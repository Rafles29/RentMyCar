using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model;
using Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using RentMyCar.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMyCar.Controllers
{
    [AllowAnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {

        private IUserRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, UserManager<User> userManager,
            IMapper mapper)
        {
            this._repo = userRepository;
            this._userManager = userManager;
            this._mapper = mapper;
        } 

        // GET: api/values
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repo.GetUsers();            
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(users));
        }

        // GET api/values/5
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<User, UserView>(user));

        }
    }
}
