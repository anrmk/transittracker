using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitTracker.Models {
    public class RouteModel {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TimeSpan> Transits { get; set; }

        public int StopId { get; set; }

        public string StopName { get; set; }
    }
}
