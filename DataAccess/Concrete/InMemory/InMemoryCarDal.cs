using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
                                                              // 1=Mercedes     //1-Kırmızı
                                                              // 2=Bmw          //2-Mavi
                                                              // 3=Audi         //3-Siyah
                                                              // 4=Toyota       //4-Beyaz
                                                              // 5=Renault
        public InMemoryCarDal(List<Car> cars)                    //İnjection
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=3,DailyPrice=400,Description="Sport",ModelYear=2006},
                new Car{CarId=2,BrandId=2,ColorId=3,DailyPrice=500,Description="Daily",ModelYear=2002},
                new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=350,Description="Sport",ModelYear=20010},
                new Car{CarId=4,BrandId=4,ColorId=3,DailyPrice=200,Description="Sport",ModelYear=2018},
                new Car{CarId=5,BrandId=5,ColorId=3,DailyPrice=150,Description="Daily",ModelYear=2009}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)                   //LİNQ
        {
            Car carToDelete = _cars.SingleOrDefault(p=> p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()                            //DB'den Business'in bilgi almasını sağlar
        {
            return _cars;
        }

        public List<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.CarId== car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
