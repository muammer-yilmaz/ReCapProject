using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult Update(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        public IResult VerifyPayment(CreditCard creditCard, decimal payment)
        {
            var result = Verify(creditCard, payment);

            return result;
        }

        private IResult Verify(CreditCard creditCard, decimal payment)
        {
            var result = _creditCardDal.MatchCard(creditCard);
            if (result is null)
            {
                return new ErrorResult(Messages.CardNotFound);
            }
            if (result.Balance < payment)
            {
                return new ErrorResult(Messages.BalanceInsufficient);
            }
            _creditCardDal.UpdateBalance(result.Id, result.Balance - payment);
            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
