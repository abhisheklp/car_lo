using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarLo.Backend.DAL.Entities
{
    public class CarCategoryEntity
    {
        [Key]
        public int CarCategoryId { get; set; }

        [Required]
        [MaxLength(10)]
        public string CarCategoryName { get; set; }

        [Required]
        [MaxLength(255)]
        public string CarCategoryDescription { get; set; }

        public ICollection<CarDetailsEntity> CarDetails { get; set; }
    }
}
