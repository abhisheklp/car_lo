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
    [Route("car")]
    public class CarController : ControllerBase
    {
        private readonly ICarManager _carManager;
        private readonly IMapper _mapper;

        public CarController(ICarManager carManager, IMapper mapper)
        {
            _carManager = carManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new car.
        /// </summary>
        /// <param name="product">The car to add.</param>
        /// <returns>Returns the ID of the added car.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddCar([FromForm] CarModel car)
        {
            var entity = _mapper.Map<CarDetailsDTO>(car);
            return Ok(await _carManager.AddCar(entity));
        }

        /// <summary>
        /// Retrieves all cars.
        /// </summary>
        /// <returns>Returns the list of all cars.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetAllCars()
        {
            var response = await _carManager.GetAllCars();
            return Ok(_mapper.Map<IEnumerable<CarModel>>(response));
        }

        /// <summary>
        /// Retrieves a car by ID.
        /// </summary>
        /// <param name="id">The ID of the car.</param>
        /// <returns>Returns the car with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarById(int id)
        {
            var response = await _carManager.GetCarById(id);
            return Ok(_mapper.Map<CarModel>(response));
        }


        /// <summary>
        /// Retrieves car by category ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>Returns the list of car in the specified category.</returns>
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarsByCategory(int categoryId)
        {
            var response = await _carManager.GetCarsByCategory(categoryId);
            return Ok(_mapper.Map<IEnumerable<CarModel>>(response));
        }

        /// <summary>
        /// Searches for car based on a query string.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>Returns the list of car matching the search query.</returns>
        [HttpGet("search/")]
        public async Task<ActionResult<IEnumerable<CarModel>>> SearchCar([FromQuery] string query)
        {
            var response = await _carManager.SearchCar(query);
            return Ok(_mapper.Map<IEnumerable<CarModel>>(response));
        }

        /// <summary>
        /// Deletes a car.
        /// </summary>
        /// <param name="id">The ID of the car to delete.</param>
        /// <returns>Returns a value indicating whether the car deletion was successful or not.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteCar(int id)
        {
            return Ok(await _carManager.DeleteCar(id));
        }


        /// <summary>
        /// Updates the quantity of a car.
        /// </summary>
        /// <param name="id">The ID of the car.</param>
        /// <param name="decQuantity">The decreased quantity to add.</param>
        /// <returns>Returns the updated car quantity.</returns>
        [HttpPatch("{id}/{decQuantity}")]
        [Authorize]
        public async Task<ActionResult> updateQuantity(int id, int decQuantity)
        {
            await _carManager.updateQuantity(id, decQuantity);
            return Ok();
        }

        /// <summary>
        /// Updates a car.
        /// </summary>
        /// <param name="updatedProduct">The updated car data.</param>
        /// <returns>Returns a value indicating whether the car update was successful or not.</returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateCar([FromForm] CarModel updatedCar)
        {
            var entity = _mapper.Map<CarDetailsDTO>(updatedCar);
            return Ok(await _carManager.UpdateCar(entity));
        }
        
    }
}
