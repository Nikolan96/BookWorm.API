using BookWorm.API.Requests;
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
    public class UserBookNoteController : ControllerBase
    {
        private readonly IUserBookNoteService _userBookNoteService;

        public UserBookNoteController(IUserBookNoteService bookService)
        {
            _userBookNoteService = bookService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserBookNote> Get(Guid id)
        {
            var item = _userBookNoteService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserBookNote>> Get()
        {
            return Ok(_userBookNoteService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        [Route("GetWithPagination")]

        public ActionResult GetWithPagination(PaginationRequest request)
        {
            var list = _userBookNoteService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserBookNote newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _userBookNoteService.AddUserBookNote(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserBookNote changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _userBookNoteService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _userBookNoteService.UpdateUserBookNote(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _userBookNoteService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _userBookNoteService.RemoveUserBookNote(item);

            return Ok();
        }
    }
}
