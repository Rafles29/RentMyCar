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
    public class RentController : Controller
    {

        private RentRepository _repo;

        public RentController(RentRepository rentRepository)
        {
            this._repo = rentRepository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Rent> Get()
        {
            return _repo.GetRents();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Rent Get(int id)
        {
            return _repo.GetRent(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Rent newRent)
        {
            _repo.AddRent(newRent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Rent rent)
        {
            _repo.UpdateRent(id, rent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteRent(id);
        }
    }
}
