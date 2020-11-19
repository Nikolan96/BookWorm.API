﻿using BookWorm.API.Requests;
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
        private readonly IReasonToReadService _reasonsToReadService;

        public ReasonsToReadController(IReasonToReadService reasonToReadService)
        {
            _reasonsToReadService = reasonToReadService;
        }

        [HttpGet("{id}")]
        public ActionResult<ReasonsToRead> Get(Guid id)
        {
            var item = _reasonsToReadService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReasonsToRead>> Get()
        {
            return Ok(_reasonsToReadService
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

            var list = _reasonsToReadService.AsQueryable()
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

            double totalItems = _reasonsToReadService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ReasonsToRead newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _reasonsToReadService.AddReasonToRead(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] ReasonsToRead changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _reasonsToReadService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _reasonsToReadService.UpdateReasonToRead(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _reasonsToReadService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _reasonsToReadService.RemoveReasonToRead(item);

            return Ok();
        }
    }
}