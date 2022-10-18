using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetCars()
        {
            var list = _carService.GetAll();
            if(list.Success)
            {
                return Ok(list);
            }

            return BadRequest(list);
        }

        [HttpGet("getallbybrand")]
        public IActionResult GetCarsByBrand(int brandId)
        {
            var list = _carService.GetCarsByBrandId(brandId);
            if(list.Success)
            {
                return Ok(list);
            }
            return BadRequest(list);
        }

        [HttpGet("getallbycolor")]
        public IActionResult GetCarsByColor(int colorId)
        {
            var list = _carService.GetCarsByColorId(colorId);
            if (list.Success)
            {
                return Ok(list);
            }
            return BadRequest(list);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarList()
        {
            var list = _carService.GetCarDetails();
            if(list.Success)
            {
                return Ok(list);
            }
            return BadRequest(list);
        }
    }
}
