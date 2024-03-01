using ComputerShopApi.Data;
using ComputerShopApi.DTO;
using ComputerShopApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly DbHelper _db;

        public TypeController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }

        [HttpPost]
        [Route("api/[controller]/CreateType")]
        public IActionResult Post([FromBody] BrandTypeDTO typeDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateType(typeDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateType")]
        public IActionResult Update(int id,string Name)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateType(id,Name);
                return Ok(new { message = "Type updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteType")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteType(id);
                return Ok(new { message = "Type deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
