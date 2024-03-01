using ComputerShopApi.Data;
using ComputerShopApi.DTO;
using ComputerShopApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class BrandController : ControllerBase
    //{
    //    private readonly DbHelper _db;

    //    public BrandController(ApiDbContext apiDbContext)
    //    {
    //        _db = new DbHelper(apiDbContext);
    //    }

    //    [HttpPost]
    //    [Route("api/[controller]/CreateBrand")]
    //    public IActionResult Post([FromBody] BrandTypeDTO brandDto)
    //    {
    //        try
    //        {
    //            ResponseType type = ResponseType.Success;
    //            _db.CreateBrand(brandDto);
    //            return StatusCode(StatusCodes.Status201Created);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ResponseHandler.GetExceptionResponse(ex));
    //        }
    //    }
    //}
}
