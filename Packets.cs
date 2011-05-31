using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Sambuca
{
    public static class Packets
    {
        public enum PacketId : byte
        {
            KeepAlive = 0x00,               //
            LoginRequest = 0x01,            //
            Handshake = 0x02,               //
            ChatMessage = 0x03,             //
            TimeUpdate = 0x04,              //
            EntityEquipment = 0x05,         //
            SpawnPosition = 0x06,           //
            UseEntity = 0x07,               //
            UpdateHealth = 0x08,            //
            Respawn = 0x09,                 //
            Player = 0x0A,                  //
            PlayerPosition = 0x0B,          //
            PlayerLook = 0x0C,              //
            PlayerPositionAndLook = 0x0D,   //
            PlayerDigging = 0x0E,           //
            PlayerBlockPlacement = 0x0F,    //
            HoldingChange = 0x10,           //
            UseBed = 0x11,                  //
            Animation = 0x12,               //
            EntityAction = 0x13,            //
            NamedEntitySpawn = 0x14,        //
            PickupSpawn = 0x15,             //
            CollectItem = 0x16,             //
            AddObjectVehicle = 0x17,        //
            MobSpawn = 0x18,                //
            EntityPainting = 0x19,          //
            UNKNOWN_1B = 0x1B,              //
            EntityVelocity = 0x1C,          //
            DestroyEntity = 0x1D,           //
            Entity = 0x1E,                  //
            EntityRelativeMove = 0x1F,      //
            EntityLook = 0x20,              //
            EntityLookAndRelativeMove = 0x21,   //
            EntityTeleport = 0x22,          //
            EntityStatus = 0x26,            //
            AttachEntity = 0x27,            //
            EntityMetadata = 0x28,          //
            PreChunk = 0x32,                //
            MapChunk = 0x33,                //
            MultiBlockChange = 0x34,        //
            BlockChange = 0x35,             //
            PlayNoteBlock = 0x36,           //
            Explosion = 0x3C,               //
            NewInvalidState = 0x46,         //
            Thunderbolt = 0x47,             //
            OpenWindow = 0x64,              //
            CloseWindow = 0x65,             //
            WindowClick = 0x66,             //
            SetSlot = 0x67,                 //
            WindowItems = 0x68,             //
            UpdateProgressBar = 0x69,       //
            Transaction = 0x6A,             //
            UpdateSign = 0x82,              //
            IncrementStatistic = 0xC8,      //
            DisconnectKick = 0xFF,          //
        }

        public static Packet Deserialize(byte packetId, Stream stream)
        {
            PacketId _packetId = (PacketId)packetId;
            switch(_packetId)
            {
                case PacketId.KeepAlive:
                    return new KeepAlive();                             //0x00
                case PacketId.LoginRequest:
                    return LoginRequestIncoming.Deserialize(stream);    //0x01
                case PacketId.Handshake:
                    return HandshakeIncoming.Deserialize(stream);       //0x02
                case PacketId.ChatMessage:
                    return ChatMessage.Deserialize(stream);             //0x03
                case PacketId.TimeUpdate:
                    return TimeUpdate.Deserialize(stream);              //0x04
                case PacketId.EntityEquipment:
                    return EntityEquipment.Deserialize(stream);         //0x05
                case PacketId.SpawnPosition:
                    return SpawnPosition.Deserialize(stream);           //0x06
                case PacketId.UseEntity:
                    return UseEntity.Deserialize(stream);               //0x07
                case PacketId.UpdateHealth:
                    return UpdateHealth.Deserialize(stream);            //0x08
                case PacketId.Respawn:
                    return new Respawn();                               //0x09
                case PacketId.Player:
                    return Player.Deserialize(stream);                  //0x0A
                case PacketId.PlayerPosition:
                    return PlayerPosition.Deserialize(stream);          //0x0B
                case PacketId.PlayerLook:
                    return PlayerLook.Deserialize(stream);              //0x0C
                case PacketId.PlayerPositionAndLook:
                    return PlayerPositionAndLookIncoming.Deserialize(stream);   //0x0D
                case PacketId.PlayerDigging:
                    return PlayerDigging.Deserialize(stream);           //0x0E
                case PacketId.PlayerBlockPlacement:
                    return PlayerBlockPlacement.Deserialize(stream);    //0x0F
                case PacketId.HoldingChange:
                    return HoldingChange.Deserialize(stream);           //0x10
                case PacketId.UseBed:
                    return UseBed.Deserialize(stream);                  //0x11
                case PacketId.Animation:
                    return Animation.Deserialize(stream);               //0x12
                case PacketId.EntityAction:
                    return EntityAction.Deserialize(stream);            //0x13
                case PacketId.NamedEntitySpawn:
                    return NamedEntitySpawn.Deserialize(stream);        //0x14
                case PacketId.PickupSpawn:
                    return PickupSpawn.Deserialize(stream);             //0x15
                case PacketId.CollectItem:
                    return CollectItem.Deserialize(stream);             //0x16
                case PacketId.AddObjectVehicle:
                    return AddObjectVehicle.Deserialize(stream);        //0x17
                case PacketId.MobSpawn:
                    return MobSpawn.Deserialize(stream);                //0x18
                case PacketId.EntityPainting:
                    return EntityPainting.Deserialize(stream);          //0x19
                case PacketId.UNKNOWN_1B:
                    return UNKNOWN_1B.Deserialize(stream);              //0x1B
                case PacketId.EntityVelocity:
                    return EntityVelocity.Deserialize(stream);          //0x1C
                case PacketId.DestroyEntity:
                    return DestroyEntity.Deserialize(stream);           //0x1D
                case PacketId.Entity:
                    return Entity.Deserialize(stream);                  //0x1E
                case PacketId.EntityRelativeMove:
                    return EntityRelativeMove.Deserialize(stream);      //0x1F
                case PacketId.EntityLook:
                    return EntityLook.Deserialize(stream);              //0x20
                case PacketId.EntityLookAndRelativeMove:
                    return EntityLookAndRelativeMove.Deserialize(stream);   //0x21
                case PacketId.EntityTeleport:
                    return EntityTeleport.Deserialize(stream);          //0x22
                case PacketId.EntityStatus:
                    return EntityStatus.Deserialize(stream);            //0x26
                case PacketId.AttachEntity:
                    return AttachEntity.Deserialize(stream);            //0x27
                case PacketId.EntityMetadata:
                    return EntityMetadata.Deserialize(stream);          //0x28
                case PacketId.PreChunk:
                    return PreChunk.Deserialize(stream);                //0x32
                case PacketId.MapChunk:
                    return MapChunk.Deserialize(stream);                //0x33
                case PacketId.MultiBlockChange:
                    return MultiBlockChange.Deserialize(stream);        //0x34
                case PacketId.BlockChange:
                    return BlockChange.Deserialize(stream);             //0x35
                case PacketId.PlayNoteBlock:
                    return PlayNoteBlock.Deserialize(stream);           //0x36
                case PacketId.Explosion:
                    return Explosion.Deserialize(stream);               //0x3C
                case PacketId.NewInvalidState:
                    return NewInvalidState.Deserialize(stream);         //0x46
                case PacketId.Thunderbolt:
                    return Thunderbolt.Deserialize(stream);             //0x47
                case PacketId.OpenWindow:
                    return OpenWindow.Deserialize(stream);              //0x64
                case PacketId.CloseWindow:
                    return CloseWindow.Deserialize(stream);             //0x65
                case PacketId.WindowClick:
                    return WindowClick.Deserialize(stream);             //0x66
                case PacketId.SetSlot:
                    return SetSlot.Deserialize(stream);                 //0x67
                case PacketId.WindowItems:
                    return WindowItems.Deserialize(stream);             //0x68
                case PacketId.UpdateProgressBar:
                    return UpdateProgressBar.Deserialize(stream);       //0x69
                case PacketId.Transaction:
                    return Transaction.Deserialize(stream);             //0x6A
                case PacketId.UpdateSign:
                    return UpdateSign.Deserialize(stream);              //0x82
                case PacketId.IncrementStatistic:
                    return IncrementStatistic.Deserialize(stream);      //0xC8
                case PacketId.DisconnectKick:
                    return DisconnectKick.Deserialize(stream);          //0xFF
                default:
                    return new Generic(_packetId);
            }
        }
        public interface Packet
        {
            /// <summary>
            /// The ID of the packet.
            /// </summary>
            PacketId PacketId { get; }
            /// <summary>
            /// The Payload of the packet.
            /// </summary>
            byte[] Data { get; }
            /// <summary>
            /// Dumps the packet data to the console.
            /// </summary>
            void Dump();
        }
        public class Generic : Packet
        {
            public byte[] Data { get { return new byte[0]; } }
            public PacketId PacketId { get { return PACKET_ID; } }
            private PacketId PACKET_ID = (PacketId)0;
            public Generic(PacketId packetid)
            { PACKET_ID = packetid; }
            public void Dump() { }
        }
        /// <summary>
        /// Sent by the client to keep the connection alive.
        /// </summary>
        public class KeepAlive : Packet //0x00
        {
            private const PacketId PACKET_ID = PacketId.KeepAlive;
            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data { get { return new byte[0]; } }
            public void Dump() { }
        }
        /// <summary>
        /// Sent out by the client after the handshake to connect to the server.
        /// </summary>
        public class LoginRequestOutgoing : Packet //0x01
        {
            private const PacketId PACKET_ID = PacketId.LoginRequest;

            public const int CURRENT_PROTOCOL_VERSION = 11;

            private int _ProtocolVersion;
            private string _Username;
            private long _MapSeed;
            private Core.Dimension _Dimension;
            /// <summary>
            /// Version of the protocol to use.
            /// </summary>
            public int ProtocolVersion { get { return _ProtocolVersion; } set { _ProtocolVersion = value; } }
            /// <summary>
            /// Username of the player that's connecting
            /// </summary>
            public string Username { get { return _Username; } set { _Username = value; } }
            /// <summary>
            /// This value is not required for outgoing packets
            /// </summary>
            public long MapSeed { get { return _MapSeed; } set { _MapSeed = value; } }
            /// <summary>
            /// This value is not required for outgoing packets
            /// </summary>
            public Core.Dimension Dimension { get { return _Dimension; } set { _Dimension = value; } }
            public LoginRequestOutgoing(int protocolversion, string username, long mapseed, Core.Dimension dimension)
            {
                this._ProtocolVersion = protocolversion;
                this._Username = username;
                this._MapSeed = mapseed;
                this._Dimension = dimension;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_ProtocolVersion, ms);
                        Protocol.WriteString16(_Username, ms);
                        Protocol.WriteLong(_MapSeed, ms);
                        Protocol.WriteSbyte((sbyte)_Dimension, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static LoginRequestOutgoing Deserialize(Stream stream)
            {
                int protocolversion = Protocol.ReadInt(stream);
                string username = Protocol.ReadString16(stream);
                long mapseed = Protocol.ReadLong(stream);
                Core.Dimension dimension = (Core.Dimension)Protocol.ReadSbyte(stream);
                return new LoginRequestOutgoing(protocolversion, username, mapseed, dimension);
            }
            public void Dump()
            {
                Console.WriteLine("  ProtocolVersion: " + _ProtocolVersion);
                Console.WriteLine("  Username: " + _Username);
                Console.WriteLine("  MapSeed: " + _MapSeed);
                Console.WriteLine("  Dimension: " + _Dimension.ToString());
            }
        }
        public class LoginRequestIncoming : Packet //0x01
        {
            private const PacketId PACKET_ID = PacketId.LoginRequest;

            private int _EntityId;
            private string _Unknown;
            private long _MapSeed;
            private Core.Dimension _Dimension;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public string Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public long MapSeed { get { return _MapSeed; } set { _MapSeed = value; } }
            public Core.Dimension Dimension { get { return _Dimension; } set { _Dimension = value; } }
            public LoginRequestIncoming(int entityid, string unknown, long mapseed, Core.Dimension dimension)
            {
                this._EntityId = entityid;
                this._Unknown = unknown;
                this._MapSeed = mapseed;
                this._Dimension = dimension;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteString16(_Unknown, ms);
                        Protocol.WriteLong(_MapSeed, ms);
                        Protocol.WriteSbyte((sbyte)_Dimension, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static LoginRequestIncoming Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                string unknown = Protocol.ReadString16(stream);
                long mapseed = Protocol.ReadLong(stream);
                Core.Dimension dimension = (Core.Dimension)Protocol.ReadSbyte(stream);
                return new LoginRequestIncoming(entityid, unknown, mapseed, dimension);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Unknown: " + _Unknown);
                Console.WriteLine("  MapSeed: " + _MapSeed);
                Console.WriteLine("  Dimension: " + _Dimension.ToString());
            }
        }
        public class HandshakeOutgoing : Packet //0x02
        {
            private const PacketId PACKET_ID = PacketId.Handshake;

            private string _Username;
            public string Username { get { return _Username; } set { _Username = value; } }
            public HandshakeOutgoing(string username)
            {
                this._Username = username;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteString16(_Username, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static HandshakeOutgoing Deserialize(Stream stream)
            {
                string username = Protocol.ReadString16(stream);
                return new HandshakeOutgoing(username);
            }
            public void Dump()
            {
                Console.WriteLine("  Username: " + _Username);
            }
        }
        public class HandshakeIncoming : Packet //0x02
        {
            private const PacketId PACKET_ID = PacketId.Handshake;

            private string _ConnectionHash;
            public string ConnectionHash { get { return _ConnectionHash; } set { _ConnectionHash = value; } }
            public HandshakeIncoming(string connectionhash)
            {
                this._ConnectionHash = connectionhash;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteString16(_ConnectionHash, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static HandshakeIncoming Deserialize(Stream stream)
            {
                string connectionhash = Protocol.ReadString16(stream);
                return new HandshakeIncoming(connectionhash);
            }
            public void Dump()
            {
                Console.WriteLine("  Connection Hash: " + _ConnectionHash);
            }
        }
        public class ChatMessage : Packet //0x03
        {
            private const PacketId PACKET_ID = PacketId.ChatMessage;

            public static string StripColors(string message)
            {
                for(int i = 0; i < 16; i++)
                    message = message.Replace("§" + i.ToString("x1"), "");
                return message;
            }
            public static void PrintMessage(string message)
            {
                ConsoleColor initialForegroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                for(int i = 0; i < message.Length; i++)
                    if((short)message[i] == 0x00A7)
                        Console.ForegroundColor = Core.ChatColors[Convert.ToInt32(message[++i].ToString(), 16)];
                    else
                        Console.Write(message[i]);
                Console.WriteLine();
                Console.ForegroundColor = initialForegroundColor;
            }

            private string _Message;
            public string Message { get { return _Message; } set { _Message = value; } }
            public ChatMessage(string message)
            {
                this._Message = message;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteString16(_Message, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static ChatMessage Deserialize(Stream stream)
            {
                string message = Protocol.ReadString16(stream);
                return new ChatMessage(message);
            }
            public void Dump()
            {
                Console.WriteLine("  Raw Message: " + _Message);
                Console.Write("  Colored Message: ");
                PrintMessage(_Message);
            }
        }
        public class TimeUpdate : Packet //0x04
        {
            private const PacketId PACKET_ID = PacketId.TimeUpdate;

            private long _Time;
            public long Time { get { return _Time; } set { _Time = value; } }
            public TimeUpdate(long time)
            {
                this._Time = time;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteLong(_Time, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static TimeUpdate Deserialize(Stream stream)
            {
                long time = Protocol.ReadLong(stream);
                return new TimeUpdate(time);
            }
            public void Dump()
            {
                Console.WriteLine("  Time: " + _Time);
            }
        }
        public class EntityEquipment : Packet //0x05
        {
            private const PacketId PACKET_ID = PacketId.EntityEquipment;

            private int _EntityId;
            private Core.EquipmentSlot _Slot;
            private short _ItemId, _Unknown;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public Core.EquipmentSlot Slot { get { return _Slot; } set { _Slot = value; } }
            public short ItemId { get { return _ItemId; } set { _ItemId = value; } }
            public short Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public EntityEquipment(int entityid, Core.EquipmentSlot slot, short itemid, short unknown)
            {
                this._EntityId = entityid;
                this._Slot = slot;
                this._ItemId = itemid;
                this._Unknown = unknown;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteShort((short)_Slot, ms);
                        Protocol.WriteShort(_ItemId, ms);
                        Protocol.WriteShort(_Unknown, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityEquipment Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                Core.EquipmentSlot slot = (Core.EquipmentSlot)Protocol.ReadShort(stream);
                short itemid = Protocol.ReadShort(stream);
                short unknown = Protocol.ReadShort(stream);
                return new EntityEquipment(entityid, slot, itemid, unknown);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Slot: " + _Slot.ToString());
                Console.WriteLine("  Item ID: " + _ItemId);
                Console.WriteLine("  Unknown: " + _Unknown);
            }
        }
        public class SpawnPosition : Packet //0x06
        {
            private const PacketId PACKET_ID = PacketId.SpawnPosition;

            private int _X, _Y, _Z;
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public SpawnPosition(int x, int y, int z)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteInt(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static SpawnPosition Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                return new SpawnPosition(x, y, z);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
            }
        }
        public class UseEntity : Packet //0x07
        {
            private const PacketId PACKET_ID = PacketId.UseEntity;

            private int _User, _Target;
            private bool _LeftClick;
            public int User { get { return _User; } set { _User = value; } }
            public int Target { get { return _Target; } set { _Target = value; } }
            public bool LeftClick { get { return _LeftClick; } set { _LeftClick = value; } }
            public UseEntity(int user, int target, bool leftclick)
            {
                this._User = user;
                this._Target = target;
                this._LeftClick = leftclick;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_User, ms);
                        Protocol.WriteInt(_Target,ms);
                        Protocol.WriteBool(_LeftClick, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static UseEntity Deserialize(Stream stream)
            {
                int user = Protocol.ReadInt(stream);
                int target = Protocol.ReadInt(stream);
                bool leftclick = Protocol.ReadBool(stream);
                return new UseEntity(user, target, leftclick);
            }
            public void Dump()
            {
                Console.WriteLine("  User: " + _User);
                Console.WriteLine("  Target: " + _Target);
                Console.WriteLine("  Left-Click: " + _LeftClick);
            }
        }
        public class UpdateHealth : Packet //0x08
        {
            private const PacketId PACKET_ID = PacketId.UpdateHealth;

            private short _Health;
            public short Health { get { return _Health; } set { _Health = value; } }
            public UpdateHealth(short health)
            {
                this._Health = health;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteShort(_Health, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static UpdateHealth Deserialize(Stream stream)
            {
                short health = Protocol.ReadShort(stream);
                return new UpdateHealth(health);
            }
            public void Dump()
            {
                Console.WriteLine("  Health: " + _Health);
            }
        }
        public class Respawn : Packet //0x09
        {
            private const PacketId PACKET_ID = PacketId.Respawn;
            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data { get { return new byte[0]; } }
            public void Dump() { }
        }
        public class Player : Packet //0x0A
        {
            private const PacketId PACKET_ID = PacketId.Player;

            private bool _OnGround;
            public bool OnGround { get { return _OnGround; } set { _OnGround = value; } }
            public Player(bool onground)
            {
                this._OnGround = onground;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteBool(_OnGround, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static Player Deserialize(Stream stream)
            {
                bool onground = Protocol.ReadBool(stream);
                return new Player(onground);
            }
            public void Dump()
            {
                Console.WriteLine("  On Ground: " + _OnGround);
            }
        }
        public class PlayerPosition : Packet //0x0B
        {
            private const PacketId PACKET_ID = PacketId.PlayerPositionAndLook;

            private double _X, _Y, _Stance, _Z;
            private bool _OnGround;
            public double X { get { return _X; } set { _X = value; } }
            public double Y { get { return _Y; } set { _Y = value; } }
            public double Stance { get { return _Stance; } set { _Stance = value; } }
            public double Z { get { return _Z; } set { _Z = value; } }
            public bool OnGround { get { return _OnGround; } set { _OnGround = value; } }
            public PlayerPosition(double x, double y, double stance, double z, bool onground)
            {
                this._X = x;
                this._Y = y;
                this._Stance = stance;
                this._Z = z;
                this._OnGround = onground;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteDouble(_X, ms);
                        Protocol.WriteDouble(_Y, ms);
                        Protocol.WriteDouble(_Stance, ms);
                        Protocol.WriteDouble(_Z, ms);
                        Protocol.WriteBool(_OnGround, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerPosition Deserialize(Stream stream)
            {
                double x = Protocol.ReadDouble(stream);
                double y = Protocol.ReadDouble(stream);
                double stance = Protocol.ReadDouble(stream);
                double z = Protocol.ReadDouble(stream);
                bool onground = Protocol.ReadBool(stream);
                return new PlayerPosition(x, y, stance, z, onground);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Stance: " + _Stance);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Onground: " + _OnGround);
            }
        }
        public class PlayerLook : Packet //0x0C
        {
            private const PacketId PACKET_ID = PacketId.PlayerPositionAndLook;

            private float _Yaw, _Pitch;
            private bool _OnGround;
            public float Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public float Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public bool OnGround { get { return _OnGround; } set { _OnGround = value; } }
            public PlayerLook(float yaw, float pitch, bool onground)
            {
                this._Yaw = yaw;
                this._Pitch = pitch;
                this._OnGround = onground;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteFloat(_Yaw, ms);
                        Protocol.WriteFloat(_Pitch, ms);
                        Protocol.WriteBool(_OnGround, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerLook Deserialize(Stream stream)
            {
                float yaw = Protocol.ReadFloat(stream);
                float pitch = Protocol.ReadFloat(stream);
                bool onground = Protocol.ReadBool(stream);
                return new PlayerLook(yaw, pitch, onground);
            }
            public void Dump()
            {
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
                Console.WriteLine("  On Ground: " + _OnGround);
            }
        }
        public class PlayerPositionAndLookOutgoing : Packet //0x0D
        {
            private const PacketId PACKET_ID = PacketId.PlayerPositionAndLook;

            private double _X, _Y, _Stance, _Z;
            private float _Yaw, _Pitch;
            private bool _OnGround;
            public double X { get { return _X; } set { _X = value; } }
            public double Y { get { return _Y; } set { _Y = value; } }
            public double Stance { get { return _Stance; } set { _Stance = value; } }
            public double Z { get { return _Z; } set { _Z = value; } }
            public float Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public float Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public bool OnGround { get { return _OnGround; } set { _OnGround = value; } }
            public PlayerPositionAndLookOutgoing(double x, double y, double stance, double z, float yaw, float pitch, bool onground)
            {
                this._X = x;
                this._Y = y;
                this._Stance = stance;
                this._Z = z;
                this._Yaw = yaw;
                this._Pitch = pitch;
                this._OnGround = onground;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteDouble(_X, ms);
                        Protocol.WriteDouble(_Y, ms);
                        Protocol.WriteDouble(_Stance, ms);
                        Protocol.WriteDouble(_Z, ms);
                        Protocol.WriteFloat(_Yaw, ms);
                        Protocol.WriteFloat(_Pitch, ms);
                        Protocol.WriteBool(_OnGround, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerPositionAndLookOutgoing Deserialize(Stream stream)
            {
                double x = Protocol.ReadDouble(stream);
                double y = Protocol.ReadDouble(stream);
                double stance = Protocol.ReadDouble(stream);
                double z = Protocol.ReadDouble(stream);
                float yaw = Protocol.ReadFloat(stream);
                float pitch = Protocol.ReadFloat(stream);
                bool onground = Protocol.ReadBool(stream);
                return new PlayerPositionAndLookOutgoing(x, y, stance, z, yaw, pitch, onground);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Stance: " + _Stance);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
                Console.WriteLine("  On Ground: " + _OnGround);
            }
        }
        public class PlayerPositionAndLookIncoming : Packet //0x0D
        {
            private const PacketId PACKET_ID = PacketId.PlayerPositionAndLook;

            private double _X, _Stance, _Y, _Z;
            private float _Yaw, _Pitch;
            private bool _OnGround;
            public double X { get { return _X; } set { _X = value; } }
            public double Stance { get { return _Stance; } set { _Stance = value; } }
            public double Y { get { return _Y; } set { _Y = value; } }
            public double Z { get { return _Z; } set { _Z = value; } }
            public float Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public float Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public bool OnGround { get { return _OnGround; } set { _OnGround = value; } }
            public PlayerPositionAndLookIncoming(double x, double stance, double y, double z, float yaw, float pitch, bool onground)
            {
                this._X = x;
                this._Stance = stance;
                this._Y = y;
                this._Z = z;
                this._Yaw = yaw;
                this._Pitch = pitch;
                this._OnGround = onground;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteDouble(_X, ms);
                        Protocol.WriteDouble(_Stance, ms);
                        Protocol.WriteDouble(_Y, ms);
                        Protocol.WriteDouble(_Z, ms);
                        Protocol.WriteFloat(_Yaw, ms);
                        Protocol.WriteFloat(_Pitch, ms);
                        Protocol.WriteBool(_OnGround, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerPositionAndLookIncoming Deserialize(Stream stream)
            {
                double x = Protocol.ReadDouble(stream);
                double stance = Protocol.ReadDouble(stream);
                double y = Protocol.ReadDouble(stream);
                double z = Protocol.ReadDouble(stream);
                float yaw = Protocol.ReadFloat(stream);
                float pitch = Protocol.ReadFloat(stream);
                bool onground = Protocol.ReadBool(stream);
                return new PlayerPositionAndLookIncoming(x, stance, y, z, yaw, pitch, onground);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Stance: " + _Stance);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
                Console.WriteLine("  On Ground: " + _OnGround);
            }
        }
        public class PlayerDigging : Packet //0x0E
        {
            private const PacketId PACKET_ID = PacketId.PlayerDigging;

            private Core.DiggingStatus _Status;
            private sbyte _Y;
            private Core.Direction _Face;
            private int _X, _Z;
            public Core.DiggingStatus Status { get { return _Status; } set { _Status = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Core.Direction Face { get { return _Face; } set { _Face = value; } }
            public PlayerDigging(Core.DiggingStatus status, int x, sbyte y, int z, Core.Direction face)
            {
                this._Status = status;
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Face = face;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte((sbyte)_Status,ms);
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteSbyte(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        Protocol.WriteSbyte((sbyte)_Face,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerDigging Deserialize(Stream stream)
            {
                Core.DiggingStatus status = (Core.DiggingStatus )Protocol.ReadSbyte(stream);
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadSbyte(stream);
                int z = Protocol.ReadInt(stream);
                Core.Direction face = (Core.Direction)Protocol.ReadSbyte(stream);
                return new PlayerDigging(status, x, y, z, face);
            }
            public void Dump()
            {
                Console.WriteLine("  Status: " + _Status.ToString());
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Face: " + _Face.ToString());
            }
        }
        public class PlayerBlockPlacement : Packet //0x0F
        {
            private const PacketId PACKET_ID = PacketId.PlayerBlockPlacement;

            private int _X, _Z;
            private sbyte _Y, _Amount;
            private Core.Direction _Direction;
            private short _BlockId, _Damage;
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Core.Direction Direction { get { return _Direction; } set { _Direction = value; } }
            public short BlockId { get { return _BlockId; } set { _BlockId = value; } }
            public sbyte Amount { get { return _Amount; } set { _Amount = value; } }
            public short Damage { get { return _Damage; } set { _Damage = value; } }
            public PlayerBlockPlacement(int x, sbyte y, int z, Core.Direction direction, short blockid, sbyte amount, short damage)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Direction = direction;
                this._BlockId = blockid;
                this._Amount = amount;
                this._Damage = damage;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteSbyte(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        Protocol.WriteSbyte((sbyte)_Direction,ms);
                        Protocol.WriteShort(_BlockId,ms);
                        Protocol.WriteSbyte(_Amount,ms);
                        Protocol.WriteShort(_Damage,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerBlockPlacement Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadSbyte(stream);
                int z = Protocol.ReadInt(stream);
                Core.Direction direction = (Core.Direction)Protocol.ReadSbyte(stream);
                short blockid = Protocol.ReadShort(stream);
                sbyte amount = Protocol.ReadSbyte(stream);
                short damage = Protocol.ReadShort(stream);
                return new PlayerBlockPlacement(x, y, z, direction, blockid, amount, damage);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Direction: " + _Direction.ToString());
                Console.WriteLine("  Block ID: " + _BlockId);
                Console.WriteLine("  Amount: " + _Amount);
                Console.WriteLine("  Damage: " + _Damage);
            }
        }
        public class HoldingChange : Packet //0x10
        {
            private const PacketId PACKET_ID = PacketId.HoldingChange;

            private short _SlotId;
            public short SlotId { get { return _SlotId; } set { _SlotId = value; } }
            public HoldingChange(short slotid)
            {
                this._SlotId = slotid;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteShort(_SlotId,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static HoldingChange Deserialize(Stream stream)
            {
                short slotid = Protocol.ReadShort(stream);
                return new HoldingChange(slotid);
            }
            public void Dump()
            {
                Console.WriteLine("  Slot ID: " + _SlotId);
            }
        }
        public class UseBed : Packet //0x11
        {
            private const PacketId PACKET_ID = PacketId.UseBed;

            private int _EntityId, _X, _Z;
            private sbyte _InBed, _Y;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte InBed { get { return _InBed; } set { _InBed = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public UseBed(int entityid, sbyte inbed, int x, sbyte y, int z)
            {
                this._EntityId = entityid;
                this._InBed = inbed;
                this._X = x;
                this._Y = y;
                this._Z = z;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte(_InBed,ms);
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteSbyte(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static UseBed Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte inbed = Protocol.ReadSbyte(stream);
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadSbyte(stream);
                int z = Protocol.ReadInt(stream);
                return new UseBed(entityid, inbed, x, y, z);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  In Bed: " + _InBed);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
            }
        }
        public class Animation : Packet //0x12
        {
            private const PacketId PACKET_ID = PacketId.Animation;

            private int _EntityId;
            private Core.Animation _Animate;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public Core.Animation Animate { get { return _Animate; } set { _Animate = value; } }
            public Animation(int entityid, Core.Animation animate)
            {
                this._EntityId = entityid;
                this._Animate = animate;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte((sbyte)_Animate,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static Animation Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                Core.Animation animate = (Core.Animation)Protocol.ReadSbyte(stream);
                return new Animation(entityid, animate);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Animate: " + _Animate);
            }
        }
        public class EntityAction : Packet //0x13
        {
            private const PacketId PACKET_ID = PacketId.EntityAction;

            private int _EntityId;
            private Core.EntityAction _Action;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public Core.EntityAction Action { get { return _Action; } set { _Action = value; } }
            public EntityAction(int entityid, Core.EntityAction action)
            {
                this._EntityId = entityid;
                this._Action = action;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte((sbyte)_Action,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityAction Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                Core.EntityAction action = (Core.EntityAction)Protocol.ReadSbyte(stream);
                return new EntityAction(entityid, action);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Action: " + _Action);
            }
        }
        public class NamedEntitySpawn : Packet //0x14
        {
            private const PacketId PACKET_ID = PacketId.NamedEntitySpawn;

            private int _EntityId, _X, _Y, _Z;
            private string _PlayerName;
            private sbyte _Rotation, _Pitch;
            private short _Item;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public string PlayerName { get { return _PlayerName; } set { _PlayerName = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Rotation { get { return _Rotation; } set { _Rotation = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public short Item { get { return _Item; } set { _Item = value; } }
            public NamedEntitySpawn(int entityid, string playername, int x, int y, int z, sbyte rotation, sbyte pitch, short item)
            {
                this._EntityId = entityid;
                this._PlayerName = playername;
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Rotation = rotation;
                this._Pitch = pitch;
                this._Item = item;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteString16(_PlayerName, ms);
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteInt(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        Protocol.WriteSbyte(_Rotation, ms);
                        Protocol.WriteSbyte(_Pitch, ms);
                        Protocol.WriteShort(_Item, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static NamedEntitySpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                string playername = Protocol.ReadString16(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                sbyte rotation = Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                short item = Protocol.ReadShort(stream);
                return new NamedEntitySpawn(entityid, playername, x, y, z, rotation, pitch, item);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Player Name: " + _PlayerName);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Rotation: " + _Rotation);
                Console.WriteLine("  Pitch: " + _Pitch);
                Console.WriteLine("  Item: " + _Item);
            }
        }
        public class PickupSpawn : Packet //0x15
        {
            private const PacketId PACKET_ID = PacketId.PickupSpawn;

            private int _EntityId, _X, _Y, _Z;
            private short _Item, _DamageData;
            private sbyte _Count, _Rotation, _Pitch, _Roll;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public short Item { get { return _Item; } set { _Item = value; } }
            public sbyte Count { get { return _Count; } set { _Count = value; } }
            public short DamageData { get { return _DamageData; } set { _DamageData = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Rotation { get { return _Rotation; } set { _Rotation = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public sbyte Roll { get { return _Roll; } set { _Roll = value; } }
            public PickupSpawn(int entityid, short item, sbyte count, short damagedata, int x, int y, int z, sbyte rotation, sbyte pitch, sbyte roll)
            {
                this._EntityId = entityid;
                this._Item = item;
                this._Count = count;
                this._DamageData = damagedata;
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Rotation = rotation;
                this._Pitch = pitch;
                this._Roll = roll;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteShort(_Item, ms);
                        Protocol.WriteSbyte(_Count, ms);
                        Protocol.WriteShort(_DamageData, ms);
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteInt(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        Protocol.WriteSbyte(_Rotation, ms);
                        Protocol.WriteSbyte(_Pitch, ms);
                        Protocol.WriteSbyte(_Roll, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PickupSpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                short item = Protocol.ReadShort(stream);
                sbyte count = Protocol.ReadSbyte(stream);
                short damagedata = Protocol.ReadShort(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                sbyte rotation = Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                sbyte roll = Protocol.ReadSbyte(stream);
                return new PickupSpawn(entityid, item, count, damagedata, x, y, z, rotation, pitch, roll);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Item: " + _Item);
                Console.WriteLine("  Count: " + _Count);
                Console.WriteLine("  Damage Data: " + _DamageData);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Rotation: " + _Rotation);
                Console.WriteLine("  Pitch: " + _Pitch);
                Console.WriteLine("  Roll: " + _Roll);
            }
        }
        public class CollectItem : Packet //0x16
        {
            private const PacketId PACKET_ID = PacketId.CollectItem;

            private int _CollectedEntityId, _CollectorEntityId;
            public int CollectedEntityId { get { return _CollectedEntityId; } set { _CollectedEntityId = value; } }
            public int CollectorEntityId { get { return _CollectorEntityId; } set { _CollectorEntityId = value; } }
            public CollectItem(int collectedentityid, int collectorentityid)
            {
                this._CollectedEntityId = collectedentityid;
                this._CollectorEntityId = collectorentityid;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_CollectedEntityId, ms);
                        Protocol.WriteInt(_CollectorEntityId, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static CollectItem Deserialize(Stream stream)
            {
                int collectedentityid = Protocol.ReadInt(stream);
                int collectorentityid = Protocol.ReadInt(stream);
                return new CollectItem(collectedentityid, collectorentityid);
            }
            public void Dump()
            {
                Console.WriteLine("  Collected Entity ID: " + _CollectedEntityId);
                Console.WriteLine("  Collector Entity ID: " + _CollectorEntityId);
            }
        }
        public class AddObjectVehicle : Packet //0x17
        {
            private const PacketId PACKET_ID = PacketId.AddObjectVehicle;

            private int _EntityId, _X, _Y, _Z;
            private Core.ObjectType _Type;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Core.ObjectType Type { get { return _Type; } set { _Type = value; } }
            public AddObjectVehicle(int entityid, Core.ObjectType type, int x, int y, int z)
            {
                this._EntityId = entityid;
                this._Type = type;
                this._X = x;
                this._Y = y;
                this._Z = z;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte((sbyte)_Type,ms);
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteInt(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static AddObjectVehicle Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                Core.ObjectType type = (Core.ObjectType)Protocol.ReadSbyte(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                return new AddObjectVehicle(entityid, type, x, y, z);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Type: " + _Type);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
            }
        }
        public class MobSpawn : Packet //0x18
        {
            private const PacketId PACKET_ID = PacketId.MobSpawn;

            private int _EntityId, _X, _Y, _Z;
            private Core.MobType _Type;
            private sbyte _Yaw, _Pitch;
            private byte[] _Metadata;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Core.MobType Type { get { return _Type; } set { _Type = value; } }
            public sbyte Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public byte[] Metadata { get { return _Metadata; } set { _Metadata = value; } }
            public MobSpawn(int entityid, Core.MobType type, int x, int y, int z, sbyte yaw, sbyte pitch, byte[] metadata)
            {
                this._EntityId = entityid;
                this._Type = type;
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Yaw = yaw;
                this._Pitch = pitch;
                this._Metadata = metadata;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte((sbyte)_Type,ms);
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteInt(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        Protocol.WriteSbyte(_Yaw,ms);
                        Protocol.WriteSbyte(_Pitch,ms);
                        ms.Write(_Metadata, 0, _Metadata.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static MobSpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                Core.MobType type = (Core.MobType)Protocol.ReadSbyte(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                sbyte yaw = Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                byte[] metadata = Protocol.ReadMetadata(stream);
                return new MobSpawn(entityid, type, x, y, z, yaw, pitch, metadata);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Type: " + _Type);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
                Console.Write("  Metadata: ");
                for(int i = 0; i < _Metadata.Length; i++)
                    Console.Write(((byte)_Metadata[i]).ToString("X2"));
                Console.WriteLine();
            }
        }
        public class EntityPainting : Packet //0x19
        {
            private const PacketId PACKET_ID = PacketId.EntityPainting;

            private int _EntityId, _X, _Y, _Z;
            private Core.PaintingDirection _Direction;
            private string _Title;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Core.PaintingDirection Direction { get { return _Direction; } set { _Direction = value; } }
            public string Title { get { return _Title; } set { _Title = value; } }
            public EntityPainting(int entityid, string title, int x, int y, int z, Core.PaintingDirection direction)
            {
                this._EntityId = entityid;
                this._Title = title;
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Direction = direction;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteString16(_Title,ms);
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteInt(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        Protocol.WriteInt((int)_Direction,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityPainting Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                string title = Protocol.ReadString16(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                Core.PaintingDirection direction = (Core.PaintingDirection)Protocol.ReadInt(stream);
                return new EntityPainting(entityid, title, x, y, z, direction);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Title: " + _Title);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Direction: " + _Direction);
            }
        }
        public class UNKNOWN_1B : Packet //0x1B
        {
            private const PacketId PACKET_ID = PacketId.UNKNOWN_1B;

            private float _Unknown1, _Unknown2, _Unknown5, _Unknown6;
            private bool _Unknown3, _Unknown4;
            public float Unknown1 { get { return _Unknown1; } set { _Unknown1 = value; } }
            public float Unknown2 { get { return _Unknown2; } set { _Unknown2 = value; } }
            public bool Unknown3 { get { return _Unknown3; } set { _Unknown3 = value; } }
            public bool Unknown4 { get { return _Unknown4; } set { _Unknown4 = value; } }
            public float Unknown5 { get { return _Unknown5; } set { _Unknown5 = value; } }
            public float Unknown6 { get { return _Unknown6; } set { _Unknown6 = value; } }
            public UNKNOWN_1B(float unknown1, float unknown2, bool unknown3, bool unknown4, float unknown5, float unknown6)
            {
                this._Unknown1 = unknown1;
                this._Unknown2 = unknown2;
                this._Unknown3 = unknown3;
                this._Unknown4 = unknown4;
                this._Unknown5 = unknown5;
                this._Unknown6 = unknown6;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteFloat(_Unknown1, ms);
                        Protocol.WriteFloat(_Unknown2, ms);
                        Protocol.WriteBool(_Unknown3, ms);
                        Protocol.WriteBool(_Unknown4, ms);
                        Protocol.WriteFloat(_Unknown5, ms);
                        Protocol.WriteFloat(_Unknown6, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static UNKNOWN_1B Deserialize(Stream stream)
            {
                float unknown1 = Protocol.ReadFloat(stream);
                float unknown2 = Protocol.ReadFloat(stream);
                bool unknown3 = Protocol.ReadBool(stream);
                bool unknown4 = Protocol.ReadBool(stream);
                float unknown5 = Protocol.ReadFloat(stream);
                float unknown6 = Protocol.ReadFloat(stream);
                return new UNKNOWN_1B(unknown1, unknown2, unknown3, unknown4, unknown5, unknown6);
            }
            public void Dump()
            {
                Console.WriteLine("  Unknown 1: " + _Unknown1);
                Console.WriteLine("  Unknown 2: " + _Unknown2);
                Console.WriteLine("  Unknown 3: " + _Unknown3);
                Console.WriteLine("  Unknown 4: " + _Unknown4);
                Console.WriteLine("  Unknown 5: " + _Unknown5);
                Console.WriteLine("  Unknown 6: " + _Unknown6);
            }
        }
        public class EntityVelocity : Packet //0x1C
        {
            private const PacketId PACKET_ID = PacketId.EntityVelocity;

            private int _EntityId;
            private short _VX, _VY, _VZ;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public short VX { get { return _VX; } set { _VX = value; } }
            public short VY { get { return _VY; } set { _VY = value; } }
            public short VZ { get { return _VZ; } set { _VZ = value; } }
            public EntityVelocity(int entityid, short vx, short vy, short vz)
            {
                this._EntityId = entityid;
                this._VX = vx;
                this._VY = vy;
                this._VZ = vz;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteShort(_VX, ms);
                        Protocol.WriteShort(_VY,ms);
                        Protocol.WriteShort(_VZ,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityVelocity Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                short vx = Protocol.ReadShort(stream);
                short vy = Protocol.ReadShort(stream);
                short vz = Protocol.ReadShort(stream);
                return new EntityVelocity(entityid, vx, vy, vz);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  VX: " + _VX);
                Console.WriteLine("  VY: " + _VY);
                Console.WriteLine("  VZ: " + _VZ);
            }
        }
        public class DestroyEntity : Packet //0x1D
        {
            private const PacketId PACKET_ID = PacketId.DestroyEntity;

            private int _EntityId;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public DestroyEntity(int entityid)
            {
                this._EntityId = entityid;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static DestroyEntity Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                return new DestroyEntity(entityid);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
            }
        }
        public class Entity : Packet //0x1E
        {
            private const PacketId PACKET_ID = PacketId.Entity;

            private int _EntityId;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public Entity(int entityid)
            {
                this._EntityId = entityid;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static Entity Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                return new Entity(entityid);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
            }
        }
        public class EntityRelativeMove : Packet //0x1F
        {
            private const PacketId PACKET_ID = PacketId.EntityRelativeMove;

            private int _EntityId;
            private sbyte _dX, _dY, _dZ;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte dX { get { return _dX; } set { _dX = value; } }
            public sbyte dY { get { return _dY; } set { _dY = value; } }
            public sbyte dZ { get { return _dZ; } set { _dZ = value; } }
            public EntityRelativeMove(int entityid, sbyte dx, sbyte dy, sbyte dz)
            {
                this._EntityId = entityid;
                this._dX = dx;
                this._dY = dy;
                this._dZ = dz;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte(_dX,ms);
                        Protocol.WriteSbyte(_dY,ms);
                        Protocol.WriteSbyte(_dZ,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityRelativeMove Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte dx = Protocol.ReadSbyte(stream);
                sbyte dy = Protocol.ReadSbyte(stream);
                sbyte dz = Protocol.ReadSbyte(stream);
                return new EntityRelativeMove(entityid, dx, dy, dz);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  dX: " + _dX);
                Console.WriteLine("  dY: " + _dY);
                Console.WriteLine("  dZ: " + _dZ);
            }
        }
        public class EntityLook : Packet //0x20
        {
            private const PacketId PACKET_ID = PacketId.EntityLook;

            private int _EntityId;
            private sbyte _Yaw, _Pitch;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public EntityLook(int entityid, sbyte yaw, sbyte pitch)
            {
                this._EntityId = entityid;
                this._Yaw = yaw;
                this._Pitch = pitch;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte(_Yaw,ms);
                        Protocol.WriteSbyte(_Pitch,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityLook Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte yaw = Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                return new EntityLook(entityid, yaw, pitch);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
            }
        }
        public class EntityLookAndRelativeMove : Packet //0x21
        {
            private const PacketId PACKET_ID = PacketId.EntityLookAndRelativeMove;

            private int _EntityId;
            private sbyte _dX, _dY, _dZ, _Yaw, _Pitch;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte dX { get { return _dX; } set { _dX = value; } }
            public sbyte dY { get { return _dY; } set { _dY = value; } }
            public sbyte dZ { get { return _dZ; } set { _dZ = value; } }
            public sbyte Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public EntityLookAndRelativeMove(int entityid, sbyte dx, sbyte dy, sbyte dz, sbyte yaw, sbyte pitch)
            {
                this._EntityId = entityid;
                this._dX = dx;
                this._dY = dy;
                this._dZ = dz;
                this._Yaw = yaw;
                this._Pitch = pitch;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteSbyte(_dX, ms);
                        Protocol.WriteSbyte(_dY, ms);
                        Protocol.WriteSbyte(_dZ, ms);
                        Protocol.WriteSbyte(_Yaw, ms);
                        Protocol.WriteSbyte(_Pitch, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityLookAndRelativeMove Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte dx = Protocol.ReadSbyte(stream);
                sbyte dy = Protocol.ReadSbyte(stream);
                sbyte dz = Protocol.ReadSbyte(stream);
                sbyte yaw = Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                return new EntityLookAndRelativeMove(entityid, dx, dy, dz, yaw, pitch);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  dX: " + _dX);
                Console.WriteLine("  dY: " + _dY);
                Console.WriteLine("  dZ: " + _dZ);
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
            }
        }
        public class EntityTeleport : Packet //0x22
        {
            private const PacketId PACKET_ID = PacketId.EntityTeleport;

            private int _EntityId, _X, _Y, _Z;
            private sbyte _Yaw, _Pitch;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public EntityTeleport(int entityid, int x, int y, int z, sbyte yaw, sbyte pitch)
            {
                this._EntityId = entityid;
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Yaw = yaw;
                this._Pitch = pitch;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteInt(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        Protocol.WriteSbyte(_Yaw, ms);
                        Protocol.WriteSbyte(_Pitch, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityTeleport Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                sbyte yaw = Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                return new EntityTeleport(entityid, x, y, z, yaw, pitch);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Yaw: " + _Yaw);
                Console.WriteLine("  Pitch: " + _Pitch);
            }
        }
        public class EntityStatus : Packet //0x26
        {
            private const PacketId PACKET_ID = PacketId.EntityStatus;

            private int _EntityId;
            private sbyte _Status;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte Status { get { return _Status; } set { _Status = value; } }
            public EntityStatus(int entityid, sbyte status)
            {
                this._EntityId = entityid;
                this._Status= status;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        Protocol.WriteSbyte(_Status,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityStatus Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte status = Protocol.ReadSbyte(stream);
                return new EntityStatus(entityid, status);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Entity Status: " + _Status);
                Console.WriteLine();
            }
        }
        public class AttachEntity : Packet //0x27
        {
            private const PacketId PACKET_ID = PacketId.AttachEntity;

            private int _EntityId;
            private int _VehicleId;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int VehicleId { get { return _VehicleId; } set { _VehicleId = value; } }
            public AttachEntity(int entityid, int vehicleid)
            {
                this._EntityId = entityid;
                this._VehicleId = vehicleid;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteInt(_VehicleId, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static AttachEntity Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                int vehicleid = Protocol.ReadInt(stream);
                return new AttachEntity(entityid, vehicleid);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Vehicle ID: " + _VehicleId);
                Console.WriteLine();
            }
        }
        public class EntityMetadata : Packet //0x28
        {
            private const PacketId PACKET_ID = PacketId.EntityMetadata;

            private int _EntityId;
            private byte[] _Metadata;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public byte[] Metadata { get { return _Metadata; } set { _Metadata = value; } }
            public EntityMetadata(int entityid, byte[] metadata)
            {
                this._EntityId = entityid;
                this._Metadata = metadata;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId,ms);
                        ms.Write(_Metadata, 0, _Metadata.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityMetadata Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                byte[] metadata = Protocol.ReadMetadata(stream);
                return new EntityMetadata(entityid, metadata);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.Write("  Metadata: ");
                for(int i = 0; i < _Metadata.Length; i++)
                    Console.Write(((byte)_Metadata[i]).ToString("X2"));
                Console.WriteLine();
            }
        }
        public class PreChunk : Packet //0x32
        {
            private const PacketId PACKET_ID = PacketId.PreChunk;

            private int _X, _Z;
            private bool _Mode;
            public int X { get { return _X; } set { _X = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public bool Mode { get { return _Mode; } set { _Mode = value; } }
            public PreChunk(int x, int z, bool mode)
            {
                this._X = x;
                this._Z = z;
                this._Mode = mode;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X,ms);
                        Protocol.WriteInt(_Z,ms);
                        Protocol.WriteBool(_Mode, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PreChunk Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                bool mode = Protocol.ReadBool(stream);
                return new PreChunk(x, z, mode);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Mode: " + _Mode);
            }
        }
        public class MapChunk : Packet //0x33
        {
            private const PacketId PACKET_ID = PacketId.MapChunk;

            private int _X, _Z, _CompressedDataLength;
            private short _Y;
            private byte _Size_X, _Size_Y, _Size_Z;
            private byte[] _CompressedData;
            public int X { get { return _X; } set { _X = value; } }
            public short Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public byte Size_X { get { return _Size_X; } set { _Size_X = value; } }
            public byte Size_Y { get { return _Size_Y; } set { _Size_Y = value; } }
            public byte Size_Z { get { return _Size_Z; } set { _Size_Z = value; } }
            public int CompressedDataLength { get { return _CompressedDataLength; } set { _CompressedDataLength = value; } }
            public byte[] CompressedData { get { return _CompressedData; } set { _CompressedData = value; } }
            public byte[] DecompressedData
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream(_CompressedData))
                    using(GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress))
                    using(MemoryStream ms2 = new MemoryStream())
                    {
                        Decompress.CopyTo(ms2);
                        return ms2.GetBuffer();
                    }
                }
                set
                {
                    using(MemoryStream ms = new MemoryStream(value))
                    using(GZipStream Compress = new GZipStream(ms, CompressionMode.Compress))
                    using(MemoryStream ms2 = new MemoryStream())
                    {
                        Compress.CopyTo(ms2);
                        _CompressedData = ms2.GetBuffer();
                    }
                }
            }
            public MapChunk(int x, short y, int z, byte size_x, byte size_y, byte size_z, int compresseddatalength, byte[] compresseddata)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Size_X = size_x;
                this._Size_Y = size_y;
                this._Size_Z = size_z;
                this._CompressedDataLength = compresseddatalength;
                this._CompressedData = compresseddata;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteShort(_Y,ms);
                        Protocol.WriteInt(_Z,ms);
                        Protocol.WriteByte(_Size_X,ms);
                        Protocol.WriteByte(_Size_Y,ms);
                        Protocol.WriteByte(_Size_Z,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static MapChunk Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                short y = Protocol.ReadShort(stream);
                int z = Protocol.ReadInt(stream);
                byte size_x = (byte)Protocol.ReadByte(stream);
                byte size_y = (byte)Protocol.ReadByte(stream);
                byte size_z = (byte)Protocol.ReadByte(stream);
                int compresseddatalength = Protocol.ReadInt(stream);
                byte[] compresseddata = new byte[compresseddatalength];
                for(int i = 0; i < compresseddatalength; i++)
                    compresseddata[i] = (byte)Protocol.ReadByte(stream);
                return new MapChunk(x, y, z, size_x, size_y, size_z, compresseddatalength, compresseddata);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Size X: " + _Size_X);
                Console.WriteLine("  Size Y: " + _Size_Y);
                Console.WriteLine("  Size Z: " + _Size_Z);
                Console.WriteLine("  Compressed Data Length: " + _CompressedDataLength + " bytes");
                Console.WriteLine("  Predicted Raw Data Length: " + ((_Size_X + 1) * (_Size_Y + 1) * (_Size_Z + 1) * 2.5).ToString() + " bytes");
            }
        }
        public class MultiBlockChange : Packet //0x34
        {
            private const PacketId PACKET_ID = PacketId.MultiBlockChange;

            private int _Chunk_X, _Chunk_Z;
            private short _ArraySize;
            private short[] _CoordinateArray;
            private byte[] _TypeArray, _MetadataArray;
            public int Chunk_X { get { return _Chunk_X; } set { _Chunk_X = value; } }
            public int Chunk_Z { get { return _Chunk_Z; } set { _Chunk_Z = value; } }
            public short ArraySize { get { return _ArraySize; } set { _ArraySize = value; } }
            public short[] CoordinateArray { get { return _CoordinateArray; } set { _CoordinateArray = value; } }
            public byte[] TypeArray { get { return _TypeArray; } set { _TypeArray = value; } }
            public byte[] MetadataArray { get { return _MetadataArray; } set { _MetadataArray = value; } }
            public MultiBlockChange(int chunk_x, int chunk_z, short arraysize, short[] coordinatearray, byte[] typearray, byte[] metadataarray)
            {
                this._Chunk_X = chunk_x;
                this._Chunk_Z = chunk_z;
                this._ArraySize = arraysize;
                this._CoordinateArray = coordinatearray;
                this._TypeArray = typearray;
                this._MetadataArray = metadataarray;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_Chunk_X, ms);
                        Protocol.WriteInt(_Chunk_Z,ms);
                        Protocol.WriteShort(_ArraySize,ms);
                        for(int i = 0; i < _CoordinateArray.Length; i++)
                            Protocol.WriteShort(_CoordinateArray[i],ms);
                        ms.Write(_TypeArray, 0, _TypeArray.Length);
                        ms.Write(_MetadataArray, 0, _MetadataArray.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static MultiBlockChange Deserialize(Stream stream)
            {
                int chunk_x = Protocol.ReadInt(stream);
                int chunk_z = Protocol.ReadInt(stream);
                short arraysize = Protocol.ReadShort(stream);
                short[] coordinatearray = new short[arraysize];
                for(int i = 0; i < arraysize; i++)
                    coordinatearray[i] = Protocol.ReadShort(stream);
                byte[] typearray = new byte[arraysize];
                for(int i = 0; i < arraysize; i++)
                    typearray[i] = (byte)Protocol.ReadByte(stream);
                byte[] metadataarray = new byte[arraysize];
                for(int i = 0; i < arraysize; i++)
                    metadataarray[i] = (byte)Protocol.ReadByte(stream);
                return new MultiBlockChange(chunk_x, chunk_z, arraysize, coordinatearray, typearray, metadataarray);
            }
            public void Dump()
            {
                Console.WriteLine("  Chunk X: " + _Chunk_X);
                Console.WriteLine("  Chunk Z: " + _Chunk_Z);
                Console.WriteLine("  Array Size: " + _ArraySize + " bytes");
            }
        }
        public class BlockChange : Packet //0x35
        {
            private const PacketId PACKET_ID = PacketId.BlockChange;

            private int _X, _Z;
            private sbyte _Y;
            private byte _BlockType, _BlockMetadata;
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public byte BlockType { get { return _BlockType; } set { _BlockType = value; } }
            public byte BlockMetadata { get { return _BlockMetadata; } set { _BlockMetadata = value; } }
            public BlockChange(int x, sbyte y, int z, byte blocktype, byte blockmetadata)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._BlockType = blocktype;
                this._BlockMetadata = blockmetadata;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteSbyte(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        Protocol.WriteByte(_BlockType, ms);
                        Protocol.WriteByte(_BlockMetadata, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static BlockChange Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadSbyte(stream);
                int z = Protocol.ReadInt(stream);
                byte blocktype = Protocol.ReadByte(stream);
                byte blockmetadata = Protocol.ReadByte(stream);
                return new BlockChange(x, y, z, blocktype, blockmetadata);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Block Type: " + _BlockType);
                Console.WriteLine("  Block Metadata: " + _BlockMetadata);
            }
        }
        public class PlayNoteBlock : Packet //0x36
        {
            private const PacketId PACKET_ID = PacketId.PlayNoteBlock;

            private int _X, _Z;
            private short _Y;
            private Core.NoteBlockInstrument _Instrument;
            private sbyte _Pitch;
            public int X { get { return _X; } set { _X = value; } }
            public short Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Core.NoteBlockInstrument Instrument { get { return _Instrument; } set { _Instrument = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public PlayNoteBlock(int x, short y, int z, Core.NoteBlockInstrument instrument, sbyte pitch)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Instrument = instrument;
                this._Pitch = pitch;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteShort(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        Protocol.WriteSbyte((sbyte)_Instrument, ms);
                        Protocol.WriteSbyte(_Pitch, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayNoteBlock Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                short y = Protocol.ReadShort(stream);
                int z = Protocol.ReadInt(stream);
                Core.NoteBlockInstrument instrument = (Core.NoteBlockInstrument)Protocol.ReadSbyte(stream);
                sbyte pitch = Protocol.ReadSbyte(stream);
                return new PlayNoteBlock(x, y, z, instrument, pitch);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Instrument: " + _Instrument);
                Console.WriteLine("  Pitch: " + _Pitch);
            }
        }
        public class Explosion : Packet //0x3C
        {
            private const PacketId PACKET_ID = PacketId.Explosion;

            private double _X, _Y, _Z;
            private float _Unknown;
            private int _RecordCount;
            private sbyte[] _Records;
            public double X { get { return _X; } set { _X = value; } }
            public double Y { get { return _Y; } set { _Y = value; } }
            public double Z { get { return _Z; } set { _Z = value; } }
            public float Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public int RecordCount { get { return _RecordCount; } set { _RecordCount = value; } }
            public sbyte[] Records { get { return _Records; } set { _Records = value; } }
            public Explosion(double x, double y, double z, float unknown, int recordcount, sbyte[] records)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Unknown = unknown;
                this._RecordCount = recordcount;
                this._Records = records;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteDouble(_X, ms);
                        Protocol.WriteDouble(_Y, ms);
                        Protocol.WriteDouble(_Z, ms);
                        Protocol.WriteFloat(_Unknown, ms);
                        Protocol.WriteInt(_RecordCount, ms);
                        for(int i = 0; i < _Records.Length; i++)
                            Protocol.WriteSbyte(_Records[i], ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static Explosion Deserialize(Stream stream)
            {
                double x = Protocol.ReadDouble(stream);
                double y = Protocol.ReadDouble(stream);
                double z = Protocol.ReadDouble(stream);
                float unknown = Protocol.ReadFloat(stream);
                int recordcount = Protocol.ReadInt(stream);
                sbyte[] records = new sbyte[recordcount * 3];
                for(int i = 0; i < records.Length; i++)
                    records[i] = Protocol.ReadSbyte(stream);
                return new Explosion(x, y, z, unknown, recordcount, records);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Unknown: " + _Unknown);
                Console.WriteLine("  Record Count: " + _RecordCount);
            }
        }
        public class NewInvalidState : Packet //0x46
        {
            private const PacketId PACKET_ID = PacketId.NewInvalidState;

            private Core.NewInvalidState _Reason;
            public Core.NewInvalidState Reason { get { return _Reason; } set { _Reason = value; } }
            public NewInvalidState(Core.NewInvalidState reason)
            {
                this._Reason = reason;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte((sbyte)_Reason,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static NewInvalidState Deserialize(Stream stream)
            {
                Core.NewInvalidState reason = (Core.NewInvalidState)Protocol.ReadSbyte(stream);
                return new NewInvalidState(reason);
            }
            public void Dump()
            {
                Console.WriteLine("  Reason: " + _Reason);
            }
        }
        public class Thunderbolt : Packet //0x47
        {
            private const PacketId PACKET_ID = PacketId.Thunderbolt;

            private int _EntityId, _X, _Y, _Z;
            private bool _Unknown;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public bool Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public Thunderbolt(int entityid, bool unknown, int x,int y, int z)
            {
                this._EntityId = entityid;
                this._Unknown = unknown;
                this._X = x;
                this._Y = y;
                this._Z = z;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_EntityId, ms);
                        Protocol.WriteBool(_Unknown, ms);
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteInt(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static Thunderbolt Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                bool unknown = Protocol.ReadBool(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                return new Thunderbolt(entityid, unknown, x, y, z);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Unknown: " + _Unknown);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
            }
        }
        public class OpenWindow : Packet //0x64
        {
            private const PacketId PACKET_ID = PacketId.OpenWindow;

            private sbyte _WindowId, _SlotCount;
            private Core.InventoryType _InventoryType;
            private string _WindowTitle;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public Core.InventoryType InventoryType { get { return _InventoryType; } set { _InventoryType = value; } }
            public string WindowTitle { get { return _WindowTitle; } set { _WindowTitle = value; } }
            public sbyte SlotCount { get { return _SlotCount; } set { _SlotCount = value; } }
            public OpenWindow(sbyte windowid, Core.InventoryType inventorytype, string windowtitle, sbyte slotcount)
            {
                this._WindowId = windowid;
                this._InventoryType = inventorytype;
                this._WindowTitle = windowtitle;
                this._SlotCount = slotcount;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId,ms);
                        Protocol.WriteSbyte((sbyte)_InventoryType,ms);
                        Protocol.WriteString8(_WindowTitle,ms);
                        Protocol.WriteSbyte(_SlotCount,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static OpenWindow Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                Core.InventoryType inventorytype = (Core.InventoryType)Protocol.ReadSbyte(stream);
                string windowtitle = Protocol.ReadString8(stream);
                sbyte slotcount = Protocol.ReadSbyte(stream);
                return new OpenWindow(windowid, inventorytype, windowtitle, slotcount);
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
                Console.WriteLine("  Inventory Type: " + _InventoryType);
                Console.WriteLine("  Window Title: " + _WindowTitle);
                Console.WriteLine("  Slot Count: " + _SlotCount);
            }
        }
        public class CloseWindow : Packet //0x65
        {
            private const PacketId PACKET_ID = PacketId.CloseWindow;

            private sbyte _WindowId;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public CloseWindow(sbyte windowid)
            {
                this._WindowId = windowid;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static CloseWindow Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                return new CloseWindow(windowid);
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
            }
        }
        public class WindowClick : Packet //0x65
        {
            private const PacketId PACKET_ID = PacketId.WindowClick;

            private sbyte _WindowId, _RightClick, _ItemCount;
            private short _Slot, _ActionNumber, _ItemId, _ItemUses;
            private bool _Shift;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public short Slot { get { return _Slot; } set { _Slot = value; } }
            public sbyte RightClick { get { return _RightClick; } set { _RightClick = value; } }
            public short ActionNumber { get { return _ActionNumber; } set { ActionNumber = value; } }
            public bool Shift { get { return _Shift; } set { _Shift = value; } }
            public short ItemId { get { return _ItemId; } set { _ItemId = value; } }
            public sbyte ItemCount { get { return _ItemCount; } set { _ItemCount = value; } }
            public short ItemUses { get { return _ItemUses; } set { _ItemUses = value; } }
            public WindowClick(sbyte windowid,short slot, sbyte rightclick, short actionnumber, bool shift, short itemid, sbyte itemcount, short itemuses)
            {
                this._WindowId = windowid;
                this._Slot = slot;
                this._RightClick = rightclick;
                this._ActionNumber = actionnumber;
                this._Shift = shift;
                this._ItemId = itemid;
                this._ItemCount = itemcount;
                this._ItemUses = itemuses;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId, ms);
                        Protocol.WriteShort(_Slot, ms);
                        Protocol.WriteSbyte(_RightClick, ms);
                        Protocol.WriteShort(_ActionNumber, ms);
                        Protocol.WriteBool(_Shift, ms);
                        Protocol.WriteShort(_ItemId, ms);
                        if(_ItemId == -1)
                            return ms.GetBuffer();
                        Protocol.WriteSbyte(_ItemCount, ms);
                        Protocol.WriteShort(_ItemUses, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static WindowClick Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                short slot = Protocol.ReadShort(stream);
                sbyte rightclick = Protocol.ReadSbyte(stream);
                short actionnumber = Protocol.ReadShort(stream);
                bool shift = Protocol.ReadBool(stream);
                short itemid = Protocol.ReadShort(stream);
                if(itemid == -1)
                    return new WindowClick(windowid, slot, rightclick, actionnumber, shift, itemid, 0, 0);
                sbyte itemcount = Protocol.ReadSbyte(stream);
                short itemuses = Protocol.ReadShort(stream);
                return new WindowClick(windowid, slot, rightclick, actionnumber, shift, itemid, itemcount, itemuses);
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
                Console.WriteLine("  Slot: " + _Slot);
                Console.WriteLine("  RightClick: " + _RightClick);
                Console.WriteLine("  Action Number: " + _ActionNumber);
                Console.WriteLine("  Shift: " + _Shift);
                Console.WriteLine("  Item ID: " + _ItemId);
                Console.WriteLine("  Item Count: " + _ItemCount);
                Console.WriteLine("  Item Uses: " + _ItemUses);
            }
        }
        public class SetSlot : Packet //0x67
        {
            private const PacketId PACKET_ID = PacketId.SetSlot;

            private sbyte _WindowId, _ItemCount;
            private short _Slot, _ItemID, _ItemUses;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public short Slot { get { return _Slot; } set { _Slot = value; } }
            public short ItemID { get { return _ItemID; } set { _ItemID = value; } }
            public sbyte ItemCount { get { return _ItemCount; } set { _ItemCount = value; } }
            public short ItemUses { get { return _ItemUses; } set { _ItemUses = value; } }
            public SetSlot(sbyte windowid, short slot, short itemid, sbyte itemcount, short itemuses)
            {
                this._WindowId = windowid;
                this._Slot = slot;
                this._ItemID = itemid;
                this._ItemCount = itemcount;
                this._ItemUses = itemuses;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId,ms);
                        Protocol.WriteShort(_Slot, ms);
                        Protocol.WriteShort(_ItemID,ms);
                        if(_ItemID == -1)
                            return ms.GetBuffer();
                        Protocol.WriteSbyte(_ItemCount,ms);
                        Protocol.WriteShort(_ItemUses, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static SetSlot Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                short slot = Protocol.ReadShort(stream);
                short itemid = Protocol.ReadShort(stream);
                if(itemid == -1)
                    return new SetSlot(windowid, slot, itemid, 0, 0);
                sbyte itemcount = Protocol.ReadSbyte(stream);
                short itemuses = Protocol.ReadShort(stream);
                return new SetSlot(windowid, slot, itemid, itemcount, itemuses);
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
                Console.WriteLine("  Slot: " + _Slot);
                Console.WriteLine("  Item ID: " + _ItemID);
                if(_ItemID == -1)
                    return;
                Console.WriteLine("  Item Count: " + _ItemCount);
                Console.WriteLine("  Item Uses: " + _ItemUses);
            }
        }
        public class WindowItems : Packet //0x68
        {
            private const PacketId PACKET_ID = PacketId.WindowItems;

            private sbyte _WindowId;
            private short _Count;
            private byte[] _Payload;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public short Count { get { return _Count; } set { _Count = value; } }
            public byte[] Payload { get { return _Payload; } set { _Payload = value; } }
            public WindowItems(sbyte windowid, short count, byte[] payload)
            {
                this._WindowId = windowid;
                this._Count = count;
                this._Payload = payload;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId,ms);
                        Protocol.WriteShort(_Count,ms);
                        ms.Write(_Payload, 0, _Payload.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static WindowItems Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                short count = Protocol.ReadShort(stream);
                MemoryStream payload = new MemoryStream();
                for(int i = 0; i < count; i++)
                {
                    short item_id = Protocol.ReadShort(stream);
                    Protocol.WriteShort(item_id, payload);
                    if(item_id == -1)
                        continue;
                    sbyte item_count = Protocol.ReadSbyte(stream);
                    short item_uses = Protocol.ReadShort(stream);
                    Protocol.WriteSbyte(item_count, payload);
                    Protocol.WriteShort(item_uses, payload);
                }
                return new WindowItems(windowid, count, payload.GetBuffer());
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
                Console.WriteLine("  Count: " + _Count);
                Console.Write("  Payload: ");
                for(int i = 0; i < _Payload.Length; i++)
                    Console.Write(_Payload[i].ToString("X2"));
                Console.WriteLine();
            }
        }
        public class UpdateProgressBar : Packet //0x69
        {
            private const PacketId PACKET_ID = PacketId.UpdateProgressBar;

            private sbyte _WindowId;
            private short _ProgressBarId, _Value;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public short ProgressBarId { get { return _ProgressBarId; } set { _ProgressBarId = value; } }
            public short Value { get { return _Value; } set { _Value = value; } }
            public UpdateProgressBar(sbyte windowid, short progressbarid, short value)
            {
                this._WindowId = windowid;
                this._ProgressBarId = progressbarid;
                this._Value = value;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId,ms);
                        Protocol.WriteShort(_ProgressBarId,ms);
                        Protocol.WriteShort(_Value,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static UpdateProgressBar Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                short count = Protocol.ReadShort(stream);
                short payload = Protocol.ReadShort(stream);
                return new UpdateProgressBar(windowid, count, payload);
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
                Console.WriteLine("  Progress Bar ID: " + _ProgressBarId);
                Console.WriteLine("  Value: " + _Value);
                Console.WriteLine();
            }
        }
        public class Transaction : Packet //0x6A
        {
            private const PacketId PACKET_ID = PacketId.Transaction;

            private sbyte _WindowId;
            private short _ActionId;
            private bool _Accepted;
            public sbyte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public short Slot { get { return _ActionId; } set { _ActionId = value; } }
            public bool Accepted { get { return _Accepted; } set { _Accepted = value; } }
            public Transaction(sbyte windowid, short actionid, bool accepted)
            {
                this._WindowId = windowid;
                this._ActionId = actionid;
                this._Accepted = accepted;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteSbyte(_WindowId, ms);
                        Protocol.WriteShort(_ActionId,ms);
                        Protocol.WriteBool(_Accepted,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static Transaction Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadSbyte(stream);
                short actionid= Protocol.ReadShort(stream);
                bool accepted = Protocol.ReadBool(stream);
                return new Transaction(windowid, actionid, accepted);
            }
            public void Dump()
            {
                Console.WriteLine("  Window ID: " + _WindowId);
                Console.WriteLine("  Action ID: " + _ActionId);
                Console.WriteLine("  Accepted: " + _Accepted);
            }
        }
        public class UpdateSign : Packet //0x82
        {
            private const PacketId PACKET_ID = PacketId.UpdateSign;

            private int _X, _Z;
            private short _Y;
            private string _Text1, _Text2, _Text3, _Text4;
            public int X { get { return _X; } set { _X = value; } }
            public short Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public string Text1 { get { return _Text1; } set { _Text1 = value; } }
            public string Text2 { get { return _Text2; } set { _Text2 = value; } }
            public string Text3 { get { return _Text3; } set { _Text3 = value; } }
            public string Text4 { get { return _Text4; } set { _Text4 = value; } }
            public UpdateSign(int x,short y, int z, string text1, string text2, string text3, string text4)
            {
                this._X = x;
                this._Y = y;
                this._Z = z;
                this._Text1 = text1;
                this._Text2 = text2;
                this._Text3 = text3;
                this._Text4 = text4;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_X, ms);
                        Protocol.WriteShort(_Y, ms);
                        Protocol.WriteInt(_Z, ms);
                        Protocol.WriteString16(_Text1, ms);
                        Protocol.WriteString16(_Text2, ms);
                        Protocol.WriteString16(_Text3, ms);
                        Protocol.WriteString16(_Text4, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static UpdateSign Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                short y = Protocol.ReadShort(stream);
                int z = Protocol.ReadInt(stream);
                string text1 = Protocol.ReadString16(stream);
                string text2 = Protocol.ReadString16(stream);
                string text3 = Protocol.ReadString16(stream);
                string text4 = Protocol.ReadString16(stream);
                return new UpdateSign(x, y, z, text1, text2, text3, text4);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Text1: " + _Text1);
                Console.WriteLine("  Text2: " + _Text2);
                Console.WriteLine("  Text3: " + _Text3);
                Console.WriteLine("  Text4: " + _Text4);
            }
        }
        public class IncrementStatistic : Packet //0xC8
        {
            private const PacketId PACKET_ID = PacketId.IncrementStatistic;

            private int _StatisticId;
            private sbyte _Amount;
            public int StatisticId { get { return _StatisticId; } set { _StatisticId = value; } }
            public sbyte Amount { get { return _Amount; } set { _Amount = value; } }
            public IncrementStatistic(int statisticid, sbyte amount)
            {
                this._StatisticId = statisticid;
                this._Amount = amount;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteInt(_StatisticId, ms);
                        Protocol.WriteSbyte(_Amount,ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static IncrementStatistic Deserialize(Stream stream)
            {
                int statisticid = Protocol.ReadInt(stream);
                sbyte amount = Protocol.ReadSbyte(stream);
                return new IncrementStatistic(statisticid, amount);
            }
            public void Dump()
            {
                Console.WriteLine("  Statistic ID: " + _StatisticId);
                Console.WriteLine("  Amount: " + _Amount);
            }
        }
        public class DisconnectKick : Packet //0xFF
        {
            private const PacketId PACKET_ID = PacketId.DisconnectKick;

            private string _Reason;
            public string Reason { get { return _Reason; } set { _Reason = value; } }
            public DisconnectKick(string reason)
            {
                this._Reason = reason;
            }

            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data
            {
                get
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Protocol.WriteString16(_Reason, ms);
                        return ms.GetBuffer();
                    }
                }
            }
            public static DisconnectKick Deserialize(Stream stream)
            {
                string Reason = Protocol.ReadString16(stream);
                return new DisconnectKick(Reason);
            }
            public void Dump()
            {
                Console.WriteLine("  Reason: " + _Reason);
            }
        }
    }
}