using BookWorm.API.Extensions;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactController : ControllerBase
    {
        private readonly IBookFactService _bookFactService;
        private readonly IAuthorFactService _authorFactService;

        public FactController(IBookFactService bookFactService,
            IAuthorFactService authorFactService)
        {
            _bookFactService = bookFactService;
            _authorFactService = authorFactService;
        }

        [HttpGet()]
        [Route("GetRandomFact")]
        public ActionResult<object> Get(Guid id)
        {
            var rnd = new Random();
            var facts = new List<EntityBase>();

            var authorFacts = _authorFactService
                .AsQueryable()
                .ToList();

            var bookFacts = _bookFactService
                .AsQueryable()
                .ToList();

            facts.AddRange(authorFacts);
            facts.AddRange(bookFacts);

            facts.Shuffle();

            var rndFact = facts[rnd.Next(0, facts.Count-1)];

            return Ok(rndFact);
        }
    }
}
