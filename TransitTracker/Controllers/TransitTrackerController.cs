using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using TransitTracker.Models;
using TransitTracker.Services;

namespace TransitTracker.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TransitTrackerController {
        private readonly ITransitTrackerService _transitTrackerService;

        public TransitTrackerController(ITransitTrackerService transitTrackerService) {
            _transitTrackerService = transitTrackerService;
        }

        [HttpGet("GetStops", Name = "GetStops")]
        public IEnumerable<StopModel> GetStops() {
            var currentTime = DateTime.Now;

            var time = new TimeSpan(currentTime.Hour, currentTime.Minute, 00);

            var routes = _transitTrackerService.GetStops(time);
            return routes;
        }

        [HttpGet("GetRoutes", Name = "GetRoutes")]
        public IEnumerable<RouteModel> GetRoutes(int id) {
            var time = new TimeSpan(15, 1, 00);

            var routes = _transitTrackerService.GetRoutes(id, time);
            return routes;
        }
    }
}
