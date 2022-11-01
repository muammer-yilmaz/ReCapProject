using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
        public IResult Add(Rental rental, CreditCard card)
        {
            var result = BusinessRules.Run(IsRentable(rental.CarId));

            if (result is not null)
            {
                return result;
            }
            var paymentResult = _posService.Pay(card, CalculatePayment(rental));
            if (paymentResult)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult();
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
            if (_rentalDal.Get(r => r.CarId == carId) != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private decimal CalculatePayment(Rental rental)
        {
            var rentDays = (rental.ReturnDate - rental.RentDate);
            var dailyPrice = _carService.GetByCarId(rental.CarId).Data.DailyPrice;

            return dailyPrice * rentDays.Days;
        }
    }
}
