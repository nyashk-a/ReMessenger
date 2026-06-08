using System.Net.Sockets;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessengerServer
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddPooledDbContextFactory<AppDbContext>(options =>
                options.UseNpgsql("Host=localhost;Database=JabNetDatabase;Username=Jadmin;Password=4649"));
                services.AddSingleton<TaskHandler>();
            }).Build();
            
            Channel<Socket> accepting = Channel.CreateUnbounded<Socket>();
            var clientFabric = new ConnectionFabric(accepting, 22222);

            

            // var server = host.Services.GetRequiredService<TaskHandler>();
        }
    }
}