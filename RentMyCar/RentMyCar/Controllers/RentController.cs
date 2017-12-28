using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model;
using Model.Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMyCar.Controllers
{
    [Route("api/rents")]
    public class RentController : Controller
    {

        private IRentRepository _repo;

        public RentController(IRentRepository rentRepository)
        {
            this._repo = rentRepository;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetRents()
        {
            return Ok(_repo.GetRents());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRent")]
        public IActionResult GetRent(int id)
        {
            var rent = _repo.GetRent(id);
            if(rent == null)
            {
                return NotFound();
            }
            return Ok(rent);
        }

        // POST api/values
        [HttpPost]
        public IActionResult PostRent([FromBody]Rent newRent)
        {
            if (newRent == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rent = _repo.AddRent(newRent);

            return CreatedAtRoute("GetRent", new { id = rent.RentId }, rent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult PutRent(int id, [FromBody]Rent rent)
        {
            if (rent == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repo.UpdateRent(id, rent);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRent(int id)
        {
            var rent = _repo.GetRent(id);
            if (rent == null)
            {
                return NotFound();
            }
            _repo.DeleteRent(id);
            return NoContent();
        }

        //GET adress
        [HttpGet("{id}/adress")]
        public IActionResult GetAdress(int id)
        {
            var rent = _repo.GetRent(id);
            if (rent == null)
            {
                return NotFound();
            }
            return Ok(_repo.GetAdress(id));
        }
        [HttpPut("{id}/adress")]
        public IActionResult PutAdress(int id, [FromBody]Adress adress)
        {
            var rent = _repo.GetRent(id);
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

            return NoContent();
        }
    }
}
