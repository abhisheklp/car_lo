using CarLo.Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository.Interface
{
    public interface IRentalAgreementRepository
    {
        Task<int> AddAgreement(RentalAgreementEntity agreement);

        Task<IEnumerable<RentalAgreementEntity>> GetAllAgreements();

        Task<bool> UpdateAgreement(RentalAgreementEntity updatedAgreement);

        Task<bool> UpdateAgreementStatus(int agreementId);

        Task<bool> DeleteAgreement(int agreementid);

    }
}
