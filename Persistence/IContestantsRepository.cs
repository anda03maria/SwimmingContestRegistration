using System.Collections;
using System.Collections.Generic;
using SwimmingModel.user;

namespace SwimmingPersistence
{
    public interface IContestantsRepository: IRepository<int, Contestant>
    {
        int GetNumberOfContestantsFromRace(int raceId);

        IList<Contestant> GetContestantsFromRace(int raceId);

        IList<Contestant> GetContestantsFromRaceAndName(int raceId, string searchText);
        
        Contestant GetLastContestantInserted();
    }
}