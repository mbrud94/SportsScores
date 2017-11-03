using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services
{
    public class AdminService
    {
        private const string PASSWORD = "f865b53623b121fd34ee5426c792e5c33af8c227";

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
