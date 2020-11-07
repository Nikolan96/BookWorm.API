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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService bookService)
        {
            _addressService = bookService;
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get(Guid id)
        {
            var item = _addressService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            return Ok(_addressService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Address newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _addressService.AddAddress(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Address changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _addressService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _addressService.UpdateAddress(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _addressService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _addressService.RemoveAddress(item);

            return Ok();
        }
    }
}
