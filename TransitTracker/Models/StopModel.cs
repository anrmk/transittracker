using System.Collections.Generic;

namespace TransitTracker.Models {
    public class StopModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RouteModel> Routes { get; set; }
    }
}
