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
    [Route("api/Competitions")]
    public class CompetitionsController : Controller
    {
        private CompetitionsService service;

        public CompetitionsController(CompetitionsService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var res = service.GetAll();
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}