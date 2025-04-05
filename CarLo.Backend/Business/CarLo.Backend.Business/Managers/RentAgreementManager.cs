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
    public class RentalAgreementManager : IRentalAgreementManager
    {
        private readonly IRentalAgreementRepository _rentalAgreementRepository;
        private readonly IMapper _mapper;

        public RentalAgreementManager(IRentalAgreementRepository rentalAgreementRepository, IMapper mapper)
        {
            _rentalAgreementRepository = rentalAgreementRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAgreement(RentalAgreementDTO agreement)
        {
            RentalAgreementDetailsValidator rentalAgreementValidator = new RentalAgreementDetailsValidator();
            ValidationResult result = rentalAgreementValidator.Validate(agreement);

            if (result.IsValid)
            {
                var entity = _mapper.Map<RentalAgreementEntity>(agreement);
                var response = await _rentalAgreementRepository.AddAgreement(entity);
                return response;
            }
            return -1;
        }

        public async Task<IEnumerable<RentalAgreementDTO>> GetAllAgreements()
        {
            var response = await _rentalAgreementRepository.GetAllAgreements();
            return _mapper.Map<IEnumerable<RentalAgreementDTO>>(response);
        }

        public async Task<bool> UpdateAgreement(RentalAgreementDTO updatedAgreement)
        {
            RentalAgreementDetailsValidator rentalAgreementValidator = new RentalAgreementDetailsValidator();
            ValidationResult result = rentalAgreementValidator.Validate(updatedAgreement);

            if (result.IsValid)
            {
                var entity = _mapper.Map<RentalAgreementEntity>(updatedAgreement);
                var response = await _rentalAgreementRepository.UpdateAgreement(entity);
                return response;
            }
            return false;
        }

        public async Task<bool> UpdateAgreementStatus(int agreementId)
        {
            var response = await _rentalAgreementRepository.UpdateAgreementStatus(agreementId);
            return response;
        }

        public async Task<bool> DeleteAgreement(int agreementId)
        {
            var response = await _rentalAgreementRepository.DeleteAgreement(agreementId);
            return response;
        }

    }
}
