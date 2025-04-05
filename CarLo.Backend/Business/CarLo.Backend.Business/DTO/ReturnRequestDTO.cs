using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.DTO
{
    public class ReturnRequestDTO
    {
        public int ReturnRequestId { get; set; }

        public int RentalAgreementEntityId { get; set; }

        public bool ReturnRequestGenerate { get; set; }

        public bool ReturnApproval { get; set; }

        public string Remarks { get; set; }
    }
}
