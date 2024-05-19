using System.Collections.Generic;
using SwimmingModel.contest;
using SwimmingModel.dto;
using SwimmingModel.user;

namespace SwimmingNetworking.dto
{
    public class DTOUtils
    {
        public static Admin GetFromDTO(AdminDTO adminDto)
        {
            return new Admin(adminDto.Id, adminDto.Password);
        }

        public static AdminDTO GetDTO(Admin admin)
        {
            return new AdminDTO(admin.Id, admin.Password);
        }

        public static RaceInfo GetFromDTO(RaceInfoDTO raceInfoDto)
        {
            return new RaceInfo(raceInfoDto.Id, raceInfoDto.Distance, raceInfoDto.Date,
                raceInfoDto.Style, raceInfoDto.NumberOfContestants);
        }

        public static RaceInfoDTO GetDTO(RaceInfo raceInfo)
        {
            return new RaceInfoDTO(raceInfo.RaceId, raceInfo.Distance, raceInfo.Style,
                raceInfo.Date, raceInfo.NumberOfContestants);
        }

        public static Race GetFromDTO(RaceDTO raceDto)
        {
            return new Race(raceDto.Id);
        }

        public static RaceDTO GetDTO(Race race)
        {
            return new RaceDTO(race.Id);
        }

        public static RaceInfo[] GetFromDTO(RaceInfoDTO[] raceInfoDtos)
        {
            RaceInfo[] races = new RaceInfo[raceInfoDtos.Length];
            for (int i = 0; i < races.Length; i++)
            {
                races[i] = GetFromDTO(raceInfoDtos[i]);
            }

            return races;
        }

        public static RaceInfoDTO[] GetDTO(RaceInfo[] races)
        {
            RaceInfoDTO[] raceInfoDtos = new RaceInfoDTO[races.Length];
            for (int i = 0; i < raceInfoDtos.Length; i++)
            {
                raceInfoDtos[i] = GetDTO(races[i]);
            }

            return raceInfoDtos;
        }

        public static ContestantInfoDTO GetDTO(ContestantInfo contestantInfo)
        {
            return new ContestantInfoDTO(contestantInfo.Name, contestantInfo.BirthDate, contestantInfo.RacesIDs);
        }

        public static ContestantInfo GetFromDTO(ContestantInfoDTO contestantInfoDto)
        {
            IList<int> ids = new List<int>();
            for (int i = 0; i < contestantInfoDto.RaceIds.Length; i++)
            {
                ids.Add(contestantInfoDto.RaceIds[i]);
            }

            return new ContestantInfo(contestantInfoDto.Name, contestantInfoDto.BirthDate, ids);
        }

        public static ContestantInfoDTO[] GetDTO(ContestantInfo[] contestants)
        {
            ContestantInfoDTO[] contestantInfoDtos = new ContestantInfoDTO[contestants.Length];
            for (int i = 0; i < contestantInfoDtos.Length; i++)
            {
                contestantInfoDtos[i] = GetDTO(contestants[i]);
            }

            return contestantInfoDtos;
        }

        public static ContestantInfo[] GetFromDTO(ContestantInfoDTO[] contestantInfoDtos)
        {
            ContestantInfo[] contestantInfos = new ContestantInfo[contestantInfoDtos.Length];
            for (int i = 0; i < contestantInfoDtos.Length; i++)
            {
                contestantInfos[i] = GetFromDTO(contestantInfoDtos[i]);
            }

            return contestantInfos;
        }
    }
}