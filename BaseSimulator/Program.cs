using System.Threading.Tasks;
using Arknights.BaseSimulator.Data;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Arknights.BaseSimulator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddSingleton<GameService>();

            builder.RootComponents.Add<App>("app");
            var host = builder.Build();

            var gameService = host.Services.GetRequiredService<GameService>();
            await gameService.InitAsync("data/building_data.json", "data/item_table.json");

            await host.RunAsync();
        }
    }
}
