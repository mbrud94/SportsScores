using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsScoresAPI.Services;

namespace SportsScoresAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private GamesService service;

        public GamesController(GamesService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAllCompetitionGames(int id)
        {
            var res = service.GetAllCompetitionGames(id);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public IActionResult GetAllCompetitionGames(string name)
        {
            var res = service.GetAllCompetitionGames(name);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{id:int}/scheduled")]
        public IActionResult GetScheduledCompetitionGames(int id)
        {
            var res = service.GetScheduledCompetitionGames(id);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}/scheduled")]
        public IActionResult GetScheduledCompetitionGames(string name)
        {
            var res = service.GetScheduledCompetitionGames(name);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{id:int}/finished")]
        public IActionResult GetFinishedCompetitionGames(int id)
        {
            var res = service.GetFinishedCompetitionGames(id);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}/finished")]
        public IActionResult GetFinishedCompetitionGames(string name)
        {
            var res = service.GetFinishedCompetitionGames(name);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{id:int}/{matchday:int}")]
        public IActionResult GetCompetitionGamesByMatchday(int id, int matchday)
        {
            var res = service.GetCompetitionGamesByMatchday(id, matchday);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}/{matchday:int}")]
        public IActionResult GetCompetitionGamesByMatchday(string name, int matchday)
        {
            var res = service.GetCompetitionGamesByMatchday(name, matchday);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

    }
}