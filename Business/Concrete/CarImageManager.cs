using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("admin")]
        public IResult Add(IFormFile carFile , CarImage carImage)
        {
            IResult result = BusinessRules.Run
                (CheckIfImageLimitExceeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var filePath = _fileHelper.Upload(carFile, PathConstants.CarImagePath);
            carImage.Date = DateTime.Now;
            carImage.ImagePath = filePath;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.CarImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == imageId));
        }

        public IResult Update(IFormFile carFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(carFile, PathConstants.CarImagePath + carImage.ImagePath, PathConstants.CarImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count() >= 5)
                return new ErrorResult(Messages.CarImageLimitExceeded);
            return new SuccessResult();
        }
    }
}
