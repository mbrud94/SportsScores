using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportsScoresAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<string> Test()
        {
            return Enumerable.Range(1, 5).Select(index => $"Test string {index}");
        }
    }
}