using BlazorServerApp.Models;
using BlazorServerApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages.Players
{
    public partial class Create
    {
        [Inject]
        protected IPlayersService PlayersService { get; set; }

        [Inject]
        protected IPositionsService PositionsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Player Player { get; set; }
        private List<Position> Positions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Player = new Player();
            Positions = await PositionsService.GetPositionsList();
        }

        private async void SubmitPlayer()
        {
            await PlayersService.CreatePlayer(Player);

            NavigationManager.NavigateTo("/players");
        }
    }
}
