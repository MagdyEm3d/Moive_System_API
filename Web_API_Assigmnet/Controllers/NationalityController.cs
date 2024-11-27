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
    public class NationalityController : ControllerBase
    {
       
        private readonly INationalityReposatory _repo;

        public NationalityController(INationalityReposatory repo)
        {
            _repo = repo;
        }
        [HttpPost("AddNationality")]
        public IActionResult AddNationality(NationalityDTO nationalitydto)
        {

            try
            {
                bool isadd = _repo.Add(nationalitydto);
                if (!isadd)
                    return BadRequest("Nationaly Already Exist");
                return Accepted();
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }


        }

        [HttpDelete("DeleteNationality")]
        public IActionResult DeleteNationality(int id)
        {
            try
            {
                bool isdelete=_repo.Delete(id); 
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
