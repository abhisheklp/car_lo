using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.DAL.Miscellaneous
{
    public class VehicleNumberGenerator
    {
        public string GenerateRandomVehicleRegistrationNumber()
        {
            string stateCode = GenerateRandomStateCode();
            string districtCode = GenerateRandomDistrictCode();
            string randomchar = GenerateRandomCharCode();
            string serialNumber = GenerateRandomSerialNumber();
            string registrationNumber = $"{stateCode} {districtCode} {randomchar} {serialNumber}";
            return registrationNumber;
        }

        private string GenerateRandomStateCode()
        {
            List<string> stateCodes = new List<string> { "AP", "AR", "AS", "BR", "CG", "GA", "GJ", "HR", "HP", "JH", "KA", "KL", "MP", "MH", "MN", "ML", "MZ", "NL", "OR", "PB", "RJ", "SK", "TN", "TG", "TR", "UP", "UK", "WB" };
            Random random = new Random();
            string randomStateCode = stateCodes[random.Next(0, stateCodes.Count)];
            return randomStateCode;
        }

        private string GenerateRandomDistrictCode()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            string randomDistrictCode = randomNumber.ToString("D2");
            return randomDistrictCode;
        }

        private string GenerateRandomCharCode()
        {
            Random random = new Random();
            char firstChar = (char)random.Next(65, 91);
            char secondChar = (char)random.Next(65, 91);
            string randomCharCode = $"{firstChar}{secondChar}";
            return randomCharCode;
        }


        private string GenerateRandomSerialNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 10000);
            string randomSerialNumber = randomNumber.ToString("D4");
            return randomSerialNumber;
        }
    }
}
