using CarLo.Backend.DAL.Data.DBContext;
using CarLo.Backend.DAL.Entities;
using CarLo.Backend.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarLoDbContext _carLoDbContext;

        public CarRepository(CarLoDbContext carLoDbContext)
        {
            _carLoDbContext = carLoDbContext;
        }

        public async Task<int> AddCar(CarDetailsEntity car)
        {
            await _carLoDbContext.AddAsync(car);
            await _carLoDbContext.SaveChangesAsync();
            return car.CarId;
        }

        public async Task<IEnumerable<CarDetailsEntity>> GetAllCars()
        {
            var allProduct = await _carLoDbContext.CarDetails.ToListAsync();
            return allProduct;
        }

        public async Task<CarDetailsEntity> GetCarById(int id)
        {
            var product = await _carLoDbContext.CarDetails.Where(x => x.CarId == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<CarDetailsEntity>> GetCarsByCategory(int categoryId)
        {
            var allProduct = await _carLoDbContext.CarDetails.Where(x => x.CarCategoryEntityId == categoryId).ToListAsync();
            return allProduct;
        }

        public async Task<IEnumerable<CarDetailsEntity>> SearchCar(string query)
        {
            var products = await _carLoDbContext.CarDetails.Where(c => c.CarBrandName.Contains(query) || c.CarModelName.Contains(query) || c.CarDescription.Contains(query)).ToListAsync();
            return products;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var product = await _carLoDbContext.CarDetails.FindAsync(id);
            if (product != null)
            {
                _carLoDbContext.CarDetails.Remove(product);
                await _carLoDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task updateQuantity(int id, int decQuantity)
        {
            var car = await _carLoDbContext.CarDetails.FindAsync(id);
            car.CarAvailability = car.CarAvailability - decQuantity;
            await _carLoDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateCar(CarDetailsEntity updatedCar)
        {
            var car = await _carLoDbContext.CarDetails.FindAsync(updatedCar.CarId);
            if (car != null)
            {
                car.CarBrandName = updatedCar.CarBrandName;
                car.CarModelName = updatedCar.CarModelName;
                car.CarDescription = updatedCar.CarDescription;
                car.CarImageURL = updatedCar.CarImageURL;
                car.RentalPrice = updatedCar.RentalPrice;
                car.CarAvailability = updatedCar.CarAvailability;
                await _carLoDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
