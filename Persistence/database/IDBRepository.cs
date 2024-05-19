using System.Data;
using SwimmingModel;

namespace SwimmingPersistence.database
{
    public interface IDBRepository<ID, E> where E : Entity<ID>
    {
        E extractEntity(IDataReader dataR);
    }
}