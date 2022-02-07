using Blog_Dapper.Models;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Blog_Dapper.Repositories {
    public class RoleRepository {

        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) {
            this._connection = connection;
        }

        #region  CRUD
        public IEnumerable<Role> get() => _connection.GetAll<Role>();

        public Role getById(int id) => _connection.Get<Role>(id);

        public void Create(Role role) => _connection.Insert<Role>(role);

        public void Update(int id, Role role)
        {
            if(id != 0) 
            {
                _connection.Update<Role>(role);
            }
            
        }

        public void Delete(int id) {
            if(id != 0) {
                return;
            }
            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        } 



        #endregion


    }
}