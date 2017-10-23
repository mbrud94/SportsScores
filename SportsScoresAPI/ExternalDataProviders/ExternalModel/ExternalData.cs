using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.ExternalDataProviders.ExternalModel
{
    public interface IExternalData
    {
    }

    public class ExternalData
    {
        public CompetitionExt Competition { get; set; }
    }

    public class Links
    {
        public LinkItem Teams { get; set; }
        public LinkItem Fixtures { get; set; }
        public LinkItem Players { get; set; }
        public LinkItem Self { get; set; }
        public LinkItem HomeTeam { get; set; }
        public LinkItem AwayTeam { get; set; }
        public LinkItem Competition { get; set; }
    }

    public class LinkItem
    {
        public string Href { get; set; }
    }

    public class CompetitionExt : IExternalData
    {
        public string Caption { get; set; }
        public Links _links { get; set; }

        public TeamsList Teams { get; set; }
        public FixturesList Fixtures { get; set; }

    }

    public class TeamsList : IExternalData
    {
        public List<TeamExt> Teams { get; set; }
        public Links _links { get; set; }
    }

    public class TeamExt
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string SquadMarketValue { get; set; }
        public string CrestUrl { get; set; }
        public Links _links { get; set; }

        public PlayersList Players { get; set; }
    }

    public class PlayersList : IExternalData
    {
        public List<PlayerExt> Players { get; set; }
        public Links _links { get; set; }
    }

    public class PlayerExt
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public string MarketValue { get; set; }
        public int? JerseyNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? ContractUntil { get; set; }

    }

    public class FixturesList : IExternalData
    {
        public List<FixutreExt> Fixtures { get; set; }
        public Links _links { get; set; }
    }

    public class FixutreExt
    {
        public Links _links { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Status { get; set; }
        public int? Matchday { get; set; }
        public DateTime? Date { get; set; }
        public ResultItem Result { get; set; }
    }

    public class ResultItem
    {
        public int? GoalsHomeTeam { get; set; }
        public int? GoalsAwayTeam { get; set; }
        public ResultItem HalfTime { get; set; }
    }

}
