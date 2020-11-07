﻿using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriticReviewController : ControllerBase
    {
        private readonly ICriticReviewService _criticReviewService;

        public CriticReviewController(ICriticReviewService criticReviewService)
        {
            _criticReviewService = criticReviewService;
        }

        [HttpGet("{id}")]
        public ActionResult<CriticReview> Get(Guid id)
        {
            var item = _criticReviewService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CriticReview>> Get()
        {
            return Ok(_criticReviewService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] CriticReview newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _criticReviewService.AddCriticReview(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] CriticReview changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _criticReviewService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _criticReviewService.UpdateCriticReview(existingItem, changedItem);

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

            _criticReviewService.RemoveCriticReview(item);

            return Ok();
        }
    }
}