using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using RestSharp;
using SportsScoresAPI.ExternalDataProviders;
using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using SportsScoresAPI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.Facades
{
    public class AdminFacade
    {
        private const string PASSWORD = "f865b53623b121fd34ee5426c792e5c33af8c227";

        private DataReaderBuilder externaldDataReaderBuilder;
        private DataSaver externalDataSaver;
        private IHostingEnvironment env;
        private CompetitionsService competitionsService;

        public AdminFacade(DataReaderBuilder dataReaderBuilder, DataSaver saver, IHostingEnvironment env, CompetitionsService competitionsService)
        {
            this.externaldDataReaderBuilder = dataReaderBuilder;
            this.externalDataSaver = saver;
            this.env = env;
            this.competitionsService = competitionsService;
        }

        public string GetToken()
        {
            var client = new RestClient("https://sportsscores.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"l2C2qdJWtZ5DPH1FvlqTSmv1iUF9l8Be\",\"client_secret\":\"QYeysa0zuiGCITe2D7VwkONjt_oG4DXOtWvX9Uj6twl4CDESFE5whirQEYzcYnlA\",\"audience\":\"https://sportsscores.api.com\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse<Token> response = client.Execute<Token>(request);

            return response.Data.access_token;

        }

        public bool ValidatePasword(string password)
        {
            return HashPassword(password) == PASSWORD;
        }

        public int UpdateCompetitionGamesUsingExternalApi(int competitionId)
        {
            int updatedCount = -1;
            if (competitionsService.IsCompetitionExist(competitionId))
            {
                var reader = externaldDataReaderBuilder.ReadCompetition(competitionId)
                                .WithGames()
                                .Build();

                var data = reader.ReadData();
                updatedCount = externalDataSaver.Update(data);
            }
            return updatedCount;
        }

        public void ReadFullCompetitionFromFile(int competitionId)
        {
            string fileName = ExternalDataTools.MapIdToFileName(competitionId);
            string path = $@"{env.ContentRootPath}/AppData/{fileName}.json";
            ExternalData data = new ExternalData();
            using (StreamReader sr = new StreamReader(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = (ExternalData)serializer.Deserialize(sr, typeof(ExternalData));
            }
            externalDataSaver.Create(data);
        }

        public bool IsReadFromFilePossible(int competitionId)
        {
            bool res = false;
            string fileName = ExternalDataTools.MapIdToFileName(competitionId);
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = $@"{env.ContentRootPath}/AppData/{fileName}.json";
                res = File.Exists(path) && !competitionsService.IsCompetitionExist(competitionId);
            }
            return res;
        }

        private string HashPassword(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private class Token
        {
            public string access_token { get; set; }
        }
    }
}
