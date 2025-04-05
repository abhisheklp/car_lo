using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.DTO
{
    public class RentalAgreementDTO
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
