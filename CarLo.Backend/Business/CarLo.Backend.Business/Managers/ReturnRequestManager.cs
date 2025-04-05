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
    public class ReturnRequestManager : IReturnRequestManager
    {
        private readonly IReturnRequestRepository _returnRequestRepository;
        private readonly IMapper _mapper;

        public ReturnRequestManager(IReturnRequestRepository returnRequestRepository, IMapper mapper)
        {
            _returnRequestRepository = returnRequestRepository;
            _mapper = mapper;
        }

        public async Task<int> AddReturnRequest(ReturnRequestDTO returnRequest)
        {
            ReturnRequestValidator returnRequestValidator = new ReturnRequestValidator();
            ValidationResult result = returnRequestValidator.Validate(returnRequest);

            if (result.IsValid)
            {
                var entity = _mapper.Map<ReturnRequestEntity>(returnRequest);
                var response = await _returnRequestRepository.AddReturnRequest(entity);
                return response;
            }
            return -1;
        }

        public async Task<IEnumerable<ReturnRequestDTO>> GetAllReturnRequest()
        {
            var response = await _returnRequestRepository.GetAllReturnRequest();
            return _mapper.Map<IEnumerable<ReturnRequestDTO>>(response);
        }

        public async Task<bool> UpdateApprovalRemarks(ReturnRequestDTO updateApprovalRemarks)
        {
            ReturnRequestValidator returnRequestValidator = new ReturnRequestValidator();
            ValidationResult result = returnRequestValidator.Validate(updateApprovalRemarks);

            if (result.IsValid)
            {
                var entity = _mapper.Map<ReturnRequestEntity>(updateApprovalRemarks);
                var response = await _returnRequestRepository.UpdateApprovalRemarks(entity);
                return response;
            }
            return false;
        }
    }
}
