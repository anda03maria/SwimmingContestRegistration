using System;
using System.Runtime.CompilerServices;
using SwimmingNetworking.dto;

namespace SwimmingNetworking.objectprotocol
{
    public interface Response
    {
        
    }

    [Serializable]
    public class OKResponse : Response
    {
        
    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

    [Serializable]
    public class GetContestantsByRaceIdAndNameResponse : Response
    {
        private ContestantInfoDTO[] contestants;

        public GetContestantsByRaceIdAndNameResponse(ContestantInfoDTO[] contestants)
        {
            this.contestants = contestants;
        }

        public virtual ContestantInfoDTO[] Contestants
        {
            get
            {
                return contestants;
            }
        }
    }

    [Serializable]
    public class GetRaceByIdResponse : Response
    {
        private RaceDTO race;

        public GetRaceByIdResponse(RaceDTO race)
        {
            this.race = race;
        }

        public virtual RaceDTO Race
        {
            get
            {
                return race;
            }
        }
    }

    [Serializable]
    public class GetRacesInfoResponse : Response
    {
        private RaceInfoDTO[] races;

        public GetRacesInfoResponse(RaceInfoDTO[] races)
        {
            this.races = races;
        }

        public virtual RaceInfoDTO[] Races
        {
            get
            {
                return races;
            }
        }
    }
    
    public interface UpdateResponse : Response
    {
        
    }
    
    
    [Serializable]
    public class AddedContestantResponse : UpdateResponse
    {
        
    }
    
}