using System.Net.Http;
using System.Threading.Tasks;
using Arknights.BaseSimulator.Data;
using Arknights.Data;
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
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddSingleton(async sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                string jsonString = await httpClient.GetStringAsync("data/building_data.json");

                return BaseData.FromJson(jsonString);
            });
            builder.Services.AddSingleton<GameService>();

            await builder.Build().RunAsync();
        }
    }
}
