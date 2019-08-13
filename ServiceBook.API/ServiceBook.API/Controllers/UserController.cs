using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System.Collections.Generic;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            IEnumerable<User> usersFromRepo = _userRepository.GetAll();
            IEnumerable<UserDto> users = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(usersFromRepo);

            return Ok(users);
        }
    }
}
