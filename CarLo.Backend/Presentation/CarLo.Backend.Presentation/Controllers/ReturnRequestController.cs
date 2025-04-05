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
    [Route("return")]
    [Authorize]
    public class ReturnRequestController : ControllerBase
    {
        private readonly IReturnRequestManager _returnRequestManager;
        private readonly IMapper _mapper;

        public ReturnRequestController(IReturnRequestManager returnRequestManager, IMapper mapper)
        {
            _returnRequestManager = returnRequestManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new return request.
        /// </summary>
        /// <param name="returnRequest">The return request to add.</param>
        /// <returns>Returns the ID of the added return request.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> AddReturnRequest(ReturnRequestModel returnRequest)
        {
            var entity = _mapper.Map<ReturnRequestDTO>(returnRequest);
            return Ok(await _returnRequestManager.AddReturnRequest(entity));
        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>Returns the list of all return requets.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnRequestModel>>> GetAllReturnRequest()
        {
            var response = await _returnRequestManager.GetAllReturnRequest();
            return Ok(_mapper.Map<IEnumerable<ReturnRequestModel>>(response));
        }

        /// <summary>
        /// Updates an request.
        /// </summary>
        /// <param name="updateApprovalRemarks">The updated return request data.</param>
        /// <returns>Returns a value indicating whether the return request update was successful or not.</returns>
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateApprovalRemarks(ReturnRequestModel updateApprovalRemarks)
        {
            var entity = _mapper.Map<ReturnRequestDTO>(updateApprovalRemarks);
            return Ok(await _returnRequestManager.UpdateApprovalRemarks(entity));
        }
    }
}
