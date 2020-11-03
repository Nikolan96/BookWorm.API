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
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("{id}")]
        public ActionResult<Case> Get(Guid id)
        {
            var item = _caseService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Case>> Get()
        {
            return Ok(_caseService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Case newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _caseService.AddCase(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Case changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _caseService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _caseService.UpdateCase(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _caseService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _caseService.RemoveCase(item);

            return Ok();
        }
    }
}