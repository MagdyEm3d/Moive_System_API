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
    public class DirectorController : ControllerBase
    {
        
        private readonly IDirectorReposatory _repo;

        public DirectorController(IDirectorReposatory repo)
        {
            _repo = repo;
        }
        [HttpPost("AddAll")]
        public IActionResult AddAll(DirectorrDTO directorrdto)
        {


            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool isadd = _repo.AddAll(directorrdto);
                if (!isadd)
                    return BadRequest("Director or Moive or Category Already Exist");
                return Created();

            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }


        }

        [HttpPut("UpateAll")]
        public IActionResult UpdateAll(int id, DirectorrDTO directorrdto)
        {
            try
            {
                bool isupdate=_repo.UpdateAll(id, directorrdto);
                if(!isupdate)   
                    return BadRequest("Director Id is not found or Moive is Already Exist");
                return Accepted();

            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }


        }
        [HttpDelete("DeleteDirector")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                bool isdelete = _repo.Delete(id);
                if (!isdelete)
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
