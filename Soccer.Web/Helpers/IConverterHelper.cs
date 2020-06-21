using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soccer.Web.Models;
using Soccer.Web.Data.Entities;

namespace Soccer.Web.Helpers
{
    public interface IConverterHelper
    {
        TeamEntity ToTeamEntity(TeamViewModel model, string path, bool isNew);
        TeamViewModel ToTeamViewModel(TeamEntity teamEntity);
        TournamentEntity ToTournamentEntity(TournamentViewModel model, string path, bool isNew);
        TournamentViewModel ToTournamentViewModel(TournamentEntity tournamentEntity);
    }
}
