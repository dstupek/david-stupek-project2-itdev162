﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreApi.Models;

namespace WebStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserDto> listUsers = new List<UserDto>() {
            new UserDto()
            {
                Firstname = "Bill",
                Lastname = "Gates",
                Email = "bill@microsoft.com",
                Phone = "+11112223333",
                Address = "New York, USA"
            },
            new UserDto()
            {
                Firstname = "Bob",
                Lastname = "Smith",
                Email = "bob@microsoft.com",
                Phone = "+11112223339",
                Address = "New York, USA"
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            if (listUsers.Count > 0)
            {
                return Ok(listUsers);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (id >= 0 && id < listUsers.Count)
            {
                return Ok(listUsers[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            //Check if email is authorized
            if (user.Email.Equals("user@example.com")) 
            {
                ModelState.AddModelError("Email", "This Email Address is not authorized");
                return BadRequest(ModelState);
            }
            listUsers.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDto user)
        {

            if (user.Email.Equals("user@example.com"))
            {
                ModelState.AddModelError("Email", "This Email Address is not authorized");
                return BadRequest(ModelState);
            }

            if (id >= 0 && id < listUsers.Count)
            { 
                listUsers[id] = user;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            if (id >= 0 && id < listUsers.Count)
            {
                listUsers.RemoveAt(id);
            }
            return NoContent();
        }

    }
}