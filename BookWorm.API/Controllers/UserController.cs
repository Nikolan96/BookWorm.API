using BookWorm.API.Requests;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;

        public UserController(IUserService reasonToReadService,
            IAddressService addressService)
        {
            _userService = reasonToReadService;
            _addressService = addressService;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            var item = _userService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<IEnumerable<User>> Login([FromBody]LoginRequest request)
        {

            if (request is null)
            {
                return BadRequest();
            }

            var user = _userService
                .AsQueryable()
                .Where(x => x.Email == request.Email && x.Password == request.Password)
                .FirstOrDefault();

            if (user is null)
            {
                return BadRequest("Wrong username or password!");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult<IEnumerable<User>> Register([FromBody]RegisterRequest request)
        {

            if (request is null || request.Address is null || request.UserRegistration is null)
            {
                return BadRequest();
            }

            var newAddress = _addressService.AddAddress(request.Address);
            var newUser = MapUserRegistrationToUser(request, newAddress.Id);

            var user = _userService.AddUser(newUser);

            return Ok(user);
        }

        [HttpPost]
        public ActionResult Post([FromBody] User newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _userService.AddUser(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] User changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _userService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _userService.UpdateUser(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _userService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _userService.RemoveUser(item);

            return Ok();
        }

        private static User MapUserRegistrationToUser(RegisterRequest request, Guid addressId)
        {
            return new User
            {
                Email = request.UserRegistration.Email,
                FirstName = request.UserRegistration.FirstName,
                LastName = request.UserRegistration.LastName,
                DateOfBirth = request.UserRegistration.DateOfBirth,
                Password = request.UserRegistration.Password,
                Gender = request.UserRegistration.Gender,
                AddressId = addressId,
            };
        }
    }
}