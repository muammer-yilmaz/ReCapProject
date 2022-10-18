using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            this.carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile image,[FromForm] CarImage carImage)
        {
            var result =  carImageService.Add(image, carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile image, [FromForm] CarImage carImage)
        {
            var imageToUpdate = carImageService.GetById(carImage.ImageId).Data;
            var result = carImageService.Update(image, imageToUpdate);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var imageToDelete = carImageService.GetById(carImage.ImageId).Data;
            var result = carImageService.Delete(imageToDelete);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcarimages")]
        public IActionResult GetCarImages(int carId)
        {
            var result= carImageService.GetAllByCarId(carId);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
