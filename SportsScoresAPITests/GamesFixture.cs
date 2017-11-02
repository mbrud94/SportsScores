using SportsScoresAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScoresAPITests
{
    public class GamesFixture
    {
        public List<GameDTO> Games { get; set; }

        public const string TEAM_A = "TeamA";
        public const string TEAM_B = "TeamB";
        public const string TEAM_C = "TeamC";
        public const string TEAM_D = "TeamD";

        public GamesFixture()
        {
            Games = new List<GameDTO>
            {
                new GameDTO
                {
                    HomeTeam = TEAM_A,
                    AwayTeam = TEAM_B,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                },

                new GameDTO
                {
                    HomeTeam = TEAM_A,
                    AwayTeam = TEAM_C,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 0,
                },

                new GameDTO
                {
                    HomeTeam = TEAM_B,
                    AwayTeam = TEAM_C,
                    HomeTeamGoals = 3,
                    AwayTeamGoals = 3,
                }
            };

        }
    }
}
