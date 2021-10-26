using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

using Quartz;

using TransitTracker.Hubs;
using TransitTracker.Services;

namespace TransitTracker.Jobs {
    public class TransitJob: IJob {
        private readonly IServiceProvider _provider;
        private readonly ITransitTrackerService _transitTrackerService;
        private readonly IHubContext<TransitHub> _transitHub;

        public TransitJob(IServiceProvider provider, ITransitTrackerService transitTrackerService, IHubContext<TransitHub> transitHub) {
            _provider = provider;
            _transitTrackerService = transitTrackerService;
            _transitHub = transitHub;
        }

        public async Task Execute(IJobExecutionContext context) {
            using var scope = _provider.CreateScope();

            var currentDate = DateTime.Now;
            var time = new TimeSpan(currentDate.Hour, currentDate.Minute, 00);

            var transitTrackerService = scope.ServiceProvider.GetRequiredService<ITransitTrackerService>();
            var stops = _transitTrackerService.GetStops(time);

            await _transitHub.Clients.All.SendAsync("ReceiveMessage", stops); ///new { Stops = stops, Time = time });
        }
    }
}
