using System;

namespace SwimmingModel.contest{
    
    public class Registration : Entity<int>
    {
        public int ContestantId { get; set; }
        public int RaceId { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public Registration(int id) : base(id)
        {
        }

        public Registration(int id, int contestantId, int raceId, DateTime registrationDate) : base(id)
        {
            ContestantId = contestantId;
            RaceId = raceId;
            RegistrationDate = registrationDate;
        }
        
        public Registration(int contestantId, int raceId, DateTime registrationDate) : base()
        {
            ContestantId = contestantId;
            RaceId = raceId;
            RegistrationDate = registrationDate;
        }

        public Registration(int contestantId, int raceId) : base()
        {
            ContestantId = contestantId;
            RaceId = raceId;
            RegistrationDate = DateTime.Today;
        }
        
        public string ToString()
        {
            return String.Format("{0} {1} {2}", ContestantId, RaceId, RegistrationDate.ToString());
        }
    }
}