using BlazorServerApp.Data;
using BlazorServerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Services
{
    public class PositionsService : IPositionsService
    {
        private readonly FootballDbContext _context;

        public PositionsService(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<List<Position>> GetPositionsList()
        {
            return await _context.Positions
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }
    }
}
