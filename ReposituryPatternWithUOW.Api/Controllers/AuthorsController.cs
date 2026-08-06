using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReposituryPatternWithUOW.Core;
using ReposituryPatternWithUOW.Core.Interfaces;
using ReposituryPatternWithUOW.Core.Models;

namespace ReposituryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authors);
        }


        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(1));
        }
    }
}
