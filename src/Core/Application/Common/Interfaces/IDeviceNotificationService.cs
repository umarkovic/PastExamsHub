using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Core.Application.Common.Models;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface IDeviceNotificationService
    {
        //TODO: always call from EventHandler
        Task SendAsync(string deviceId, DeviceNotificationModel notification, CancellationToken cancellationToken);
    }
}
