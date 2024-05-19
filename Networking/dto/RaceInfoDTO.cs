using System;
using SwimmingModel.contest;

namespace SwimmingNetworking.dto
{
    [Serializable]
    public class RaceInfoDTO
    {
        public int Id { get; }
        public int Distance { get; }
        public SwimmingStyle Style { get; }
        public DateTime Date { get; }
        public int NumberOfContestants { get; }

        public RaceInfoDTO(int id, int distance, SwimmingStyle style, DateTime date, int numberOfContestants)
        {
            Id = id;
            Distance = distance;
            Style = style;
            Date = date;
            NumberOfContestants = numberOfContestants;
        }
    }
}