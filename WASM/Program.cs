using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HackRegistration.HttpRepository;
using HackRegistration.Services;

namespace HackRegistration
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient());
            builder.Services.AddScoped<IHacksHttpRepository, HacksHttpRepository>();
            builder.Services.AddScoped<ToastService>();

            await builder.Build().RunAsync();
        }
    }
}
