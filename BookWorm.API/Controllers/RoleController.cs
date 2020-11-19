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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService bookService)
        {
            _roleService = bookService;
        }

        [HttpGet("{id}")]
        public ActionResult<Role> Get(Guid id)
        {
            var item = _roleService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetUserRoleId")]
        public ActionResult GetAdminRoleId()
        {
            var adminRoleId = _roleService.AsQueryable()
                 .Where(x => x.Name == "User")
                 .FirstOrDefault().Id;

            return Ok(adminRoleId); 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            return Ok(_roleService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Role newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var existingRoles = _roleService.AsQueryable().ToList();

            foreach (var existingRole in existingRoles)
            {
                if (newItem.Name.ToLower() == existingRole.Name.ToLower())
                {
                    return BadRequest($"Role {newItem.Name} already exists!");
                }
            }

            var item = _roleService.AddRole(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Role changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _roleService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _roleService.UpdateRole(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _roleService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _roleService.RemoveRole(item);

            return Ok();
        }
    }
}
