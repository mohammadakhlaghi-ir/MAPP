using AutoMapper;
using MAPP.Application.DTOs;
using MAPP.Domain.Entities;

namespace MAPP.Application.Mapping
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<AddLogDto, Log>().ReverseMap();
        }
    }
}
