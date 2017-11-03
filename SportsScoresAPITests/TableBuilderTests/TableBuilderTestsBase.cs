using SportsScoresAPI.Services.CompetitionTable;
using System;
using Xunit;
using System.Linq;
using SportsScoresAPI.Models.DTO;
using System.Collections.Generic;

namespace TableBuilderTests.SportsScoresAPITests
{
    public abstract class TableBuilderTestsBase
    {

        protected void TestBuildTableContent(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            TestTableStructure(buildTable, expectedTable);
            TestTeamsGames(buildTable, expectedTable);
            TestTeamsGoals(buildTable, expectedTable);
            TestTeamsPoints(buildTable, expectedTable);
            TestTeamsPositionAndTableOrder(buildTable, expectedTable);
        }

        private void TestTableStructure(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            Assert.Equal(expectedTable.Count(), buildTable.Count());
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.NotNull(buildRow);
                Assert.Equal(1, buildTable.Count(r => r.TeamName == expectedRow.TeamName));
            }
        }

        private void TestTeamsPoints(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.Equal(expectedRow.Points, buildRow.Points);
            }
        }

        private void TestTeamsGames(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
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

        private void TestTeamsGoals(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
        {
            foreach (var expectedRow in expectedTable)
            {
                var buildRow = buildTable.FirstOrDefault(r => r.TeamName == expectedRow.TeamName);
                Assert.Equal(expectedRow.GoalsScored, buildRow.GoalsScored);
                Assert.Equal(expectedRow.GoalsLost, buildRow.GoalsLost);
            }
        }

        private void TestTeamsPositionAndTableOrder(IEnumerable<TableRowDTO> buildTable, IEnumerable<TableRowDTO> expectedTable)
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
