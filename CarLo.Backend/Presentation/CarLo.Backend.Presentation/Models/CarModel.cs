using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarLo.Backend.Presentation.Models
{
    public class CarModel
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
