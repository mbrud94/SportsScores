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
    [Route("api/Players")]
    public class PlayersController : Controller
    {
        private PlayersService service;

        public PlayersController(PlayersService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTeamPlayers(int id)
        {
            var res = service.GetTeamPlayers(id);
            if(res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public IActionResult GetTeamPlayers(string name)
        {
            var res = service.GetTeamPlayers(name);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}