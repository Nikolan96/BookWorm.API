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
    public class AuthorFactController : ControllerBase
    {
        private readonly IAuthorFactService _authorFactService;

        public AuthorFactController(IAuthorFactService authorFactService)
        {
            _authorFactService = authorFactService;
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorFact> Get(Guid id)
        {
            var item = _authorFactService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorFact>> Get()
        {
            return Ok(_authorFactService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] AuthorFact newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _authorFactService.AddAuthorFact(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] AuthorFact changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _authorFactService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _authorFactService.UpdateAuthorFact(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _authorFactService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _authorFactService.RemoveAuthorFact(item);

            return Ok();
        }
    }
}