using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TransitTracker.Hubs;
using TransitTracker.Services;

namespace TransitTracker.Controllers {
    public class HomeController: Controller {
        private readonly IHubContext<TransitHub> _transitHub;
        private readonly ITransitTrackerService _transitTrackerService;

        public HomeController(IHubContext<TransitHub> transitHub, ITransitTrackerService transitTrackerService) {
            _transitHub = transitHub;
            _transitTrackerService = transitTrackerService;
        }

        public async Task<IActionResult> Index() {
            var time = new TimeSpan(15, 1, 00);
            var routes = _transitTrackerService.GetRoutes(0, time);

            await _transitHub.Clients.All.SendAsync("ReceiveMessage", new { Routes = routes });
            return View();
        }
    }
}
