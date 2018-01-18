using Conductor.Repositories;
using Conductor.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Conductor.Controllers
{
    [Produces("application/json")]
    [Route("api/Artists/{ArtistKey}/Compositions")]
    public class CompositionsController : Controller
    {
        private readonly ICompositionRepository _repository;

        public CompositionsController(ICompositionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IEnumerable<CompositionDTO> GetUnplayedCompositions([FromRoute] string artistKey)
        {
            if (!ModelState.IsValid)
                return new CompositionDTO[0];

            return _repository.GetUnplayedCompositions(artistKey);
        }

        [HttpPut("{Key}/MarkAsPlayed")]
        public IActionResult MarkAsPerformed([FromRoute] string ArtistKey, [FromRoute] string Key, [FromBody] PerformanceDTO result)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.MarkAsPerformed(ArtistKey, result);
            return NoContent();
        }
    }
}