using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarLo.Backend.Presentation.Models
{
    public class RentalAgreementModel
    {
        public int AgreementId { get; set; }

        public string FullName { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public int NoOfDays { get; set; }

        public string LicenseNo { get; set; }

        public int CarDetailsEntityId { get; set; }

        public string VehicleNo { get; set; }

        public bool AgreementStatus { get; set; }
    }
}
