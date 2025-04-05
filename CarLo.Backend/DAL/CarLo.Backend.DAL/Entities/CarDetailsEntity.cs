using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarLo.Backend.DAL.Entities
{
    public class CarDetailsEntity
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(15)]
        public string CarBrandName { get; set; }

        [Required]
        [MaxLength(15)]
        public string CarModelName { get; set; }

        [Required]
        [MaxLength(255)]
        public string CarDescription { get; set; }

        [Required]
        public string CarImageURL { get; set; }

        [Required]
        public int RentalPrice { get; set; }

        [Required]
        public int CarAvailability { get; set; }

        [Required]
        public int CarCategoryEntityId { get; set; }

        public ICollection<RentalAgreementEntity> RentalAgreementDetails { get; set; }
    }
}
