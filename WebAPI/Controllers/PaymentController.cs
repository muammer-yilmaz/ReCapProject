using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public PaymentController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost]
        public IActionResult AddCard(CreditCard card)
        {
            var result = _creditCardService.Add(card);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
