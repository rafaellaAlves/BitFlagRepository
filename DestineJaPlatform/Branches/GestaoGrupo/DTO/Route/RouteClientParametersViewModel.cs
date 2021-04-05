using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Route
{
    public class RouteClientParametersViewModel
    {
        public List<RouteClientListViewModel> RouteClient { get; set; }
        public RouteViewModel Route { get; set; }

        public RouteClientParametersViewModel(List<RouteClientListViewModel> routeClient, RouteViewModel route)
        {
            RouteClient = routeClient;
            Route = route;
        }
    }
}
