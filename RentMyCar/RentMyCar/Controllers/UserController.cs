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
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IUserRepository _repo;

        public UserController(IUserRepository userRepository)
        {
            this._repo = userRepository;
        } 


        // GET: api/values
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_repo.GetUsers());
        }
        // GET api/values/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = _repo.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // POST api/values
        [HttpPost]
        public IActionResult PostRent([FromBody]User newUser)
        {
            if(newUser == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _repo.AddUser(newUser);

            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult PutRent(int id, [FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.UpdateUser(id, user);

            return NoContent();
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRent(int id)
        {
            var user = _repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            _repo.DeleteUser(id);
            return NoContent();
        }
    }
}
