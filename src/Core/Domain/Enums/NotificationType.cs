using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PastExamsHub.Core.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationType
    {
        
    }
}
