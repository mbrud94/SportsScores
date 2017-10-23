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
    public class PlayersDataProvider : IExternalDataProvider
    {
        public IExternalData GetData(string url)
        {
            PlayersList res = new PlayersList();
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                var stringResult = response.Result;
                res = JsonConvert.DeserializeObject<PlayersList>(stringResult);
            }
            return res;
        }

        public IExternalData GetData(Stream stream)
        {
            PlayersList players = null;
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                players = (PlayersList)serializer.Deserialize(reader, typeof(PlayersList));
            }
            return players;
        }
    }
}
