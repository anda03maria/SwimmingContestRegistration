using System;
using System.Collections.Generic;

namespace SwimmingNetworking.dto
{
    [Serializable]
    public class ContestantInfoDTO
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public int[] RaceIds { get; }

        public ContestantInfoDTO(string name, DateTime birthDate, IList<int> raceIds)
        {
            Name = name;
            BirthDate = birthDate;
            RaceIds = new int[raceIds.Count];
            for (int i = 0; i < RaceIds.Length; i++)
            {
                RaceIds[i] = raceIds[i];
            }
        }
    }
}