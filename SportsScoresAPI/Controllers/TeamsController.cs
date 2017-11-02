using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsScoresAPI.Services;
using SportsScoresAPI.Models.DTO;

namespace SportsScoresAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Teams")]
    public class TeamsController : Controller
    {
        private TeamsService service;

        public TeamsController(TeamsService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCompetitionTeams(int id)
        {
            var res = service.GetCompetitionTeams(id);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public IActionResult GetCompetitionTeams(string name)
        {
            var res = service.GetCompetitionTeams(name);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}