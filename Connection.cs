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
        private bool _PacketDumping = true;
        public bool DebugLogging { get { return _DebugLogging; } set { _DebugLogging = value; } }
        public bool PacketDumping { get { return _PacketDumping; } set { _PacketDumping = value; } }

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
                try
                {
                    int packetId_ = stream.ReadByte();
                    if(packetId_ == -1)
                        break;
                    byte packetId = (byte)packetId_;
                    Packets.Packet packet = Packets.Deserialize(packetId, stream);
                    if(_DebugLogging)
                    {
                        Console.WriteLine("0x" + ((byte)packet.PacketId).ToString("X2") + ' ' + packet.PacketId.ToString());
                        if(_PacketDumping)
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
                        case Packets.PacketId.EntityEquipment:
                            OnPacket_EntityEquipment((Packets.EntityEquipment)packet);
                            break;
                        case Packets.PacketId.SpawnPosition:
                            OnPacket_SpawnPosition((Packets.SpawnPosition)packet);
                            break;
                        case Packets.PacketId.UpdateHealth:
                            OnPacket_UpdateHealth((Packets.UpdateHealth)packet);
                            break;
                        case Packets.PacketId.Respawn:
                            OnPacket_Respawn((Packets.Respawn)packet);
                            break;
                        case Packets.PacketId.PlayerPositionAndLook:
                            OnPacket_PlayerPositionAndLook((Packets.PlayerPositionAndLookIncoming)packet);
                            break;
                        case Packets.PacketId.Animation:
                            OnPacket_Animation((Packets.Animation)packet);
                            break;
                        case Packets.PacketId.NamedEntitySpawn:
                            OnPacket_NamedEntitySpawn((Packets.NamedEntitySpawn)packet);
                            break;
                        case Packets.PacketId.PickupSpawn:
                            OnPacket_PickupSpawn((Packets.PickupSpawn)packet);
                            break;
                        case Packets.PacketId.AddObjectVehicle:
                            OnPacket_AddObjectVehicle((Packets.AddObjectVehicle)packet);
                            break;
                        case Packets.PacketId.MobSpawn:
                            OnPacket_MobSpawn((Packets.MobSpawn)packet);
                            break;
                        case Packets.PacketId.EntityPainting:
                            OnPacket_EntityPainting((Packets.EntityPainting)packet);
                            break;
                        case Packets.PacketId.EntityVelocity:
                            OnPacket_EntityVelocity((Packets.EntityVelocity)packet);
                            break;
                        case Packets.PacketId.DestroyEntity:
                            OnPacket_DestroyEntity((Packets.DestroyEntity)packet);
                            break;
                        case Packets.PacketId.EntityRelativeMove:
                            OnPacket_EntityRelativeMove((Packets.EntityRelativeMove)packet);
                            break;
                        case  Packets.PacketId.EntityLookAndRelativeMove:
                            OnPacket_EntityLookAndRelativeMove((Packets.EntityLookAndRelativeMove)packet);
                            break;
                        case Packets.PacketId.EntityStatus:
                            OnPacket_EntityStatus((Packets.EntityStatus)packet);
                            break;
                        case Packets.PacketId.EntityMetadata:
                            OnPacket_EntityMetadata((Packets.EntityMetadata)packet);
                            break;
                        case Packets.PacketId.PreChunk:
                            OnPacket_PreChunk((Packets.PreChunk)packet);
                            break;
                        case Packets.PacketId.MapChunk:
                            OnPacket_MapChunk((Packets.MapChunk)packet);
                            break;
                        case Packets.PacketId.MultiBlockChange:
                            OnPacket_MultiBlockChange((Packets.MultiBlockChange)packet);
                            break;
                        case Packets.PacketId.BlockChange:
                            OnPacket_BlockChange((Packets.BlockChange)packet);
                            break;
                        case Packets.PacketId.NewInvalidState:
                            OnPacket_NewInvalidState((Packets.NewInvalidState)packet);
                            break;
                        case Packets.PacketId.SetSlot:
                            OnPacket_SetSlot((Packets.SetSlot)packet);
                            break;
                        case Packets.PacketId.WindowItems:
                            OnPacket_WindowItems((Packets.WindowItems)packet);
                            break;
                        case Packets.PacketId.DisconnectKick:
                            OnPacket_DisconnectKick((Packets.DisconnectKick)packet);
                            break;
                        default:
                            if(Enum.IsDefined(typeof(Packets.PacketId), packetId))
                                SendPacket(new Packets.DisconnectKick("Sambuca encountered unimplemented packet 0x" + packetId.ToString("X2") + " " + ((Packets.PacketId)packetId).ToString()));
                            else
                                SendPacket(new Packets.DisconnectKick("Sambuca encountered unexpected packet 0x" + packetId.ToString("X2")));
                            connection.Close(); // DEBUG OPTION
                            break;
                    }
                }
                catch(Exception ex) { Console.WriteLine(ex.ToString()); }
            }
        }
        public void SendPacket(Packets.Packet packet)
        {
            if(_DebugLogging)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("0x" + ((byte)packet.PacketId).ToString("X2") + ' ' + packet.PacketId.ToString());
                if(_PacketDumping)
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
