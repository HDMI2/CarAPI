using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace CarRental.Helpers
{
    internal class CarRentalRouter
    {
        private IRouteBuilder _routes;

        public CarRentalRouter(IRouteBuilder routes)
        {
            this._routes = routes;
            ConfigureRoutes();
        }

        private void ConfigureRoutes()
        {
            _routes.MapRoute(
                name: "default",
                template: "{controller}/{action}",
                defaults: new { controller = "Cars", action = "Index" });

            //PArams
            _routes.MapRoute(
                name: "carRoute",
                template: "{controller}/{id?}/{action}/",
                defaults: new { controller = "Cars", action = "Index" });

            //constrains
            _routes.MapRoute(
              name: "carRoute1",
              template: "{controller}/{id:alpha}/{action}/",
              defaults: new { controller = "Cars", action = "Test" });
        }
    }
}