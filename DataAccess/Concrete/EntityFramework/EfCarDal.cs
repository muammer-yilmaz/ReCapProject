using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using ReCapContext context = new ReCapContext();

            var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         join cl in context.Colors
                         on c.ColorId equals cl.ColorId
                         select new CarDetailDto
                         {
                             CarId = c.CarId,
                             BrandName = b.BrandName,
                             ColorName = cl.ColorName,
                             CarName = c.CarName,
                             ModelYear = c.ModelYear,
                             DailyPrice = c.DailyPrice,
                             CarImage = (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).FirstOrDefault() ?? "no-image.png",
                             IsRentable = !(from r in context.Rentals where r.CarId == c.CarId select c.CarName).Any()
                         };
            return result.ToList();

        }
    }
}
