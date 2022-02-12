using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(
            [FromServices] 
            IUserRepository repository
            )
        {
            try
            {
                var users = await repository.GetAll();
                if(users == null)
                {
                    throw new Exception("Nenhum usuário cadastrado");
                }

                return Ok(users);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<User> GetById(
            int id,
            [FromServices]
            IUserRepository repository
            )
        {
            var user = await repository.GetById(id);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(
            User user,
            [FromServices]
            IUserRepository repository
            )
        {
            try
            {
                if(user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                await repository.Add(user);

                return Ok(user);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> Update(
            [FromServices]
            IUserRepository repository,
            [FromBody] User user
            )
        {
            try
            {
                if(user == null)
                {
                    throw new Exception("Objeto inválido");
                }

                await repository.Update(user);
                return Ok(user);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(
            int id,
            [FromServices]
            IUserRepository repository
            )
        {
            if(id == 0)
            {
                throw new Exception("Identificador inválido");
            }

            repository.Delete(id);
        }

        [HttpGet("UserRoles")]
        public async Task<List<User>> GetUsersWithRoles(
            [FromServices]
            IUserRepository repository
            )
        {
            return await repository.GetUsersWithRoles();
            
        }
    }
}
