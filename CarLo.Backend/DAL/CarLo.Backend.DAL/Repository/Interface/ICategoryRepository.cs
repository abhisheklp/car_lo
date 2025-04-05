using CarLo.Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CarCategoryEntity>> GetAllCategory();

        Task<int> AddCategory(CarCategoryEntity category);
    }
}
