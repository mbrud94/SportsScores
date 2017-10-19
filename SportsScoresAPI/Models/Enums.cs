using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models
{
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
