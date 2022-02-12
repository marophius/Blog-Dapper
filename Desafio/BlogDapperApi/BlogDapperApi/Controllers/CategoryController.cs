using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll(
            [FromServices]
            ICategoryRepository repository
            )
        {
            try
            {
                var categories = await repository.GetAll();
                if(categories == null)
                {
                    throw new Exception("Nenhuma categoria cadastrada");
                }

                return Ok(categories);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> Get(
            int id,
            [FromServices]
            ICategoryRepository repository
            )
        {
            try
            {
                if(id == 0)
                {
                    throw new Exception("Identificador inválido");
                }

                var category = await repository.GetById(id);

                return Ok(category);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(
            Category category,
            [FromServices]
            ICategoryRepository repository
            )
        {
            try
            {
                if(category == null)
                {
                    throw new Exception("Objeto inválido");
                }

                await repository.Add(category);
                return Ok(category);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(
            Category category,
            [FromServices]
            ICategoryRepository repository
            )
        {
            try
            {
                if(category == null)
                {
                    throw new Exception("Objeto inválido");
                }

                await repository.Update(category);
                return Ok(category);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(
            int id,
            [FromServices]
            ICategoryRepository repository
            )
        {
            if(id == 0)
            {
                throw new Exception("Identificador inválido");
            }

            repository.Delete(id);
        }
    }
}
