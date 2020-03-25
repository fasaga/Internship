using AutoMapper;
using Internship.API.Models;

namespace Internship.API.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>(); // means you want to map from User to UserDTO
            CreateMap<UserDTO, User>(); // means you want to map from UserDTO to User
            CreateMap<User, MentorDTO>(); // means you want to map from User to MentorDTO
            CreateMap<MentorDTO, User>(); // means you want to map from MentorDTO to User
            CreateMap<InternDTO, Intern>(); // means you want to map from InternDTO to Intern
            CreateMap<Intern, InternDTO>(); // means you want to map from Intern to InternDTO
        }
    }
}