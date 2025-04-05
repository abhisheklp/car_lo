using CarLo.Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository.Interface
{
    public interface ICarRepository
    {
        Task<int> AddCar(CarDetailsEntity car);

        Task<IEnumerable<CarDetailsEntity>> GetAllCars();

        Task<CarDetailsEntity> GetCarById(int id);

        Task<IEnumerable<CarDetailsEntity>> GetCarsByCategory(int categoryId);

        Task<IEnumerable<CarDetailsEntity>> SearchCar(string query);

        Task<bool> DeleteCar(int id);

        Task updateQuantity(int id, int decQuantity);

        Task<bool> UpdateCar(CarDetailsEntity updatedCar);
    }
}
