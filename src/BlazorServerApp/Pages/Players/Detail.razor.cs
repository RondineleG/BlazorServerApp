using BlazorServerApp.Models;
using BlazorServerApp.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages.Players
{
    public partial class Detail
    {
        [Inject]
        protected IPlayersService PlayersService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Player Player { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Player = await PlayersService.GetPlayerById(Id);
        }
    }
}
