using System.Net.Sockets;
using NetDriver.AE;

namespace MessengerServer
{
    internal class Client(TaskHandler handler, Socket socket) : User
    {
        public readonly TaskHandler handler = handler;
        public readonly Socket socket = socket;
        public readonly Networker network = new(socket, handler.Executor);
    }
}