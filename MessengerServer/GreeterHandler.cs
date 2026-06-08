using System;
using System.Net.Sockets;
using System.Threading.Channels;

namespace MessengerServer
{
    public class Greeter : IAsyncDisposable
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly Task Action;
        public Greeter(Channel<Socket> output)
        {
            Action = AcceptingConnectionsAsync(output);
        }
        private async Task AcceptingConnectionsAsync(Channel<Socket> output)
        {
            
        }

        public async ValueTask DisposeAsync()
        {
            _cts.Cancel();
            await Action;
            _cts.Dispose();
        }
    }
}