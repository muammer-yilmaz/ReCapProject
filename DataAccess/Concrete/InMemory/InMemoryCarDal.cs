using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        public List<Car> cars;
        public InMemoryCarDal()
        {

        }
        public void Add(Car entity)
        {
            cars = new List<Car>()
            {
                new Car { CarId = 1,
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 300,
                    ModelYear = 2016,
                    Description = "smt"
                },
                new Car { CarId = 2,
                    BrandId = 2,
                    ColorId = 2,
                    DailyPrice = 400,
                    ModelYear = 2019,
                    Description = "smt2"
                },
                new Car { CarId = 3,
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 400,
                ModelYear = 2019,
                Description = "smt3"
                }
            };
        }
        public void Delete(Car entity)
        {
            var toDelete = cars.FirstOrDefault(x => x.CarId == entity.CarId);
        }

        public Car Get(int id)
        {
            return cars.Where(c => c.CarId == id).FirstOrDefault();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            var toUpdate = cars.SingleOrDefault(p => p.CarId == entity.CarId);

            toUpdate.BrandId = entity.BrandId;
            toUpdate.ColorId = entity.ColorId;
            toUpdate.DailyPrice = entity.DailyPrice;
            toUpdate.ModelYear = entity.ModelYear;
            toUpdate.Description = entity.Description;


        }
    }
}
