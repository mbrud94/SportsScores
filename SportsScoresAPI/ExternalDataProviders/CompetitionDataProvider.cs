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
    public class CompetitionDataProvider : IExternalDataProvider
    {
        public IExternalData GetData(string url)
        {
            CompetitionExt res = new CompetitionExt();
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                var stringResult = response.Result;
                res = JsonConvert.DeserializeObject<CompetitionExt>(stringResult);
            }
            return res;
        }

        public IExternalData GetData(Stream stream)
        {
            CompetitionExt competition = null;
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                competition = (CompetitionExt)serializer.Deserialize(reader, typeof(CompetitionExt));
            }
            return competition;
        }
    }
}
