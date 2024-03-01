using ComputerShopApi.Data;
using ComputerShopApi.DTO;
using ComputerShopApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly DbHelper _db;

        public BranchController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }

        [HttpPost]
        [Route("api/[controller]/CreateType")]
        public IActionResult Post([FromBody] BranchDTO branchDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateBranch(branchDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/CreateBranchProduct")]
        public IActionResult CreateBranchProduct([FromBody] DistributionDTO branchDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DistributionProduct(branchDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
