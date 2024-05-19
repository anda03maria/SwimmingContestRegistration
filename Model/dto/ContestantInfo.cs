using System;
using System.Collections.Generic;
using SwimmingModel.contest;


namespace SwimmingModel.dto
{
    public class ContestantInfo
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IList<int> RacesIDs { get; set; }

        public ContestantInfo(string name, DateTime birthDate, IList<int> races)
        {
            Name = name;
            BirthDate = birthDate;
            RacesIDs = new List<int>();
            foreach (var id in races)
            {
                RacesIDs.Add(id);
            }
        }

        public string textRaceIds
        {
            get
            {
                string text = "";
                foreach (var id in RacesIDs)
                {
                    text += id.ToString() + " ";
                }

                return text;
            }
        }
    }
}