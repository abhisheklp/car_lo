using AutoMapper;
using CarLo.Backend.Business.DTO;
using CarLo.Backend.Business.DTO.AccountDTO;
using CarLo.Backend.DAL.Entities;
using CarLo.Backend.DAL.Entities.AccountEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carlo.Backend.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginDTO, LoginEntity>().ReverseMap();

            CreateMap<SignUpDTO, SignUpEntity>().ReverseMap();

            CreateMap<CarDetailsDTO, CarDetailsEntity>().ReverseMap();

            CreateMap<CarCategoryDTO, CarCategoryEntity>().ReverseMap();

            CreateMap<RentalAgreementDTO, RentalAgreementEntity>().ReverseMap();

            CreateMap<ReturnRequestDTO, ReturnRequestEntity>().ReverseMap();
        }
    }
}
