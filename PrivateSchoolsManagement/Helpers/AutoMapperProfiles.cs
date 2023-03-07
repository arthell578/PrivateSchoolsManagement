using AutoMapper;
using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<SchoolDTO, School>();
            CreateMap<UserDTO, User>();
            CreateMap<CreateUserDTO, User>();
        }
    }
}
