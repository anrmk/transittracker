using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet(Name = "GetStops")]
        public IEnumerable<RouteModel> GetStops(int id) {
            var routes = _transitTrackerService.GetRoutes(id);
            return routes;
        }
    }
}
