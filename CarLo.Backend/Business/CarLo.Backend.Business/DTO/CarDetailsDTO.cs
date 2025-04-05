using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.DTO
{
    public class CarDetailsDTO
    {
        public int CarId { get; set; }

        public string CarBrandName { get; set; }

        public string CarModelName { get; set; }

        public string CarDescription { get; set; }

        public string CarImageURL { get; set; }

        public int RentalPrice { get; set; }

        public int CarAvailability { get; set; }

        public int CarCategoryEntityId { get; set; }
    }
}
