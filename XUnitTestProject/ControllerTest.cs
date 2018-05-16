using CarWebApi.Models;
using CarWebApi.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class ControllerTest
    {

        [Fact]
        public async void Car_GetAll()
        {
            //https://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html

            CarRepository carRepository = new CarRepository();
            var controller = new CarWebApi.Controllers.CarController(carRepository);
            var result = await controller.GetAllCars();
        }

        [Fact]
        public async void Car_Delete_Last()
        {
            //https://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html

            CarRepository carRepository = new CarRepository();
            var controller = new CarWebApi.Controllers.CarController(carRepository);
            List<Car> cars = await controller.GetAllCars() as List<Car>;

            Assert.NotEmpty(cars);

            int id = (from c in cars
                      //where c.Id > 100000
                     select c).Max(c => c.Id);
            var result = await controller.Delete(id);
            await carRepository.SaveAll();
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
