using ComputerShopApi.Data;
using ComputerShopApi.DTO;
using ComputerShopApi.Errors;
using ComputerShopApi.Models;
using ComputerShopApi.Response;
using ComputerShopApi.WorkLogics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ComputerShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbHelper _db;

        public ProductController(ApiDbContext apiDbContext)
        {
            _db = new DbHelper(apiDbContext);
        }

        [HttpPost]
        [Route("api/[controller]/CreateProduct")]
        public async Task<IActionResult> Post([FromForm] ProductDTO productDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                await _db.CreateProduct(productDto);
                return StatusCode(StatusCodes.Status201Created);
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
                _db.DeleteProduct(id);
                return Ok(new { message = "Product deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/GetVariantSetProduct")]
        public IActionResult Post([FromBody] SoloSetProduct soloSetProduct)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                List<List<DeviceResponse>> deviceResponse = _db.GetSoloSetProduct(soloSetProduct);
                return Ok(deviceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }






        //[HttpGet]
        //public async Task<IEnumerable<Product>> Get()
        //{
        //    return await _context.Products.ToListAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(Product product)
        //{
        //    _context.Add(product);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}
    }
}
