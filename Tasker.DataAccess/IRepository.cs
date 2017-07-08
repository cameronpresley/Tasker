namespace Tasker.DataAccess
{
    public interface IRepository<T>
    {
        T Add(T record);
    }
}
