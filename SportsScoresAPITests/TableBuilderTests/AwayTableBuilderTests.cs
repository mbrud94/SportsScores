using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Services.CompetitionTable;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TableBuilderTests.SportsScoresAPITests
{
    public class AwayTableBuilderTests : TableBuilderTestsBase
    {
        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForAwayBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestGeneralTableContent(IEnumerable<GameDTO> gameSet, IEnumerable<TableRowDTO> expectedTable)
        {
            var buildTable = new AwayTableBuilder().Build(gameSet);
            TestBuildTableContent(buildTable, expectedTable);
        }
    }
}
