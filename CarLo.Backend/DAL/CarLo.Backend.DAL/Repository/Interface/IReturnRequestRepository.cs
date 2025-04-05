using CarLo.Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository.Interface
{
    public interface IReturnRequestRepository
    {
        Task<int> AddReturnRequest(ReturnRequestEntity returnRequest);

        Task<IEnumerable<ReturnRequestEntity>> GetAllReturnRequest();

        Task<bool> UpdateApprovalRemarks(ReturnRequestEntity updateApprovalRemarks);
    }
}
