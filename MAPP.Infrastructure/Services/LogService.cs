using AutoMapper;
using MAPP.Application.DTOs;
using MAPP.Application.Interfaces;
using MAPP.Domain.Entities;
using MAPP.Infrastructure.Persistence;

namespace MAPP.Infrastructure.Services
{
    public class LogService(AppDbContext context, IMapper mapper) : ILogService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task AddLog(AddLogDto logDto)
        {
            var log = _mapper.Map<Log>(logDto);
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
