using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class CarManager : ICarService
    {
        public ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        public IResult Add(Car car)
        {
            if (IsCarNameLenghtValid(car.CarName) || IsDailyPriceValid(car.DailyPrice))
            {
                return new ErrorResult();
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var carList = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(carList,Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));

        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        private bool IsCarNameLenghtValid(string name)
        {
            if(name.Length < 2)
                return true;
            
            return false;
        }

        private bool IsDailyPriceValid(decimal price)
        {
            if(price < 0 || price == 0)
                return true;

            return false;
        }
    }
}
