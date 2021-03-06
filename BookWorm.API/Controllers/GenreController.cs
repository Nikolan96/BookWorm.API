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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> Get(Guid id)
        {
            var item = _genreService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            return Ok(_genreService
                .AsQueryable()
                .OrderBy(x => x.Name)
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

            var list = _genreService.AsQueryable()
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

            double totalItems = _genreService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var existingGenres = _genreService.AsQueryable().ToList();

            foreach (var existingGenre in existingGenres)
            {
                if (newItem.Name.ToLower() == existingGenre.Name.ToLower())
                {
                    return BadRequest($"Genre {newItem.Name} already exists!");
                }
            }

            var item = _genreService.AddGenre(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _genreService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _genreService.UpdateGenre(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _genreService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _genreService.RemoveGenre(item);

            return Ok();
        }
    }
}
