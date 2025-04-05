using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarLo.Backend.DAL.Entities
{
    public class ReturnRequestEntity
    {
        [Key]
        public int ReturnRequestId { get; set; }

        [Required]
        [ForeignKey("RentalAgreementEntity")]
        public int RentalAgreementEntityId { get; set; }
        public RentalAgreementEntity RentalAgreementEntity { get; set; }

        [Required]
        public bool ReturnRequestGenerate { get; set; }

        [Required]
        public bool ReturnApproval { get; set; }

        [Required]
        [MaxLength(255)]
        public string Remarks { get; set; }
    }
}
