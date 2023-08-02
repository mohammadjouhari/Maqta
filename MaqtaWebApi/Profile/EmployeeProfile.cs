using AutoMapper;
namespace API.Profiles
{ 

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entity.Employee, DTO.Employee>();
            CreateMap<DTO.Employee, Entity.Employee>();
<<<<<<< HEAD
=======
            CreateMap<List<DTO.Employee>, List<Entity.Employee>>();
>>>>>>> 7f5fe51 (Added my project)
        }
    }
}
