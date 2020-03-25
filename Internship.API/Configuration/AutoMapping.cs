using AutoMapper;
using Internship.API.Models;

namespace Internship.API.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>().ReverseMap(); // means you want to map from User to UserDTO and viceversa
            CreateMap<User, MentorDTO>().ReverseMap(); // means you want to map from User to MentorDTO and viceversa
            CreateMap<Intern, InternDTO>().ReverseMap(); // means you want to map from Intern to InternDTO and viceversa
        }
    }
}