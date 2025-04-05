using CarLo.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.Business.Managers.Interface
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CarCategoryDTO>> GetAllCategories();

        Task<int> AddCategory(CarCategoryDTO category);
    }
}
