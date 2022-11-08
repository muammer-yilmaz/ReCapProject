using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IPosService _posService;
        private readonly ICarService _carService;

        public RentalManager(IRentalDal rentalDal, IPosService posService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _posService = posService;
            _carService = carService;
        }

        //[SecuredOperation("admin,car.add")]
        public IResult Add(PaymentDto payment)
        {
            var result = BusinessRules.Run(IsRentable(payment.CarId));

            if (result is not null)
            {
                return result;
            }

            CreditCard card = new()
            {
                CardNumber = payment.CardNumber,
                ExpirationMonth = payment.ExpirationMonth,
                ExpirationYear = payment.ExpirationYear,
                Cvv = payment.Cvv
            };

            Rental rental = new()
            {
                CarId = payment.CarId,
                CustomerId = payment.CustomerId,
                RentDate = payment.RentDate,
                ReturnDate = payment.ReturnDate
            };

            var paymentResult = _posService.Pay(card, CalculatePayment(rental));
            if (paymentResult.Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return paymentResult;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }

        private IResult IsRentable(int carId)
        {
            var rental = _rentalDal.Get(r => r.CarId == carId);
            if (rental is null)
            {
                return new SuccessResult();
            }
            if (rental.ReturnDate < DateTime.Now)
            {
                return new SuccessResult();
            }
            return new ErrorResult(rental.ReturnDate.ToString() + " tarihine kadar " + Messages.AlreadyRented);
        }

        private decimal CalculatePayment(Rental rental)
        {
            var rentDays = (rental.ReturnDate - rental.RentDate);
            var dailyPrice = _carService.GetByCarId(rental.CarId).Data.DailyPrice;

            return dailyPrice * rentDays.Days;
        }
    }
}
