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
    [Route("api/Tables")]
    public class TablesController : Controller
    {
        private CompetitionTablesService service;

        public TablesController(CompetitionTablesService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGeneralTable(int id)
        {
            var res = service.GetTable(id, Models.CompetitionTableType.General);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public IActionResult GetGeneralTable(string name)
        {
            var res = service.GetTable(name, Models.CompetitionTableType.General);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{id:int}/home")]
        public IActionResult GetHomeTable(int id)
        {
            var res = service.GetTable(id, Models.CompetitionTableType.Home);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}/home")]
        public IActionResult GetHomeTable(string name)
        {
            var res = service.GetTable(name, Models.CompetitionTableType.Home);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{id:int}/away")]
        public IActionResult GetAwayTable(int id)
        {
            var res = service.GetTable(id, Models.CompetitionTableType.Away);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{name}/away")]
        public IActionResult GetAwayTable(string name)
        {
            var res = service.GetTable(name, Models.CompetitionTableType.Away);
            if (res.Count() == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}