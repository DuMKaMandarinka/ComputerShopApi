using ComputerShopApi.Data;
using ComputerShopApi.Errors;
using ComputerShopApi.Models;
using ComputerShopApi.Response;
using ComputerShopApi.WorkLogics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DbHelper _db;

        public DeviceController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }
        [HttpGet]
        [Route("api/[controller]/CreateProduct")]
        public IActionResult GetAll()
        {
            try
            {
                ResponseType type = ResponseType.Success;
                List<DeviceResponse> deviceResponse = _db.GetDevices();
                return Ok(deviceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
