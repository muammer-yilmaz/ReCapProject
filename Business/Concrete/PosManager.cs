using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PosManager : IPosService
    {
        private readonly ICreditCardService _creditCardService;

        public PosManager(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        public IResult Pay(CreditCard card, decimal payment)
        {
            var result = _creditCardService.VerifyPayment(card, payment);
            return result;
        }
    }
}
