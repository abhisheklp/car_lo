using CarLo.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.Business.Managers.Interface
{
    public interface IReturnRequestManager
    {
        Task<int> AddReturnRequest(ReturnRequestDTO returnRequest);

        Task<IEnumerable<ReturnRequestDTO>> GetAllReturnRequest();

        Task<bool> UpdateApprovalRemarks(ReturnRequestDTO updateApprovalRemarks);
    }
}
