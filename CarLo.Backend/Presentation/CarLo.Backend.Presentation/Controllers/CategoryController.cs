using AutoMapper;
using CarLo.Backend.Business.DTO;
using CarLo.Backend.Business.Managers.Interface;
using CarLo.Backend.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarLo.Backend.Presentation.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>Returns the list of categories.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetAllCategory()
        {
            var response = await _categoryManager.GetAllCategories();
            return Ok(_mapper.Map<IEnumerable<CategoryModel>>(response));
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The category to add.</param>
        /// <returns>Returns the ID of the added category.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddCategory(CategoryModel category)
        {
            var entity = _mapper.Map<CarCategoryDTO>(category);
            return Ok(await _categoryManager.AddCategory(entity));
        }
    }
}
