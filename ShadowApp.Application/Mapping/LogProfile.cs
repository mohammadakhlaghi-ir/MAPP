using AutoMapper;
using ShadowApp.Application.DTOs;
using ShadowApp.Domain.Entities;

namespace ShadowApp.Application.Mapping
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<AddLogDto, Log>().ReverseMap();
        }
    }
}
