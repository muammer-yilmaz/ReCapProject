using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetBrands()
        {
            var list = _brandService.GetAll();

            if (list.Success)
            {
                return Ok(list);
            }

            return BadRequest(list);
        }
    }
}
