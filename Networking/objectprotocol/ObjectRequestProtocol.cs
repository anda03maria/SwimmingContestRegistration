using System;
using SwimmingNetworking.dto;

namespace SwimmingNetworking.objectprotocol
{
    public interface Request
    {
        
    }

    [Serializable]
    public class AddContestantRequest : Request
    {
        private ContestantDTO contestant;

        public AddContestantRequest(ContestantDTO contestant)
        {
            this.contestant = contestant;
        }

        public virtual ContestantDTO Contestant
        {
            get
            {
                return contestant;
            }
        }
    }

    [Serializable]
    public class GetContestantsByRaceIdAndNameRequest : Request
    {
        private int raceId;
        private string nameText;

        public GetContestantsByRaceIdAndNameRequest(int raceId, string nameText)
        {
            this.raceId = raceId;
            this.nameText = nameText;
        }

        public virtual int RaceId
        {
            get
            {
                return raceId;
            }
        }

        public virtual string NameText
        {
            get
            {
                return nameText;
            }
        }
    }

    [Serializable]
    public class GetRaceByIdRequest : Request
    {
        private int raceId;

        public GetRaceByIdRequest(int raceId)
        {
            this.raceId = raceId;
        }

        public virtual int RaceId
        {
            get
            {
                return raceId;
            }
        }
    }

    [Serializable]
    public class GetRacesInfoRequest : Request
    {
        public GetRacesInfoRequest()
        {
            
        }
    }
    
    [Serializable]
    public class LoginRequest : Request
    {
        private AdminDTO admin;

        public LoginRequest(AdminDTO admin)
        {
            this.admin = admin;
        }

        public virtual AdminDTO Admin
        {
            get
            {
                return admin;
            }
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private AdminDTO admin;

        public LogoutRequest(AdminDTO admin)
        {
            this.admin = admin;
        }
        
        public virtual AdminDTO Admin
        {
            get
            {
                return admin;
            }
        }
    }
    
    
}