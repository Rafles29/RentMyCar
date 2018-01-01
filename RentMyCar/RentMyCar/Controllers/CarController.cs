using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model;
using Model.Repository;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMyCar.Controllers
{
    [AllowAnonymous]
    [Route("api/cars")]
    public class CarController : Controller
    {
        private ICarRepository _repo;

        public CarController(ICarRepository carRepository)
        {
            this._repo = carRepository;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_repo.GetCars());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult GetCar(int id)
        {
            var car = _repo.GetCar(id);
            if(car == null)
            {
                return BadRequest();
            }
            return Ok(car);
        }

        // POST api/values
        [HttpPost]
        public IActionResult PostCar([FromBody]Car newCar)
        {
            if (newCar == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var car = _repo.AddCar(newCar);

            return CreatedAtRoute("GetCar", new { id = car.CarId }, car);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult PutCar(int id, [FromBody]Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.UpdateCar(id, car);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _repo.GetCar(id);
            if (car == null)
            {
                return BadRequest();
            }
            _repo.DeleteCar(id);
            return NoContent();
        }
    }
}
