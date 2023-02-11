using AutoMapper;
namespace API.Profiles
{ 

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entity.Employee, DTO.Employee>();
            CreateMap<DTO.Employee, Entity.Employee>();
            CreateMap<List<DTO.Employee>, List<Entity.Employee>>();
        }
    }
}
