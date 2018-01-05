using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentMyCar.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMyCar.Controllers
{
    [Route("api/cars")]
    public class CarController : Controller
    {
        private ICarRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManger;

        public CarController(ICarRepository carRepository, IMapper mapper, UserManager<User> userManger)
        {
            this._repo = carRepository;
            this._mapper = mapper;
            this._userManger = userManger;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetCars()
        {
            if(User.Identity.IsAuthenticated)
            {
                var cars = _repo.GetCars(User.Identity.Name);
                return Ok(_mapper.Map<IEnumerable<Car>, IEnumerable<CarView>>(cars));
            }
            var cars2 = _repo.GetCars();
            return Ok(_mapper.Map<IEnumerable<Car>, IEnumerable<CarView>>(cars2));
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult GetCar(int id)
        {
            var car = _repo.GetCar(id);

            if (car == null)
            {
                return BadRequest();
            }
            var mappedCar = _mapper.Map<Car, CarView>(car);
            return Ok(mappedCar);
        }

        // POST api/values
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> PostCar([FromBody]CarView newCar)
        {
            if (newCar == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var car = _mapper.Map<CarView, Car>(newCar);
            Console.WriteLine(User.Identity.Name);
            var user = await _userManger.FindByNameAsync(User.Identity.Name);
            if(user == null)
            {
                return BadRequest();
            }
            var addedCar = _repo.AddCar(User.Identity.Name, car);
            return CreatedAtRoute("GetRent", new { id = addedCar.CarId }, addedCar);
        }

        // PUT api/values/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

            _repo.UpdateCar(User.Identity.Name, id, car);
            return NoContent();
        }

        // DELETE api/values/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _repo.GetCar(id);
            if (car == null)
            {
                return BadRequest();
            }
            _repo.DeleteCar(User.Identity.Name, id);
            return NoContent();
        }
    }
}
