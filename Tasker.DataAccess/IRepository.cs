using System.Collections.Generic;

namespace Tasker.DataAccess
{
    public interface IRepository<T>
    {
        T Add(T record);
        IEnumerable<T> GetAll();
        void Update(T record);
    }
}
