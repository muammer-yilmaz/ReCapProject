
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICarService carService = new CarManager(new EfCarDal());

            //addCar(carService);

            //getAll(carService);
        }

        private static void addCar(ICarService carService)
        {
            Car a = new Car()
            {
                BrandId = 1,
                ColorId = 1,
                CarName = "First Car",
                DailyPrice = 250,
                ModelYear = 2015,
                Description = "ABC"
            };

            carService.Add(a);
        }

        private static void getAll(ICarService carService)
        {
            foreach (var item in carService.GetAll().Data)
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}
