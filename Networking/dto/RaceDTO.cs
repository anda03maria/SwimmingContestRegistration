using System;

namespace SwimmingNetworking.dto
{
    [Serializable]
    public class RaceDTO
    {
        public int Id { get; }

        public RaceDTO(int id)
        {
            Id = id;
        }
    }
}