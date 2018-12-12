using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Hubs;

namespace WebApplication2.Code
{
    public class TimedHostedService: BackgroundService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<TimedHostedService> _logger;

        public TimedHostedService(IHubContext<NotificationHub> hubContext, ILogger<TimedHostedService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Update DateTime");
                await _hubContext.Clients.All.SendAsync("Notify", $"Time is: {DateTime.Now}");
            }
            await Task.Delay(5000);

        }
        
    }
}
