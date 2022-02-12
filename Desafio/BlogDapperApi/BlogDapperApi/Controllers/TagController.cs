using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public TagController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAll(
            [FromServices]
            ITagRepository repository
            )
        {
            try
            {
                var tags = await repository.GetAll();

                if(tags == null)
                {
                    throw new Exception("nenhuma tag cadastrada");
                }else
                {
                    foreach (var tag in tags)
                    {
                        Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
                    }
                }

                return Ok(tags);

            }
            catch  (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tag>> GetById(
            int id,
            [FromServices]
            ITagRepository repository
            )
        {
            try
            {
                if(id == 0)
                {
                    throw new Exception("Identificador não válido");
                }

                var user = await repository.GetById(id);

                return Ok(user);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> AddTag(
            [FromBody]
            Tag tag,
            [FromServices]
            ITagRepository repository
            )
        {
            try
            {
                if (tag == null)
                {
                    throw new Exception("Objeto nulo");
                }

                await repository.Add(tag);
                return Ok(tag);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Tag>> UpdateTag(
            Tag tag,
            [FromServices]
            ITagRepository repository
            )
        {
            try
            {
                if(tag == null)
                {
                    throw new Exception("Objeto nulo");
                }

                await repository.Update(tag);

                return Ok(tag);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public void DeleteTag(
            int id,
            [FromServices]
            ITagRepository repository
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
