using AutoMapper;

namespace API.Profiles
{
    public class EmpProfile:Profile
    {
        public EmpProfile()
        {
            CreateMap<Entity.Employee, DTO.Employee>();
            CreateMap<DTO.Employee, Entity.Employee>();
        }
    }
}
