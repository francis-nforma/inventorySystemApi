using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventoryApi.Models;
using inventoryApi.Models.DTO;
using inventoryApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace inventoryApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IDataRepository<Car, CarDTO> _dataRepository;

        public CarsController(IDataRepository<Car, CarDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET api/cars/1
        [HttpGet("{id}", Name ="GetCar")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _dataRepository.Get(id);
            if (car == null)
            {
                return NotFound("Car not found.");
            }
            return Ok(car);
        }

        //GET api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            var cars = await _dataRepository.GetAll();
            return Ok(cars);
        }

        // POST api/cars
        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {
            var newCar = await _dataRepository.Add(car);
            return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
        }

        // PUT api/Cars/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            await _dataRepository.Update(car);
            return NoContent();
        }

        // DELETE api/Cars/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var carToDelete = await _dataRepository.Get(id);
            if (carToDelete == null)
            {
                return NotFound();
            }
            await _dataRepository.Delete(carToDelete.Id);
            return NoContent();
        }
    }
}