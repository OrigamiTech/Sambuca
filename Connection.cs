using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Sambuca
{
    public partial class Connection
    {
        const ushort DEFAULT_PORT = 25565;
        private NetworkStream stream;
        private TcpClient connection;

        private string _GameFilesCurrentVersion;
        private string _DownloadTicket;
        private string _Username;
        private string _SessionId;
        public string GameFilesCurrentVersion { get { return _GameFilesCurrentVersion; } }
        public string DownloadTicket { get { return _DownloadTicket; } }
        public string Username { get { return _Username; } }
        public string SessionId { get { return _SessionId; } }

        private bool _DebugLogging = true;
        public bool DebugLogging { get { return _DebugLogging; } set { _DebugLogging = value; } }

        public bool Authenticate(bool useOldProtocol, string username, string password, string version)
        {
            string authData = WebInterface.SendPOST(
                new Dictionary<string, string>(){
                    {"user",username},
                    {"password",password},
                    {"version",version},
                },
                useOldProtocol ? "http://www.minecraft.net/game/getversion.jsp" : "https://login.minecraft.net/");
            if(authData.Trim().ToLower() == "bad login" || authData.Trim().ToLower() == "old version")
                return false;
            Console.WriteLine(authData);
            string[] authComponents = authData.Trim().Split(':');
            _GameFilesCurrentVersion = authComponents[0];
            _DownloadTicket = authComponents[1];
            _Username = authComponents[2];
            _SessionId = authComponents[3];
            return true;
        }
        public void ConnectToServer(string hostname)
        { ConnectToServer(hostname, DEFAULT_PORT); }
        public void ConnectToServer(string hostname, ushort port)
        {
            connection = new TcpClient(hostname, port);
            stream = connection.GetStream();
            SendPacket(new Packets.HandshakeOutgoing(_Username));
            RunConnectedLoop();
        }
        public string GetJoinServerAuth(string connectionhash)
        {
            return WebInterface.SendGET(
                            new Dictionary<string, string>() {
                                {"user",Username},
                                {"sessionId",SessionId},
                                {"serverId",connectionhash}
                            }, "http://www.minecraft.net/game/joinserver.jsp");
        }
        private void RunConnectedLoop()
        {
            while(connection.Connected)
            {
                int packetId = stream.ReadByte();
                if(packetId == -1)
                    break;
                Packets.Packet packet = Packets.Deserialize((byte)packetId, stream);
                if(_DebugLogging)
                {
                    Console.WriteLine("0x" + ((byte)packet.PacketId).ToString("X2") + ' ' + packet.PacketId.ToString());
                    packet.Dump();
                }
                switch(packet.PacketId)
                {
                    case Packets.PacketId.KeepAlive:
                        OnPacket_KeepAlive((Packets.KeepAlive)packet);
                        break;
                    case Packets.PacketId.LoginRequest:
                        OnPacket_LoginRequest((Packets.LoginRequestIncoming)packet);
                        break;
                    case Packets.PacketId.Handshake:
                        OnPacket_Handshake((Packets.HandshakeIncoming)packet);
                        break;
                    case Packets.PacketId.ChatMessage:
                        OnPacket_ChatMessage((Packets.ChatMessage)packet);
                        break;
                    case Packets.PacketId.TimeUpdate:
                        OnPacket_TimeUpdate((Packets.TimeUpdate)packet);
                        break;
                    case Packets.PacketId.SpawnPosition:
                        OnPacket_SpawnPosition((Packets.SpawnPosition)packet);
                        break;
                    case Packets.PacketId.PlayerPositionAndLook:
                        OnPacket_PlayerPositionAndLook((Packets.PlayerPositionAndLookIncoming)packet);
                        break;
                    case Packets.PacketId.AddObjectVehicle:
                        OnPacket_AddObjectVehicle((Packets.AddObjectVehicle)packet);
                        break;
                    case Packets.PacketId.EntityPainting:
                        OnPacket_EntityPainting((Packets.EntityPainting)packet);
                        break;
                    case Packets.PacketId.EntityVelocity:
                        OnPacket_EntityVelocity((Packets.EntityVelocity)packet);
                        break;
                    case  Packets.PacketId.PreChunk:
                        OnPacket_PreChunk((Packets.PreChunk)packet);
                        break;
                    case Packets.PacketId.DisconnectKick:
                        OnPacket_DisconnectKick((Packets.DisconnectKick)packet);
                        break;
                    default:
                        break;
                }
            }
        }
        public void SendPacket(Packets.Packet packet)
        {
            if(_DebugLogging)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("0x" + ((byte)packet.PacketId).ToString("X2") + ' ' + packet.PacketId.ToString());
                packet.Dump();
            }
            stream.WriteByte((byte)packet.PacketId);
            byte[] data = packet.Data;
            stream.Write(data, 0, data.Length);
            if(_DebugLogging)
                Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
