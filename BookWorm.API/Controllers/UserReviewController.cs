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
    public class UserReviewController : ControllerBase
    {
        private readonly IUserReviewService _criticReviewService;

        public UserReviewController(IUserReviewService userReviewService)
        {
            _criticReviewService = userReviewService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserReview> Get(Guid id)
        {
            var item = _criticReviewService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReview>> Get()
        {
            return Ok(_criticReviewService
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

            var list = _criticReviewService.AsQueryable()
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

            double totalItems = _criticReviewService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserReview newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var existing = _criticReviewService
                  .AsQueryable()
                  .Where(x => x.BookId == newItem.BookId && x.UserId == newItem.BookId)
                  .FirstOrDefault();

            if (existing != null)
            {
                return BadRequest("User already reviewed this book!");
            }

            var item = _criticReviewService.AddUserReview(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserReview changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _criticReviewService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _criticReviewService.UpdateUserReview(existingItem, changedItem);

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

            _criticReviewService.RemoveUserReview(item);

            return Ok();
        }
    }
}