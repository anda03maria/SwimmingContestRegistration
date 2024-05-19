using System.Collections.Generic;
using SwimmingModel.contest;
using SwimmingModel.dto;

namespace SwimmingPersistence
{
    public interface IRacesRepository: IRepository<int, Race>
    {
        IList<Race> GetRacesByContestantId(int contestantId);

        IList<RaceInfo> GetRacesDetails();
    }
}