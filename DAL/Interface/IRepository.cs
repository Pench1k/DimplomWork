namespace DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>>? GetAll();
        Task<T>? Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
