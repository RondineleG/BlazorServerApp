using BlazorServerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Services
{
    public interface IPositionsService
    {
        Task<List<Position>> GetPositionsList();
    }
}
