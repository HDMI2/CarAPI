using Microsoft.AspNetCore.Builder;
namespace CarWebApi.Helpers
{
    public static class ApplicationExtensions
    {
        public static void UseCarRentalRouter( this IApplicationBuilder app)
        {
            app.UseMvc(routes => new CarRentalRouter(routes));

        }

    }
}
