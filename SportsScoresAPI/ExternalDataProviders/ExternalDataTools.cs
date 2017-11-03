using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.ExternalDataProviders
{
    public static class ExternalDataTools
    {
        public static string MapIdToFileName(int competitionId)
        {
            string fileName = string.Empty;
            switch(competitionId)
            {
                case TopLeauges.PremierLeague:
                    fileName = nameof(TopLeauges.PremierLeague);
                    break;
                case TopLeauges.Bundesliga:
                    fileName = nameof(TopLeauges.Bundesliga);
                    break;
                case TopLeauges.Ligue1:
                    fileName = nameof(TopLeauges.Ligue1);
                    break;
                case TopLeauges.PrimeraDivision:
                    fileName = nameof(TopLeauges.PrimeraDivision);
                    break;
                case TopLeauges.SerieA:
                    fileName = nameof(TopLeauges.SerieA);
                    break;
            }
            return fileName;
        }
    }

    public static class TopLeauges
    {
        public const int PremierLeague = 445;
        public const int SerieA = 456;
        public const int PrimeraDivision = 455;
        public const int Bundesliga = 452;
        public const int Ligue1 = 450;
    }
}
