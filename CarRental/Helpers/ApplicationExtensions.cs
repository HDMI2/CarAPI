using Microsoft.AspNetCore.Builder;
namespace CarRental.Helpers
{
    public static class ApplicationExtensions
    {
        public static void UseCarRentalRouter( this IApplicationBuilder app)
        {
            app.UseMvc(routes => new CarRentalRouter(routes));

        }

    }
}
