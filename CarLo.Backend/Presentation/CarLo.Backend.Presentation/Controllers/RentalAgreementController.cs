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
    [Route("agreement")]
    [Authorize]
    public class RentalAgreementController : ControllerBase
    {
        private readonly IRentalAgreementManager _rentalAgreementManager;
        private readonly IMapper _mapper;

        public RentalAgreementController(IRentalAgreementManager rentalAgreementManager, IMapper mapper)
        {
            _rentalAgreementManager = rentalAgreementManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new agreement.
        /// </summary>
        /// <param name="agreement">The agreement to add.</param>
        /// <returns>Returns the ID of the added agreement.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> AddAgreement(RentalAgreementModel agreement)
        {
            var entity = _mapper.Map<RentalAgreementDTO>(agreement);
            return Ok(await _rentalAgreementManager.AddAgreement(entity));
        }

        /// <summary>
        /// Retrieves all agreements.
        /// </summary>
        /// <returns>Returns the list of all cars.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalAgreementModel>>> GetAllAgreements()
        {
            var response = await _rentalAgreementManager.GetAllAgreements();
            return Ok(_mapper.Map<IEnumerable<RentalAgreementModel>>(response));
        }

        /// <summary>
        /// Updates an agreement.
        /// </summary>
        /// <param name="updatedAgreement">The updated agreement data.</param>
        /// <returns>Returns a value indicating whether the car update was successful or not.</returns>
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAgreement(RentalAgreementModel updatedAgreement)
        {
            var entity = _mapper.Map<RentalAgreementDTO>(updatedAgreement);
            return Ok(await _rentalAgreementManager.UpdateAgreement(entity));
        }

        /// <summary>
        /// Updates the status of an agreement.
        /// </summary>
        /// <param name="id">The ID of the agreement.</param>
        /// <returns>Returns the bool i.e whether status is updated or not.</returns>
        [HttpPatch("{agreementId}")]
        public async Task<ActionResult<bool>> UpdateAgreementStatus(int agreementId)
        {
            return Ok( await _rentalAgreementManager.UpdateAgreementStatus(agreementId));
        }

        /// <summary>
        /// Deletes an agreement.
        /// </summary>
        /// <param name="id">The ID of the agreemnet to delete.</param>
        /// <returns>Returns a value indicating whether the agreement deletion was successful or not.</returns>
        [HttpDelete("{agreementId}")]
        public async Task<ActionResult<bool>> DeleteAgreement(int agreementId)
        {
            return Ok(await _rentalAgreementManager.DeleteAgreement(agreementId));
        }

    }
}
