using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TransitTracker.Models;

namespace TransitTracker.Services {
    public interface ITransitTrackerService {
        List<RouteModel> GetRoutes(int stopId);
    }

    public class TransitTrackerService: ITransitTrackerService {
        private static readonly int busStops = 10;
        private static readonly int routeCount = 3;
        private static readonly int serviceInterval = 15; //min
        private static readonly int delay = 2; //min
        private static readonly int distanceTime = 2; //min
        private int Transits => 24 * 60 / serviceInterval; //24h =  1440m; 

        private List<RouteModel> Routes { get; set; }

        public TransitTrackerService() {
            Init();
        }

        private void Init() {
            var startTime = new TimeSpan();
            Routes = new List<RouteModel>();

            for(int stopIndex = 0; stopIndex < busStops; stopIndex++) {    // 10 bus stop
                var routeStartTime = startTime;

                for(int routeIndex = 0; routeIndex < routeCount; routeIndex++) { // 3 routes
                    routeStartTime = startTime.Add(new TimeSpan(0, delay * routeIndex, 0)); //each route starts running 2 minutes after the previous one

                    var route = new RouteModel {
                        Id = routeIndex,
                        Name = $"Route #{routeIndex + 1}",
                        Transits = new List<TimeSpan>(),
                        StopId = stopIndex,
                        StopName = $"Stop #{stopIndex + 1}"
                    };

                    for(int transitIndex = 0; transitIndex < Transits; transitIndex++) { //96 routes
                        route.Transits.Add(routeStartTime);
                        routeStartTime = routeStartTime.Add(new TimeSpan(0, serviceInterval, 0)); //Each stop is serviced every 15 minutes per route
                    }

                    Routes.Add(route);
                }
                startTime = startTime.Add(new TimeSpan(0, distanceTime, 0)); // Each stop is 2 minutes away from the previous one
            }
        }

        public List<RouteModel> GetRoutes(int stopId) {
            //var time = DateTime.Now.TimeOfDay;
            var time = new TimeSpan(15, 1, 00);

            return Routes
                .Where(x => x.StopId == stopId)
                .Select(x => new RouteModel {
                    Id = x.Id,
                    Name = x.Name,
                    StopId = x.StopId,
                    StopName = x.StopName,
                    Transits = x.Transits
                        .Where(y => y > time)
                        .Take(1)
                        .ToList()
                }).ToList();
        }
    }
}
