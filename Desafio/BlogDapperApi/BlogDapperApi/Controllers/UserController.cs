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
        public async Task<IEnumerable<User>> Get(
            [FromServices] 
            IUserRepository repository
            )
        {
            var users = await repository.GetAll();
            return users;
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
            int id,
            [FromServices]
            IUserRepository repository,
            [FromBody] User user
            )
        {
            try
            {
                if(id != user.Id)
                {
                    throw new Exception("Identificadores diferentes");
                }

                await repository.Update(user);
                return Ok();
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

        [HttpGet("UserWithRoles/{id:int}")]
        public async Task<User> GetUserWithRoles(
            int id,
            [FromServices]
            IUserRepository repository
            )
        {
            var user = repository.GetUserWithRoles();
            return user;
        }
    }
}
