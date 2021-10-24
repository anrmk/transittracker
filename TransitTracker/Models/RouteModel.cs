using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitTracker.Models {
    public class RouteModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, List<TimeSpan>> Transit { get; set; }

        public int StopId { get; set; }
    }
}
