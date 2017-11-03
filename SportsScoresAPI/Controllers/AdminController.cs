using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestSharp;
using SportsScoresAPI.Services;

namespace SportsScoresAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController(AdminService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        [Route("test")]
        public string TestAuth() //TODO: remove
        {
            return "All good. You only get this message if you are authenticated.";
        }

        [HttpGet]
        [Route("auth/{password}")]
        public IActionResult GetToken(string password) //TODO: post
        {
            if (service.ValidatePasword(password))
            {
                string token = service.GetToken();
                return Ok(token);
            }
            return Forbid();
        }
    }
}