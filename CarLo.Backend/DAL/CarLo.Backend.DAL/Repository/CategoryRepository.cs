using CarLo.Backend.DAL.Data.DBContext;
using CarLo.Backend.DAL.Entities;
using CarLo.Backend.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CarLoDbContext _carLoDbContext;

        public CategoryRepository(CarLoDbContext carLoDbContext)
        {
            _carLoDbContext = carLoDbContext;
        }

        public async Task<IEnumerable<CarCategoryEntity>> GetAllCategory()
        {
            var allCategory = await _carLoDbContext.CarCategories.ToListAsync();
            return allCategory;
        }

        public async Task<int> AddCategory(CarCategoryEntity category)
        {
            await _carLoDbContext.AddAsync(category);
            await _carLoDbContext.SaveChangesAsync();
            return category.CarCategoryId;
        }
    }
}
