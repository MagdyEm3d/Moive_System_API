using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.DTOS;
using Web_API_Assigmnet.Models;
using Web_API_Assigmnet.Reposatoty;

namespace Web_API_Assigmnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        private readonly ICategoryReposatory _repo;

        public CategoryController(ICategoryReposatory repo)
        {
             _repo = repo;
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CategoryDTO categorydto)
        {
            try
            {
                bool isadd = _repo.Add(categorydto);
                if (!isadd)
                    return BadRequest("Category Already Exist");
                return Created();
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }


        }

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                bool isdelete= _repo.Delete(id);    
                if(!isdelete)   
                    return NotFound();
                return NoContent();

            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }

        }


    }
}
