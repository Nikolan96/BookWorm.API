using BookWorm.API.Dto;
using BookWorm.API.Requests;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Constants;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksReadController : ControllerBase
    {
        private readonly IBooksReadService _booksReadService;
        private readonly IAwardAchievementService _awardAchievementService;

        public BooksReadController(IBooksReadService booksReadService,
            IAwardAchievementService awardAchievementService)
        {
            _booksReadService = booksReadService;
            _awardAchievementService = awardAchievementService;
        }

        [HttpGet("{id}")]
        public ActionResult<BooksRead> Get(Guid id)
        {
            var item = _booksReadService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BooksRead>> Get()
        {
            return Ok(_booksReadService
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

            var list = _booksReadService.AsQueryable()
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

            double totalItems = _booksReadService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BooksReadRequest request)
        {
            var response = new BooksReadResponse();

            if (request is null)
            {
                return BadRequest();
            }

            if (request.UserId is null || request.BookIds is null)
            {
                return BadRequest();
            }

            foreach (var bookId in request.BookIds)
            {
                var exists = _booksReadService
                .AsQueryable()
                .Any(x => x.BookId == bookId && x.UserId == request.UserId);

                if (exists)
                {
                    return BadRequest("User already read that book!");
                }

                var newBookRead = new BooksRead
                {
                    BookId = bookId,
                    UserId = (Guid)request.UserId
                };

                var item = _booksReadService.AddBooksRead(newBookRead);

                response.BooksRead.Add(item);
            }

            AwardAchievements((Guid)request.UserId, response.Achievements);

            return Ok(response);
        }

        private void AwardAchievements(Guid userId, List<Achievement> achievements)
        {
            achievements.Add(_awardAchievementService.AwardAchievement(Achievements.TheJurneyBegins, userId));
            achievements.Add(_awardAchievementService.AwardAchievement(Achievements.ApprenticeLibrarian, userId));
            achievements.Add(_awardAchievementService.AwardAchievement(Achievements.Bibliophile, userId));
            achievements.Add(_awardAchievementService.AwardAchievement(Achievements.Bookworm, userId));
        }

        [HttpPut]
        public ActionResult Put([FromBody] BooksRead changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _booksReadService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _booksReadService.UpdateBooksRead(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _booksReadService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _booksReadService.RemoveBooksRead(item);

            return Ok();
        }
    }
}
