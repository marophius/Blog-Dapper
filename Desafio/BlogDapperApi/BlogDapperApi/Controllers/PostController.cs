using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll(
            [FromServices]
            IPostRepository repository
            )
        {
            try
            {
                var posts = await repository.GetAll();
                if(posts == null)
                {
                    throw new Exception("Não há posts cadastrados");
                }

                return Ok(posts);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> GetById(
            int id,
            [FromServices]
            IPostRepository repository
            )
        {
            try
            {
                if(id == 0)
                {
                    throw new Exception("Identificador inválido");
                }

                var user = await repository.GetById(id);
                return Ok(user);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(
            Post post,
            [FromServices]
            IPostRepository repository
            )
        {
            try
            {
                if (post == null)
                {
                    throw new Exception("Objeto inválido");
                }

                await repository.Add(post);
                return Ok(post);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Post>> UpdatePost(
            Post post,
            [FromServices]
            IPostRepository repository
            )
        {
            try
            {
                if(post == null)
                {
                    throw new Exception("Objeto inválido");
                }

                await repository.Update(post);
                return Ok(post);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public void DeletePost(
            int id,
            [FromServices]
            IPostRepository repository
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
