using System.Collections.Generic;
using SwimmingModel;


namespace SwimmingPersistence
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);

        IList<E> FindAll();

        bool Save(E entity);

        E Delete(ID id);

        bool Update(E entity);
    }
}