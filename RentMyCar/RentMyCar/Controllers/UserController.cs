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
    public class UserController : Controller
    {

        private UserRepository _repo;

        public UserController(UserRepository userRepository)
        {
            this._repo = userRepository;
        }
        // GET: api
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User value)
        {
            _repo.AddUser(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
