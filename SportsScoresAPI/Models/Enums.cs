using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models
{
    public enum Nationality //TODO: expand
    {
        England = 0,
        Poland = 1,
        Germany = 2,
        Spain = 3,
        Italy = 4
    }

    public enum Position //TODO: expand
    {
        Keaper = 0,
        LeftBack = 1,
        CentreBack = 2,
        RightBack = 3

    }

    public enum GameEventType
    {
        Goal,
        Assist,
        YellowCard,
        RedCard,
        PlayerIn,
        PlayerOut
    }

    public enum GameStatus
    {
        Finished,
        Scheduled,
        InProgress
    }
}
