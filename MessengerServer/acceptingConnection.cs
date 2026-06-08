using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using Shared.Source.tools;

namespace MessengerServer
{
    internal class ConnectionFabric : IAsyncDisposable
    {
        private readonly Socket socket;
        private readonly CancellationTokenSource _cts = new();
        private readonly Task Action;
        public ConnectionFabric(Channel<Socket> output, int port)
        {
            socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Action = AcceptingConnectionsAsync(output, port);
        }
        private async Task AcceptingConnectionsAsync(Channel<Socket> output, int port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen();

            while(!_cts.IsCancellationRequested)
            {
                var sClien = await socket.AcceptAsync(_cts.Token);
                await output.Writer.WriteAsync(sClien, _cts.Token);
            }
        }

        public async ValueTask DisposeAsync()
        {
            _cts.Cancel();
            await Action;
            _cts.Dispose();
        }
    }
}