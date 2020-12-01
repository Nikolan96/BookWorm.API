using BookWorm.API.Requests;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCurrentlyReadingController : ControllerBase
    {
        private readonly IUserCurrentlyReadingService _UserCurrentlyReadingService;

        public UserCurrentlyReadingController(IUserCurrentlyReadingService UserCurrentlyReadingService)
        {
            _UserCurrentlyReadingService = UserCurrentlyReadingService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserCurrentlyReading> Get(Guid id)
        {
            var item = _UserCurrentlyReadingService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserCurrentlyReading>> Get()
        {
            return Ok(_UserCurrentlyReadingService
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

            var list = _UserCurrentlyReadingService.AsQueryable()
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

            double totalItems = _UserCurrentlyReadingService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserCurrentlyReading newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _UserCurrentlyReadingService.AddUserCurrentlyReading(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserCurrentlyReading changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _UserCurrentlyReadingService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _UserCurrentlyReadingService.UpdateUserCurrentlyReading(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _UserCurrentlyReadingService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _UserCurrentlyReadingService.RemoveUserCurrentlyReading(item);

            return Ok();
        }
    }
}