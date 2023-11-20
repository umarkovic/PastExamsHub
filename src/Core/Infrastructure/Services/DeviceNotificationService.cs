using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PastExamsHub.Base.Infrastructure;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Models;
using PastExamsHub.Core.Domain.Enums;

namespace PastExamsHub.Core.Infrastructure.Services
{
    public class DeviceNotificationService : IDeviceNotificationService
    {
        readonly ILogger<DeviceNotificationService> Logger;
        readonly Options.FirebaseCloudMessaging Options;
        readonly IHttpClientFactory HttpClientFactory;
        readonly JsonSerializerSettings JsonSerializerSettings;

        public DeviceNotificationService
        (
            ILogger<DeviceNotificationService> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory
        )
        {
            Logger = logger;
            Options = configuration.Read<Options.FirebaseCloudMessaging>();
            HttpClientFactory = httpClientFactory;

            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            };

            JsonSerializerSettings.Converters.Add(new StringEnumConverter());//using Newtonsoft.Json.Converters;
        }

        string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
        }

        TObject Deserialize<TObject>(string json)
        {
            return JsonConvert.DeserializeObject<TObject>(json, JsonSerializerSettings);
        }

        public async Task SendAsync(string deviceId, DeviceNotificationModel notification, CancellationToken cancellationToken)
        {
            try
            {
                await _SendAsync(deviceId, notification, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error sending {notificationModel}", notification);
            }
        }

        /// <summary>
        /// Send firebase notification.
        /// Please check out payload formats:
        /// https://firebase.google.com/docs/cloud-messaging/concept-options#notifications
        /// The SendAsync method will add/replace "to" value with deviceId
        /// </summary>
        /// <param name="deviceId">Device token (will add `to` to the payload)</param>
        /// <param name="payload">Notification payload that will be serialized using Newtonsoft.Json package</param>
        /// <cref="HttpRequestException">Throws exception when not successful</exception>
        async Task _SendAsync(string deviceId, DeviceNotificationModel notification, CancellationToken cancellationToken)
        {
            using (var httpClient = HttpClientFactory.CreateClient())
            {
                string authorizationKey = string.Format("keyy={0}", Options.ServerKey);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var fcmNotification = new FcmNotification()
                {
                    Data = notification,
                    NotificationPayload = notification //REVIEW: not needed?
                };

                var jsonObject = JObject.FromObject(fcmNotification);
                jsonObject.Remove("to");
                jsonObject.Add("to", JToken.FromObject(deviceId));

                var serialized = Serialize(jsonObject);
                string responseString;
                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, Options.Url))
                {
                    httpRequest.Headers.Add("Authorization", $"key = {Options.ServerKey}");

                    if (!string.IsNullOrEmpty(Options.SenderId))
                    {
                        httpRequest.Headers.Add("Sender", $"id = {Options.SenderId}");
                    }

                    httpRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

                    
                    using (var response = await httpClient.SendAsync(httpRequest, cancellationToken))
                    {
                        responseString = await response.Content.ReadAsStringAsync();

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new HttpRequestException(responseString);
                        }
                    }
                }
                var fcmResponse = Deserialize<FcmResponse>(responseString);

                if (!fcmResponse.IsSuccess())
                {
                    var errorMessage = string.Join("; ", fcmResponse.Results.Select(x => x.Error));
                    throw new Exception(errorMessage);
                }
            }
        }

        public class FcmNotification
        {
            [JsonProperty("priority")]
            public string Priority { get; set; } = "high";

            [JsonProperty("data")]
            public DeviceNotificationModel Data { get; set; }

            [JsonProperty("notification")]
            public DeviceNotificationModel NotificationPayload { get; set; }
        }

        public class FcmResponse
        {
            [JsonProperty("multicast_id")]
            public string MulticastId { get; set; }

            [JsonProperty("canonical_ids")]
            public int CanonicalIds { get; set; }

            public int Success { get; set; }

            public int Failure { get; set; }

            public List<FcmResult> Results { get; set; }

            public bool IsSuccess()
            {
                return Success > 0 && Failure == 0;
            }
        }

        public class FcmResult
        {
            [JsonProperty("message_id")]
            public string MessageId { get; set; }

            [JsonProperty("registration_id")]
            public string RegistrationId { get; set; }

            public string Error { get; set; }
        }
    }
}

