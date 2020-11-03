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
    public class ReasonToReadController : ControllerBase
    {
        private readonly IReasonToReadService _criticReviewService;

        public ReasonToReadController(IReasonToReadService reasonToReadService)
        {
            _criticReviewService = reasonToReadService;
        }

        [HttpGet("{id}")]
        public ActionResult<ReasonToRead> Get(Guid id)
        {
            var item = _criticReviewService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReasonToRead>> Get()
        {
            return Ok(_criticReviewService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] ReasonToRead newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _criticReviewService.AddReasonToRead(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] ReasonToRead changedItem)
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