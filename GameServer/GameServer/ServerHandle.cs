using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient},username:{_username}");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Plaer \"{_username}\" (ID:{_fromClient}) has assumed the wrong client ID({_clientIdCheck})!");
            }
            //TODO send player into game
        }
    }
}
