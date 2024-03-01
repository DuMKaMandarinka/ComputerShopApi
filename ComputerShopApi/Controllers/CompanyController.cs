using ComputerShopApi.Data;
using ComputerShopApi.DTO;
using ComputerShopApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DbHelper _db;

        public CompanyController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }

        [HttpPost]
        [Route("api/[controller]/CreateType")]
        public IActionResult Post([FromBody] CompanyDTO companyDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateCompany(companyDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
