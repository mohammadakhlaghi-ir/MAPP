using MAPP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPP.Application.Interfaces
{
    public interface ILogService
    {
        Task AddLog(AddLogDto logDto);
    }
}
