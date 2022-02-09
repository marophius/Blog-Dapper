namespace BlogDapperApi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        #region CRUD
        Task Add(T entity);
        void Delete(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);

        #endregion
    }
}
