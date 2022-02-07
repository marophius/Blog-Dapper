using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Blog_Dapper.Repositories {
    public class Repository<T> where T : class{
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection) => _connection = connection; 

        #region  CRUD
        public IEnumerable<T> get() => _connection.GetAll<T>();

        public T getById(int id) => _connection.Get<T>(id);

        public void Create(T entity) => _connection.Insert<T>(entity);

        public void Update(T entity) => _connection.Update<T>(entity);

        public void Delete(int id) {
            var entity = _connection.Get<T>(id);

            _connection.Delete<T>(entity);
        }


        #endregion
    }
}