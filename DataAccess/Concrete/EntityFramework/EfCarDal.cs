using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext> , ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
                             
            }
        }

        public List<CarListItemDto> GetCarList()
        {
            using ReCapContext context = new ReCapContext();

            var result = from c in context.Cars
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         join cl in context.Colors
                         on c.ColorId equals cl.ColorId
                         select new CarListItemDto
                         {
                             CarId = c.CarId,
                             BrandName = b.BrandName,
                             ColorName = cl.ColorName,
                             CarName = c.CarName,
                             DailyPrice = c.DailyPrice,
                             CarImage = (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).FirstOrDefault() ?? "no-image.png"
                         };
            result.Where((Expression<Func<CarListItemDto, int, bool>>)filter);
            return result.ToList();
        }
    }
}
