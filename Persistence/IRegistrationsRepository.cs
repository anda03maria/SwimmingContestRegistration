
using SwimmingModel.contest;

namespace SwimmingPersistence
{
    public interface IRegistrationsRepository: IRepository<int, Registration>
    {
        Registration FindRegistrationByPairIds(int contestantId, int raceId);
    }
    
    
}