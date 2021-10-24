using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

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
        public void GetStops() {


        }

        //private static readonly string[] Summaries = new[] {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};


    }
}
