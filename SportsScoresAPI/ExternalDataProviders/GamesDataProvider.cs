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
    public class GamesDataProvider : IExternalDataProvider
    {
        public IExternalData GetData(string url)
        {
            FixturesList res = new FixturesList();
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                var stringResult = response.Result;
                res = JsonConvert.DeserializeObject<FixturesList>(stringResult);
            }
            return res;
        }

        public IExternalData GetData(Stream stream)
        {
            FixturesList fixtures = null;
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                fixtures = (FixturesList)serializer.Deserialize(reader, typeof(FixturesList));
            }
            return fixtures;
        }
    }
}
