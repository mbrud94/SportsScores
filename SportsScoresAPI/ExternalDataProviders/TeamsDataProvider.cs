using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using Newtonsoft.Json;
using System.Net.Http;

namespace SportsScoresAPI.ExternalDataProviders
{
    public class TeamsDataProvider : IExternalDataProvider
    {
        public IExternalData GetData(string url)
        {
            TeamsList res = new TeamsList();
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                var stringResult = response.Result;
                res = JsonConvert.DeserializeObject<TeamsList>(stringResult);
            }
            return res;
        }

        public IExternalData GetData(Stream stream)
        {
            TeamsList teams = null;
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                teams = (TeamsList)serializer.Deserialize(reader, typeof(TeamsList));
            }
            return teams;
        }
    }
}
