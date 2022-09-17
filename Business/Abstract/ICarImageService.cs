using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int ImageId);
        IResult Add(IFormFile carFile, CarImage carImage);
        IResult Update(IFormFile carFile , CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
