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
        private readonly IRoleService _roleService;

        public UserController(IUserService reasonToReadService,
            IAddressService addressService,
            IRoleService roleService)
        {
            _userService = reasonToReadService;
            _addressService = addressService;
            _roleService = roleService;
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
        [Route("GetWithPagination")]

        public ActionResult GetWithPagination(PaginationRequest request)
        {
            if (request.Page <= 0)
            {
                return BadRequest("Page cannot be 0 or less than 0!");
            }

            if (request.ItemsPerPage <= 0)
            {
                return BadRequest("Items per page cannot be 0 or less than 0!");
            }

            var list = _userService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpGet]
        [Route("GetNumberOfPages/{itemsPerPage}")]
        public ActionResult GetNumberOfPages(double itemsPerPage)
        {
            if (itemsPerPage <= 0)
            {
                return BadRequest("Items per page cannot be 0 or less than 0!");
            }

            double totalItems = _userService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
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
                return BadRequest("Wrong email or password!");
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("CheckIfEmailExists/{email}")]
        public ActionResult<bool> CheckIfEmailExists(string email)
        {
            var existingUser = _userService
                .AsQueryable()
                .Where(x => x.Email == email)
                .FirstOrDefault();

            if (existingUser is null)
            {
                return Ok(false);
            }

            return Ok(true);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult<IEnumerable<User>> Register([FromBody]RegisterRequest request)
        {

            if (request is null || request.Address is null || request.UserRegistration is null)
            {
                return BadRequest();
            }

            var existing = _userService.AsQueryable().Any(x => x.Email == request.UserRegistration.Email);

            if (existing)
            {
                return BadRequest($"User with email : {request.UserRegistration.Email} already exists!");
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

        private User MapUserRegistrationToUser(RegisterRequest request, Guid addressId)
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
                RoleId = _roleService.GetUserRoleId()
            };
        }
    }
}