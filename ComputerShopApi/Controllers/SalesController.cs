using ComputerShopApi.Data;
using ComputerShopApi.DTO;
using ComputerShopApi.Errors;
using ComputerShopApi.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly DbHelper _db;

        public SalesController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }

        [HttpPost]
        [Route("api/[controller]/CreateSales")]
        public IActionResult Post([FromBody] SalesDto saleDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateSales(saleDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/MakeSale")]
        public IActionResult CreateSales([FromForm] MakeSalesDTO makeSalesDTO)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.MakeSales(makeSalesDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateSale")]
        public IActionResult UpdateSales(int id,int amount)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateSales(id,amount);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetMostSales")]
        public IActionResult GetMostSales()
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var response = _db.GetMostPopularProducts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetInformation")]
        public IActionResult GetInformation(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var response = _db.GetInformation(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
