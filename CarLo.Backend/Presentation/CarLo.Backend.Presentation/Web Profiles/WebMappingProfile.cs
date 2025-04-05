using AutoMapper;
using CarLo.Backend.Business.DTO;
using CarLo.Backend.Business.DTO.AccountDTO;
using CarLo.Backend.Presentation.Models;
using CarLo.Backend.Presentation.Models.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarLo.Backend.Presentation.Web_Profiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<LoginModel, LoginDTO>().ReverseMap();

            CreateMap<SignUpModel, SignUpDTO>().ReverseMap();

            CreateMap<CarModel, CarDetailsDTO>().ReverseMap();

            CreateMap<CategoryModel, CarCategoryDTO>().ReverseMap();

            CreateMap<RentalAgreementModel, RentalAgreementDTO>().ReverseMap();

            CreateMap<ReturnRequestModel, ReturnRequestDTO>().ReverseMap();
        }
    }
}
