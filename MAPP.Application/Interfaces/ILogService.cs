using MAPP.Application.DTOs;

namespace MAPP.Application.Interfaces
{
    public interface ILogService
    {
        Task AddLog(AddLogDto logDto);
    }
}
