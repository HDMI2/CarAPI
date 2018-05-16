using CarWebApi.Models;
using CarWebApi.Services;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class ControllerTest
    {

        [Fact]
        public async void Car_Get_AllAsync()
        {
            //https://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html
            // Arrange

            //var builder = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json");

            //DbContextOptions dbContextOptions = new

            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //;
            //CarAPIContext ctx = new CarAPIContext(dbContextOptions);
            CarAPIContext context = new CarAPIContext();
            CarRepository carRepository = new CarRepository(context);
            var controller = new CarWebApi.Controllers.CarController(carRepository);

            //// Act
            var result = await controller.GetAllCars();

            //var okResult = result.Should().BeOfType<IEnumerable<Car>>().Subject;
            //var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Car>>().Subject;

            //persons.Count().Should().Be(50);
        }

    }

}
