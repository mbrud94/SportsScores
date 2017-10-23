using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.ExternalDataProviders
{
    public class DataReader
    {
        private const string API_URL = @"http://api.football-data.org";
        private const string COMPETITION_URL = @"/v1/competitions/";

        private IExternalDataProvider competitionProvider;
        private IExternalDataProvider teamsProvider;
        private IExternalDataProvider playersProvider;
        private IExternalDataProvider gamesProvider;

        public bool readCompetition { get; set; }
        public bool readGames { get; set; }
        public bool readTeams { get; set; }
        public bool readPlayers { get; set; }
        public int startId { get; set; }

        public DataReader()
        {
            this.competitionProvider = new CompetitionDataProvider();
            this.teamsProvider = new TeamsDataProvider();
            this.playersProvider = new PlayersDataProvider();
            this.gamesProvider = new GamesDataProvider();

        }

        public ExternalData ReadData()
        {
            ExternalData res = new ExternalData();
            if (readCompetition)
            {
                var competition = competitionProvider.GetData(string.Format($"{API_URL}{COMPETITION_URL}{startId}/")) as CompetitionExt;
                res.Competition = competition;
                if (readTeams)
                {
                    var teams = teamsProvider.GetData(competition._links.Teams.Href) as TeamsList;
                    competition.Teams = teams;
                    if (readPlayers)
                    {
                        foreach (var team in teams.Teams)
                        {
                            var players = playersProvider.GetData(team._links.Players.Href) as PlayersList;
                            team.Players = players;
                        }
                    }
                }
                if (readGames)
                {
                    var games = gamesProvider.GetData(competition._links.Fixtures.Href) as FixturesList;
                    competition.Fixtures = games;
                }
            }
            return res;
        }
    }
}
