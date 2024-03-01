using ComputerShopApi.Data;
using ComputerShopApi.Errors;
using ComputerShopApi.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetProductController : ControllerBase
    {
        private readonly DbHelper _db;

        public SetProductController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }
        [HttpGet]
        [Route("api/[controller]/GetSetProduct")]
        public IActionResult GetAll()
        {
            try
            {
                ResponseType type = ResponseType.Success;
                List<SetProductResponse> deviceResponse = _db.GetSetProduct();
                return Ok(deviceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
