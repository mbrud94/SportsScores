using SportsScoresAPI.Services.CompetitionTable;
using System;
using Xunit;
using System.Linq;
using SportsScoresAPI.Models.DTO;
using System.Collections.Generic;

namespace SportsScoresAPITests
{
    public class GeneralTableBuilderTests
    {
        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForGeneralBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestTableStructure(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            Assert.Equal(expectedTable.Count(), buildTable.Count());
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.NotNull(buildRow);
                Assert.Equal(1, buildTable.Count(r => r.TeamName == expectedRow.TeamName));
            }
        }

        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForGeneralBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestTeamsPoints(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.Equal(expectedRow.Points, buildRow.Points);
            }
        }

        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForGeneralBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestTeamGames(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.Equal(expectedRow.Wins, buildRow.Wins);
                Assert.Equal(expectedRow.Draws, buildRow.Draws);
                Assert.Equal(expectedRow.Losts, buildRow.Losts);
                int total = buildRow.Wins + buildRow.Draws + buildRow.Losts;
                Assert.Equal(expectedRow.PlayedGames, total);
            }
        }

        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForGeneralBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestTeamGoals(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.Equal(expectedRow.GoalsScored, buildRow.GoalsScored);
                Assert.Equal(expectedRow.GoalsLost, buildRow.GoalsLost);
            }
        }

        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForGeneralBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestTeamPositionAndTableOrder(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            int pos = 1;
            foreach(var row in buildTable)
            {
                Assert.Equal(pos++, row.Position);
            }
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.Equal(expectedRow.Position, buildRow.Position);
            }

        }
    }
}
