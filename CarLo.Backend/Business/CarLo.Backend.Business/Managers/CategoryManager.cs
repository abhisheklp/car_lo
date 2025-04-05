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
    public class CategoryManager : ICategoryManager
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _carCategoryRepository;

        public CategoryManager(ICategoryRepository carCategoryRepository, IMapper mapper)
        {
            _carCategoryRepository = carCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarCategoryDTO>> GetAllCategories()
        {
            var response = await _carCategoryRepository.GetAllCategory();
            return _mapper.Map<IEnumerable<CarCategoryDTO>>(response);
        }

        public async Task<int> AddCategory(CarCategoryDTO category)
        {
            CarCategoryValidator categoryValidator = new CarCategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if (result.IsValid)
            {
                var entity = _mapper.Map<CarCategoryEntity>(category);
                var response = await _carCategoryRepository.AddCategory(entity);
                return response;
            }
            return -1;
        }
    }
}
