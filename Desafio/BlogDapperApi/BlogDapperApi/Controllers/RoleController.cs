using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Role>> GetAll(
            [FromServices]
            IRoleRepository repository
            )
        {
            return await repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Role>> GetById(
            int id,
            [FromServices]
            IRoleRepository repository
            )
        {
            try
            {
                if(id == 0)
                {
                    throw new Exception("Identificador inválido");
                }

                var role = await repository.GetById(id);

                return Ok(role);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(
            Role role,
            [FromServices]
            IRoleRepository repository
            )
        {
            try
            {
                if (role == null)
                {
                    throw new Exception("Objeto nulo");
                }

                await repository.Add(role);

                return Ok(role);

            }catch(Exception ex)
            {
                return BadRequest("Não foi possível cadastrar o objeto");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Role>> UpdateRole(
            Role role,
            [FromServices]
            IRoleRepository repository
            )
        {
            try
            {
                if (role == null)
                {
                    throw new Exception("Objeto inválido");
                }

                await repository.Update(role);

                return Ok(role);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(
            int id,
            [FromServices]
            IRoleRepository repository
            )
        {
            if (id == 0)
            {
                throw new Exception("Identificador inválido");
            }

            repository.Delete(id);
        }

    }
}
