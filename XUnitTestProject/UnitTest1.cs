using CarRental.Controllers;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void Values_Get_All()
        {
            //https://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html
            // Arrange
            //DbContextOptions dbContextOptions;
            //CarRentalDBContext carRentalDBContext = new CarRentalDBContext(dbContextOptions);

            //var controller = new CarsController(carRentalDBContext);

            //// Act
            //var result = await controller.Get();

            //// Assert
            //var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            //var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Car>>().Subject;

            //persons.Count().Should().Be(50);
        }

    }
}
