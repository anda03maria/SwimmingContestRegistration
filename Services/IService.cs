using System.Collections.Generic;
using Services;
using SwimmingModel.contest;
using SwimmingModel.dto;
using SwimmingModel.user;

namespace SwimmingServices
{
    public interface IService
    {
        void Login(Admin admin, IObserver client);

        void Logout(Admin admin, IObserver client);

        Race FindRace(int raceId);

        RaceInfo[] GetRacesInfo();

        ContestantInfo[] GetContestantsFromRace(int raceId, string nameText);

        void RegisterContestant(Contestant contestant, IList<int> raceIds);
    }
}