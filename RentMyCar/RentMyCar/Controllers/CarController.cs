using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMyCar.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private CarRepository _repo;

        public CarController(CarRepository carRepository)
        {
            this._repo = carRepository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _repo.GetCars();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _repo.GetCar(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Car car)
        {
            _repo.AddCar(car);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Car car)
        {
            _repo.UpdateCar(id, car);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteCar(id);
        }
    }
}
