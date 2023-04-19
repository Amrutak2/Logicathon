using AutoMapper;
using domainmodel=RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Models.DTO;

namespace RollOff_Test4API.Profiles
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            //Reversemap() is used to we want to map DTO
            CreateMap<domainmodel.Employee, GetEmployee>()
                .ReverseMap();
            CreateMap<domainmodel.Employee, GetEmployeeByID>()
                .ReverseMap();
            CreateMap<domainmodel.Login, User>()
               .ReverseMap();
            
           
            CreateMap<domainmodel.FormTable, FormTableDTO>()
                .ReverseMap();
            CreateMap<domainmodel.FormTable, UpdateFormDTO>()
                .ReverseMap();

        }
    }
}
