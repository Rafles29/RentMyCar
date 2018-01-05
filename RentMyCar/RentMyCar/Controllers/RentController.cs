using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model;
using Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using RentMyCar.ViewModels;
using Microsoft.AspNetCore.Identity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMyCar.Controllers
{
    [Route("api/rents")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RentController : Controller
    {

        private IRentRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManger;

        public RentController(IRentRepository rentRepository, IMapper mapper, UserManager<User> userManger)
        {
            this._repo = rentRepository;
            this._mapper = mapper;
            this._userManger = userManger;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetRents()
        {
            try
            {
                var userName = User.Identity.Name;
                var rents = _repo.GetRents(userName);
                return Ok(_mapper.Map<IEnumerable<Rent>, IEnumerable<RentView>>(rents));
            }
            catch (Exception)
            {
                return BadRequest("Failed to get Rents");
            }

        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRent")]
        public IActionResult GetRent(int id)
        {
            try
            {
                var userName = User.Identity.Name;
                var rent = _repo.GetRent(userName, id);
                if (rent == null)
                {
                    return NotFound();
                }
                return Ok(rent);
            }
            catch (Exception)
            {
                return BadRequest("Failed to get Rent");
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult PostRent([FromBody]RentView newRent)
        {
            if (newRent == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rent = _mapper.Map<RentView, Rent>(newRent);

            var addedRent = _repo.AddRent(User.Identity.Name, rent);
            return CreatedAtRoute("GetRent", new { id = addedRent.RentId }, addedRent);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRent(int id)
        {
            var userName = User.Identity.Name;
            var rent = _repo.GetRent(userName, id);
            if (rent == null)
            {
                return NotFound();
            }
            _repo.DeleteRent(userName, id);
            return NoContent();
        }

        //GET adress
        [HttpGet("{id}/adress")]
        public IActionResult GetAdress(string userName, int id)
        {
            var rent = _repo.GetRent(userName, id);
            if (rent == null)
            {
                return NotFound();
            }
            return Ok(_repo.GetAdress(userName, id));
        }
        [HttpPut("{id}/adress")]
        public IActionResult PutAdress(int id, [FromBody]Adress adress)
        {

            var userName = User.Identity.Name;
            var rent = _repo.GetRent(userName, id);
            if (rent == null)
            {
                return NotFound();
            }

            if (adress == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repo.SetAdress(userName, id, adress);
            return NoContent();
        }
    }
}
