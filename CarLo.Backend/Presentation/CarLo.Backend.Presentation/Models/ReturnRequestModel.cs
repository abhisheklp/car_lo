using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarLo.Backend.Presentation.Models
{
    public class ReturnRequestModel
    {
        public int ReturnRequestId { get; set; }

        public int RentalAgreementEntityId { get; set; }

        public bool ReturnRequestGenerate { get; set; }

        public bool ReturnApproval { get; set; }

        public string Remarks { get; set; }
    }
}
