using CarLo.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.Business.Managers.Interface
{
    public interface IRentalAgreementManager
    {
        Task<int> AddAgreement(RentalAgreementDTO agreement);

        Task<IEnumerable<RentalAgreementDTO>> GetAllAgreements();

        Task<bool> UpdateAgreement(RentalAgreementDTO updatedAgreement);

        Task<bool> UpdateAgreementStatus(int agreementId);

        Task<bool> DeleteAgreement(int agreementid);
    }
}
