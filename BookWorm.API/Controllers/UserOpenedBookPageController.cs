using BookWorm.API.Requests;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOpenedBookPageController : ControllerBase
    {
        private readonly IUserOpenedBookPageService _userOpenedBookPageService;

        public UserOpenedBookPageController(IUserOpenedBookPageService bookCaseService)
        {
            _userOpenedBookPageService = bookCaseService;
        }

        //[HttpGet("{id}")]
        //public ActionResult<UserOpenedBookPage> Get(Guid id)
        //{
        //    var item = _userOpenedBookPageService.AsQueryable()
        //        .Where(x => x.Id == id)
        //        .FirstOrDefault();

        //    if (item is null)
        //        return NoContent();

        //    return Ok(item);
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<UserOpenedBookPage>> Get()
        //{
        //    return Ok(_userOpenedBookPageService
        //        .AsQueryable()
        //        .ToList());
        //}

        [HttpPost]
        [Route("GetWithPagination")]

        public ActionResult GetWithPagination(PaginationRequest request)
        {
            var list = _userOpenedBookPageService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserOpenedBookPage newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var existing = _userOpenedBookPageService
                    .AsQueryable()
                    .Where(x => x.BookId == newItem.BookId && x.UserId == newItem.UserId)
                    .FirstOrDefault();

            if (existing is null)
            {
                var item = _userOpenedBookPageService.AddUserOpenedBookPage(newItem);
            }

            return Ok();
        }

        //[HttpPut]
        //public ActionResult Put([FromBody] UserOpenedBookPage changedItem)
        //{
        //    if (changedItem is null)
        //        return BadRequest();

        //    var existingItem = _userOpenedBookPageService.AsQueryable()
        //        .Where(x => x.Id == changedItem.Id)
        //        .FirstOrDefault();

        //    if (existingItem is null)
        //        return NotFound();

        //    var item = _userOpenedBookPageService.UpdateUserOpenedBookPage(existingItem, changedItem);

        //    return Ok(item);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    var item = _userOpenedBookPageService.AsQueryable()
        //        .Where(x => x.Id == id)
        //        .FirstOrDefault();

        //    if (item is null)
        //        return NotFound();

        //    _userOpenedBookPageService.RemoveUserOpenedBookPage(item);

        //    return Ok();
        //}
    }
}