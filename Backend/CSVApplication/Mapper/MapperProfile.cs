using AutoMapper;
using CSVApplication.Core.Models;
using CSVApplication.Entities;
using CSVApplication.WebAPI.DTO;

namespace CSVApplication.WebAPI.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            InitializeMappers();
        }

        public void InitializeMappers()
        {
            CreateMap<CSVBodyDTO, CSVBodyModel>().ReverseMap();
            CreateMap<CSVBodyModel, CSVBodyEntity>().ReverseMap();
        }
    }
}
