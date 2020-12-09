using BookWorm.API.Dto;
using BookWorm.API.Requests;
using BookWorm.Contracts.Enums;
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
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _caseService;
        private readonly ILevelingService _levelingService;
        private readonly IAwardAchievementService _awardAchievementService;

        public CaseController(ICaseService caseService,
            ILevelingService levelingService,
            IAwardAchievementService awardAchievementService)
        {
            _caseService = caseService;
            _levelingService = levelingService;
            _awardAchievementService = awardAchievementService;
        }

        [HttpGet("{id}")]
        public ActionResult<Case> Get(Guid id)
        {
            var item = _caseService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Case>> Get()
        {
            return Ok(_caseService
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

            var list = _caseService.AsQueryable()
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

            double totalItems = _caseService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
                res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult<CaseResponse> Post([FromBody] Case newItem)
        {
            var response = new CaseResponse();

            if (newItem is null)
            {
                return BadRequest();
            }

            response.Case = _caseService.AddCase(newItem);

            response.Achievements = AwardAchievements((Guid)newItem.UserId);

            var lvl = _levelingService.AddExperience(newItem.UserId, Activity.CreatedCase);

            if (lvl > 0)
            {
                response.LevelupResponse = new LevelupResponse
                {
                    NewLevel = lvl
                };
            }

            return Ok(response);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Case changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _caseService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _caseService.UpdateCase(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _caseService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _caseService.RemoveCase(item);

            return Ok();
        }

        private List<Achievement> AwardAchievements(Guid userId)
        {
            // TODO : refactor when there is time

            var a1 = _awardAchievementService.AwardAchievement(Achievements.OneCase, userId);
            var a2 = _awardAchievementService.AwardAchievement(Achievements.ThreeCases, userId);
            var a3 = _awardAchievementService.AwardAchievement(Achievements.FiveCases, userId);
            var a4 = _awardAchievementService.AwardAchievement(Achievements.TenCases, userId);

            if (a1 != null || a2 != null || a3 != null || a4 != null)
            {
                var achies = new List<Achievement>();

                if (a1 != null)
                    achies.Add(a1);

                if (a2 != null)
                    achies.Add(a2);

                if (a3 != null)
                    achies.Add(a3);

                if (a4 != null)
                    achies.Add(a4);
            }

            return null;
        }
    }
}