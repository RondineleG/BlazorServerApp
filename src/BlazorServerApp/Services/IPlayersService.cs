using BlazorServerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Services
{
    public interface IPlayersService
    {
        Task<List<Player>> GetPlayersList();
        Task<Player> GetPlayerById(int id);
        Task<Player> CreatePlayer(Player player);
        Task UpdatePlayer(Player player);
        Task DeletePlayer(Player player);
    }
}
