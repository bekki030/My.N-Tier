using AutoMapper;
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Models.Person;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeModel,Employee>().ReverseMap();
            CreateMap<UpdateEmployeeModel,Employee>().ReverseMap();
            CreateMap<Employee,EmployeeResponseModel>().ReverseMap();
            CreateMap<CreatePersonModel,Person>().ReverseMap();
        }
    }
}
