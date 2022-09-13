using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

namespace Asset_Management1.Blazor;

public class Program
{
    [System.Obsolete]
    public async static Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        var application = await builder.AddApplicationAsync<Asset_Management1BlazorModule>(options =>
        {
            options.UseAutofac();
        });

        var host = builder.Build();

        await application.InitializeApplicationAsync(host.Services);

        builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

        await host.RunAsync();
    }
}
