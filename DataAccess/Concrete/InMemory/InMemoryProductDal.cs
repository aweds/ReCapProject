using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = 1, ModelYear = 1985, DailyPrice =  15, Description = "Renault"},
                new Car {Id = 2, BrandId = 1, ColorId = 2, ModelYear = 2000, DailyPrice =  3,  Description = "BMW"},
                new Car {Id = 3, BrandId = 1, ColorId = 3, ModelYear = 1995, DailyPrice =  2,  Description = "AUDI"},
                new Car {Id = 4, BrandId = 1, ColorId = 4, ModelYear = 2015, DailyPrice =  65 ,Description = "Mercedes"},
                new Car {Id = 5, BrandId = 1, ColorId = 5, ModelYear = 2020, DailyPrice =  1,  Description = "Ferrai"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            productToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(productToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car product)
        {
            Car productToUpdate = _cars.SingleOrDefault(p => p.Id == product.Id);
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.ModelYear = product.ModelYear;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.Description = product.Description;
        }
    }
}
