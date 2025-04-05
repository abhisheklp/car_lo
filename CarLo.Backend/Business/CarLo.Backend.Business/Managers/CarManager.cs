using AutoMapper;
using CarLo.Backend.Business.DTO;
using CarLo.Backend.Business.Managers.Interface;
using CarLo.Backend.Business.Validations;
using CarLo.Backend.DAL.Entities;
using CarLo.Backend.DAL.Repository.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.Business.Managers
{
    public class CarManager : ICarManager
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarManager(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<int> AddCar(CarDetailsDTO car)
        {
            CarDetailsValidator carValidator = new CarDetailsValidator();
            ValidationResult result = carValidator.Validate(car);

            if (result.IsValid)
            {
                var entity = _mapper.Map<CarDetailsEntity>(car);
                var response = await _carRepository.AddCar(entity);
                return response;
            }
            return -1;
        }

        public async Task<IEnumerable<CarDetailsDTO>> GetAllCars()
        {
            var response = await _carRepository.GetAllCars();
            return _mapper.Map<IEnumerable<CarDetailsDTO>>(response);
        }

        public async Task<CarDetailsDTO> GetCarById(int id)
        {
            var response = await _carRepository.GetCarById(id);
            return _mapper.Map<CarDetailsDTO>(response);
        }

        public async Task<IEnumerable<CarDetailsDTO>> GetCarsByCategory(int categoryId)
        {
            var response = await _carRepository.GetCarsByCategory(categoryId);
            return _mapper.Map<IEnumerable<CarDetailsDTO>>(response);
        }

        public async Task<IEnumerable<CarDetailsDTO>> SearchCar(string query)
        {
            var response = await _carRepository.SearchCar(query);
            return _mapper.Map<IEnumerable<CarDetailsDTO>>(response);
        }

        public async Task<bool> DeleteCar(int id)
        {
            var response = await _carRepository.DeleteCar(id);
            return response;
        }

        public async Task updateQuantity(int id, int decQuantity)
        {
            await _carRepository.updateQuantity(id, decQuantity);
        }

        public async Task<bool> UpdateCar(CarDetailsDTO updatedCar)
        {
            CarDetailsValidator carValidator = new CarDetailsValidator();
            ValidationResult result = carValidator.Validate(updatedCar);

            if (result.IsValid)
            {
                var entity = _mapper.Map<CarDetailsEntity>(updatedCar);
                var response = await _carRepository.UpdateCar(entity);
                return response;
            }
            return false;
        }
    }
}
