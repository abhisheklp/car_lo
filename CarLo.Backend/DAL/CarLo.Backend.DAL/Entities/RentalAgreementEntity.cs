using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarLo.Backend.DAL.Entities
{
    public class RentalAgreementEntity
    {
        [Key]
        public int AgreementId {get; set;}

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [Range(1,15)]
        public int NoOfDays { get; set; }

        [Required]
        public string LicenseNo { get; set; }

        [ForeignKey("CarDetailsEntity")]
        public int CarDetailsEntityId { get; set; }

        public CarDetailsEntity CarDetailsEntity { get; set; }

        [Required]
        public string VehicleNo { get; set; }

        [Required]
        public bool AgreementStatus { get; set; }
    }
}
