using BlazorServerApp.Models;
using BlazorServerApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages.Players
{
    public partial class List
    {
        [Inject]
        protected IPlayersService PlayersService { get; set; }

        private List<Player> Players { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Players = await PlayersService.GetPlayersList();
        }

        public async Task DeletePlayer(int playerId)
        {

            var player = await PlayersService.GetPlayerById(playerId);
            if (player != null)
            {
                await PlayersService.DeletePlayer(player);

                Players.RemoveAll(x => x.Id == playerId);
            }
        }
    }
}
