using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SportsScoresAPI.Facades;

namespace SportsScoresAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private AdminFacade service;

        public AdminController(AdminFacade service)
        {
            this.service = service;

        }

        [Authorize]
        [HttpGet]
        [Route("checkauth")]
        public IActionResult CheckAuthentication()
        {
            return Ok("You are authenticated");
        }

        [HttpGet]
        [Route("gettoken/{password}")]
        public IActionResult GetToken(string password)
        {
            if (service.ValidatePasword(password))
            {
                string token = service.GetToken();
                return Ok(token);
            }
            return Forbid();
        }

        [Authorize]
        [HttpGet]
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            int updated = service.UpdateCompetitionGamesUsingExternalApi(id);
            if(updated == -1)
            {
                return NotFound($"Competition with id: {id} dosent exists");
            }
            return Ok($"Updated entites {updated}");
        }

        [Authorize]
        [HttpGet]
        [Route("read/file/{id:int}")]
        public IActionResult ReadFromFile(int id)
        {
            if (service.IsReadFromFilePossible(id))
            {
                service.ReadFullCompetitionFromFile(id);
                return NoContent();
            }
            return BadRequest("Read from file impossible, file dosent exist or data already in database");
        }

        //TODO: read from api if needed - route read/api/{id}
    }
}