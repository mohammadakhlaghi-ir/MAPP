using AutoMapper;
using MAPP.Application.DTOs;
using MAPP.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController(AppDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogs()
        {
            var logs = await _context.Logs
                .OrderByDescending(l => l.DateTime)
                .ToListAsync();

            var logDtos = _mapper.Map<IEnumerable<LogDto>>(logs);
            return Ok(logDtos);
        }
    }
}
