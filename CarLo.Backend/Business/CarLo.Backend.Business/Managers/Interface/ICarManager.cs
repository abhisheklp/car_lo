using CarLo.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.Business.Managers.Interface
{
    public interface ICarManager
    {
        Task<int> AddCar(CarDetailsDTO car);

        Task<IEnumerable<CarDetailsDTO>> GetAllCars();

        Task<CarDetailsDTO> GetCarById(int id);

        Task<IEnumerable<CarDetailsDTO>> GetCarsByCategory(int categoryId);

        Task<IEnumerable<CarDetailsDTO>> SearchCar(string query);

        Task<bool> DeleteCar(int id);

        Task updateQuantity(int id, int decQuantity);

        Task<bool> UpdateCar(CarDetailsDTO updatedCar);
    }
}
