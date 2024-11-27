using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.DTOS;
using Web_API_Assigmnet.Models;
using Web_API_Assigmnet.Reposatoty;

namespace Web_API_Assigmnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoiveController : ControllerBase
    {
        
        private IMoiveReposatory _repo;

        public MoiveController(IMoiveReposatory repo)
        {
            
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            try
            {
                var all = _repo.GetAll();
                return Ok(all);

            }catch(Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }
 
        }

        [HttpGet("GetMoive")]
        public IActionResult GetMoive(int id)
        {
            var existmoive=_repo.GetMoive(id);
            if(existmoive==null)
                return NotFound();
            return Ok(existmoive);  
        }


        [HttpPost("AddAll")]
        public IActionResult AddAll(MoiveDTO moivedto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool isadd=_repo.AddAll(moivedto);
                if(!isadd) return NotFound();
                return Created();

            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in {ex.Message}");
            }

        }
    }
}
