using BlazorServerApp.Models;
using BlazorServerApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages.Players
{
    public partial class Edit
    {
        [Inject]
        protected IPlayersService PlayersService { get; set; }

        [Inject]
        protected IPositionsService PositionsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Player Player { get; set; }
        private List<Position> Positions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Player = await PlayersService.GetPlayerById(Id);
            Positions = await PositionsService.GetPositionsList();
        }

        private async void SubmitPlayer()
        {
            await PlayersService.UpdatePlayer(Player);

            NavigationManager.NavigateTo("/players");
        }
    }
}
