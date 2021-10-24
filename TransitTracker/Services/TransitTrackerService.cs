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

        private List<StopModel> Stops { get; set; }
        private List<RouteModel> Routes { get; set; }

        public TransitTrackerService() {
            var today = DateTime.Today;
            var startTime = new TimeSpan(); //new DateTime(today.Year, today.Month, today.Day).TimeOfDay;

            Stops = new List<StopModel>();

            for(int stopIndex = 0; stopIndex < busStops; stopIndex++) {    // 10 bus stop
                var routeStartTime = startTime;

                var stop = new StopModel {
                    Id = stopIndex,
                    Name = $"Stop #{stopIndex + 1}",
                    Routes = new List<RouteModel>()
                };

                for(int routeIndex = 0; routeIndex < routeCount; routeIndex++) { // 3 routes
                    routeStartTime = startTime.Add(new TimeSpan(0, 2 * routeIndex, 0)); //each route starts running 2 minutes after the previous one

                    var route = new RouteModel {
                        Id = routeIndex,
                        Name = $"Route #{routeIndex + 1}",
                        Transit = new Dictionary<int, List<TimeSpan>>(),
                        StopId = stopIndex
                    };

                    for(int transitIndex = 0; transitIndex < Transits; transitIndex ++) { //96 routes
                        if(!route.Transit.ContainsKey(stopIndex)) {
                            route.Transit.Add(stopIndex, new List<TimeSpan>());
                        }
                        route.Transit[stopIndex].Add(routeStartTime);

                        routeStartTime = routeStartTime.Add(new TimeSpan(0, serviceInterval, 0)); //Each stop is serviced every 15 minutes per route
                    }

                    Routes.Add(route);

                    stop.Routes.Add(route);
                }

                Stops.Add(stop);
                startTime = startTime.Add(new TimeSpan(0, 2, 0)); // Each stop is 2 minutes away from the previous one
            }
        }
    
        public List<RouteModel> GetRoutes(int stopId) {
            var time = DateTime.Now.TimeOfDay;

            return Routes
                .Where(x => x.StopId == stopId)
                .Select(x => new RouteModel {
                    Name = x.Name,
                    Transit = x.Transit
                        
                      
                    
                }).ToList();
        }
    }
}
