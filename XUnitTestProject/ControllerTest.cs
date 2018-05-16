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

            CarRepository carRepository = new CarRepository();
            var controller = new CarWebApi.Controllers.CarController(carRepository);
            var result = await controller.GetAllCars();

            //var okResult = result.Should().BeOfType<IEnumerable<Car>>().Subject;
            //var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Car>>().Subject;

            //persons.Count().Should().Be(50);
        }

        [Fact]
        public async void Car_Post()
        {
            //https://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html

            CarRepository carRepository = new CarRepository();
            var controller = new CarWebApi.Controllers.CarController(carRepository);
            Car car = new Car() { ModelName = "Name", YearOfConstruction = 2000, BrandName = BrandNames.BMW };
            var result = await controller.Post(car);


        }
    }

}
