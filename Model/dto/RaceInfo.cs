using System;
using SwimmingModel.contest;


namespace SwimmingModel.dto
{
    public class RaceInfo
    {
        public int RaceId { get; set; }
        public int Distance { get; set; }
        public SwimmingStyle Style { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfContestants { get; set; }

        public RaceInfo(int raceId, int distance,  DateTime date, SwimmingStyle style, int numberOfContestants)
        {
            RaceId = raceId;
            Distance = distance;
            Style = style;
            Date = date;
            NumberOfContestants = numberOfContestants;
        }
    }
}