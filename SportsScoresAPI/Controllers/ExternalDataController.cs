using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SportsScoresAPI.ExternalDataProviders;
using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using System.IO;
using Newtonsoft.Json;

namespace SportsScoresAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ExternalData")]
    public class ExternalDataController : Controller
    {
        private IHostingEnvironment _env;
        private DataSaver _saver;

        public ExternalDataController(IHostingEnvironment env, DataSaver saver)
        {
            _env = env;
            _saver = saver;
        }

        [HttpGet("[action]")]
        public IActionResult Save()
        {
            string path = _env.ContentRootPath + @"/AppData/PremierLeague.json";
            ExternalData data = new ExternalData();
            using (StreamReader sr = new StreamReader(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = (ExternalData)serializer.Deserialize(sr, typeof(ExternalData));
            }
            _saver.Save(data);
            return Ok();
        }

    }
}