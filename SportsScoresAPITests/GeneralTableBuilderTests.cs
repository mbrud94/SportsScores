using SportsScoresAPI.Services.CompetitionTable;
using System;
using Xunit;
using System.Linq;
using SportsScoresAPI.Models.DTO;
using System.Collections.Generic;

namespace SportsScoresAPITests
{
    public class GeneralTableBuilderTests : IClassFixture<GamesFixture>
    {
        //private GamesFixture fixture;
        //private ITableBuilder builder;
        private IEnumerable<TableRowDTO> table;
        public GeneralTableBuilderTests(GamesFixture fixture)
        {
            //this.fixture = fixture;
            //builder = new GeneralTableBuilder();
            table = new GeneralTableBuilder().Build(fixture.Games);
        }
        [Theory]
        [InlineData(GamesFixture.TEAM_A, 6)]
        [InlineData(GamesFixture.TEAM_B, 1)]
        [InlineData(GamesFixture.TEAM_C, 1)]
        public void TestTeamPoints(string teamName, int points) 
        {
            var row = table.FirstOrDefault(r => r.TeamName == teamName);
            Assert.NotNull(row);
            Assert.Equal(row.Points, points);
        }

        [Theory]
        [InlineData(GamesFixture.TEAM_A, 2, 0, 0)]
        [InlineData(GamesFixture.TEAM_B, 0, 1, 1)]
        [InlineData(GamesFixture.TEAM_C, 0, 1, 1)]
        public void TestTeamGames(string teamName, int wins, int draws, int losts)
        {
            var row = table.FirstOrDefault(r => r.TeamName == teamName);
            Assert.NotNull(row);
            Assert.Equal(row.Wins, wins);
            Assert.Equal(row.Draws, draws);
            Assert.Equal(row.Losts, losts);
            int total = wins + draws + losts;
            Assert.Equal(row.PlayedGames, total);
        }

        [Theory]
        [InlineData(GamesFixture.TEAM_A, 6, 1)]
        [InlineData(GamesFixture.TEAM_B, 4, 7)]
        [InlineData(GamesFixture.TEAM_C, 3, 5)]
        public void TestTeamGoals(string teamName, int scored, int lost)
        {
            var row = table.FirstOrDefault(r => r.TeamName == teamName);
            Assert.NotNull(row);
            Assert.Equal(row.GoalsScored, scored);
            Assert.Equal(row.GoalsLost, lost);
        }

        [Fact]
        public void TestTableOrder()
        {
            int position = 1;
            foreach(var row in table)
            {
                Assert.Equal(row.Position, position++);
            }
        }

        [Theory]
        [InlineData(GamesFixture.TEAM_A, 1)]
        [InlineData(GamesFixture.TEAM_B, 3)]
        [InlineData(GamesFixture.TEAM_C, 2)]
        public void TestTeamPosition(string teamName, int position)
        {
            var row = table.FirstOrDefault(r => r.TeamName == teamName);
            Assert.NotNull(row);
            Assert.Equal(row.Position, position);
        }
    }
}
