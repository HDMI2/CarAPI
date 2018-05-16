﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.Api.Models;
using Training.Api.Services;

namespace Training.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private ICarRepository _carRepository;

        public CarsController(ICarRepository  carRepository)
        {
            _carRepository = carRepository;
        }

        //public CarsController(CarAPIContext ctx)
        //{
        //    _ctx = ctx;
        //}

        [HttpGet]
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            //var cars = await _ctx.CarSet.ToListAsync();
            //return Ok(cars);
           
            return await _carRepository.GetAll() ;

        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {

            return await _carRepository.FindByIdAsync(id);            

        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {

            var res =await _carRepository.Update(car);

            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var car = await _carRepository.FindByIdAsync(id);
            _carRepository.Remove(car);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Car car)
        {

            if (car.Id != id)
            {
                return BadRequest();

            }

            await _carRepository.Update(car);
            return new NoContentResult();
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<Car>> Patch(int id, [FromBody] JsonPatchDocument<Car> patch)
        {
            var car = await _carRepository.FindByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            patch.ApplyTo(car, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _carRepository.SaveAll();
            return car;
        }

        //Schließen der DB Verbindung
        ~CarsController()
        {
            Dispose();
        }

    }
}