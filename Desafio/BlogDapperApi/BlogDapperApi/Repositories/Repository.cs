using BlogDapperApi.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogDapperApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection) => _connection = connection;

        #region CRUD
        public Task Add(T entity) => _connection.InsertAsync<T>(entity);

        public void Delete(int id)
        {
            var entity = _connection.Get<T>(id);
            _connection.Delete<T>(entity);
        }

        public Task<IEnumerable<T>> GetAll() => _connection.GetAllAsync<T>();

        public Task<T> GetById(int id) => _connection.GetAsync<T>(id);

        public Task Update(T entity) => _connection.UpdateAsync<T>(entity);

        #endregion
    }
}
