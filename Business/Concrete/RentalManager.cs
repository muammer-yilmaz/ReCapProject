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

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[SecuredOperation("admin,car.add")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsRentable(rental.CarId));

            if(!result.Success)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
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
            if(_rentalDal.Get(r => r.CarId == carId) == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
