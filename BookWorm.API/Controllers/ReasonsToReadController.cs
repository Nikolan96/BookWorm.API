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
    public class ReasonsToReadController : ControllerBase
    {
        private readonly IReasonToReadService _criticReviewService;

        public ReasonsToReadController(IReasonToReadService reasonToReadService)
        {
            _criticReviewService = reasonToReadService;
        }

        [HttpGet("{id}")]
        public ActionResult<ReasonsToRead> Get(Guid id)
        {
            var item = _criticReviewService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReasonsToRead>> Get()
        {
            return Ok(_criticReviewService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] ReasonsToRead newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _criticReviewService.AddReasonToRead(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] ReasonsToRead changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _criticReviewService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _criticReviewService.UpdateReasonToRead(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _criticReviewService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _criticReviewService.RemoveReasonToRead(item);

            return Ok();
        }
    }
}