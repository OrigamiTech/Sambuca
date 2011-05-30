using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            UNKNOWN_1B = 0x1B,
            EntityVelocity = 0x1C,          //
            DestroyEntity = 0x1D,           //
            Entity = 0x1E,
            EntityRelativeMove = 0x1F,      //
            EntityLook = 0x20,
            EntityLookAndRelativeMove = 0x21,   //
            EntityTeleport = 0x22,          //
            EntityStatus = 0x26,            //
            AttachEntity = 0x27,
            EntityMetadata = 0x28,          //
            PreChunk = 0x32,                //
            MapChunk = 0x33,                //
            MultiBlockChange = 0x34,        //
            BlockChange = 0x35,             //
            PlayNoteBlock = 0x36,           //
            Explosion = 0x3C,
            NewInvalidState = 0x46,         //
            Weather = 0x47,
            OpenWindow = 0x64,
            CloseWindow = 0x65,
            WindowClick = 0x66,
            SetSlot = 0x67,                 //
            WindowItems = 0x68,             //
            UpdateProgressBar = 0x69,
            Transaction = 0x6A,
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
                case PacketId.EntityVelocity:
                    return EntityVelocity.Deserialize(stream);          //0x1C
                case PacketId.DestroyEntity:
                    return DestroyEntity.Deserialize(stream);           //0x1D
                case PacketId.EntityRelativeMove:
                    return EntityRelativeMove.Deserialize(stream);      //0x1F
                case PacketId.EntityLookAndRelativeMove:
                    return EntityLookAndRelativeMove.Deserialize(stream);   //0x21
                case PacketId.EntityTeleport:
                    return EntityTeleport.Deserialize(stream);          //0x22
                case PacketId.EntityStatus:
                    return EntityStatus.Deserialize(stream);            //0x26
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
                case PacketId.NewInvalidState:
                    return NewInvalidState.Deserialize(stream);         //0x46
                case PacketId.SetSlot:
                    return SetSlot.Deserialize(stream);                 //0x67
                case PacketId.WindowItems:
                    return WindowItems.Deserialize(stream);             //0x68
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
            PacketId PacketId { get; }
            byte[] Data { get; }
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
        public class KeepAlive : Packet //0x00
        {
            private const PacketId PACKET_ID = PacketId.KeepAlive;
            public PacketId PacketId { get { return PACKET_ID; } }
            public byte[] Data { get { return new byte[0]; } }
            public void Dump() { }
        }
        public class LoginRequestOutgoing : Packet //0x01
        {
            private const PacketId PACKET_ID = PacketId.LoginRequest;

            private int _ProtocolVersion;
            private string _Username;
            private long _MapSeed;
            private sbyte _Dimension;
            public int ProtocolVersion { get { return _ProtocolVersion; } set { _ProtocolVersion = value; } }
            public string Username { get { return _Username; } set { _Username = value; } }
            public long MapSeed { get { return _MapSeed; } set { _MapSeed = value; } }
            public sbyte Dimension { get { return _Dimension; } set { _Dimension = value; } }
            public LoginRequestOutgoing(int protocolversion, string username, long mapseed, sbyte dimension)
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
                        ms.Write(Protocol.WriteInt(_ProtocolVersion), 0, sizeof(int));
                        //ms.Write(Protocol.WriteShort((short)_Username.Length), 0, sizeof(short));
                        byte[] b_username = Protocol.WriteString16(_Username);
                        ms.Write(b_username, 0, b_username.Length);
                        ms.Write(Protocol.WriteLong(_MapSeed), 0, sizeof(long));
                        ms.Write(Protocol.WriteByte(_Dimension), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static LoginRequestOutgoing Deserialize(Stream stream)
            {
                int protocolversion = Protocol.ReadInt(stream);
                string username = Protocol.ReadString16(stream);
                long mapseed = Protocol.ReadLong(stream);
                sbyte dimension = Protocol.ReadByte(stream);
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
            private sbyte _Dimension;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public string Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public long MapSeed { get { return _MapSeed; } set { _MapSeed = value; } }
            public sbyte Dimension { get { return _Dimension; } set { _Dimension = value; } }
            public LoginRequestIncoming(int entityid, string unknown, long mapseed, sbyte dimension)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        //ms.Write(Protocol.WriteShort((short)_Unknown.Length), 0, sizeof(short));
                        byte[] b_unknown = Protocol.WriteString16(_Unknown);
                        ms.Write(b_unknown, 0, b_unknown.Length);
                        ms.Write(Protocol.WriteLong(_MapSeed), 0, sizeof(long));
                        ms.Write(Protocol.WriteByte(_Dimension), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static LoginRequestIncoming Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                string unknown = Protocol.ReadString16(stream);
                long mapseed = Protocol.ReadLong(stream);
                sbyte dimension = Protocol.ReadByte(stream);
                return new LoginRequestIncoming(entityid, unknown, mapseed, dimension);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
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
                        //ms.Write(Protocol.WriteShort((short)_Username.Length), 0, sizeof(short));
                        byte[] b_username = Protocol.WriteString16(_Username);
                        ms.Write(b_username, 0, b_username.Length);
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
                        //ms.Write(Protocol.WriteShort((short)_ConnectionHash.Length), 0, sizeof(short));
                        byte[] b_connectionhash = Protocol.WriteString16(_ConnectionHash);
                        ms.Write(b_connectionhash, 0, b_connectionhash.Length);
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
                Console.WriteLine("  ConnectionHash: " + _ConnectionHash);
            }
        }
        public class ChatMessage : Packet //0x03
        {
            private const PacketId PACKET_ID = PacketId.ChatMessage;

            /*public static class Colors
            {
                public const char
                    COLOR_KEYCHAR = '§';
                public const string
                    Black = "§0",
                    DarkBlue = "§1",
                    DarkGreen = "§2",
                    DarkTeal = "§3",
                    DarkRed = "§4",
                    Purple = "§5",
                    Gold = "§6",
                    Gray = "§7",
                    DarkGray = "§8",
                    Blue = "§9",
                    BrightGreen = "§a",
                    Teal = "§b",
                    Red = "§c",
                    Pink = "§d",
                    Yellow = "§e",
                    White = "§f";
            }
            public static string Rainbow(string message)
            {
                string output = "";
                string[] colors = new string[] { Colors.Red, Colors.Yellow, Colors.BrightGreen, Colors.Teal, Colors.Blue, Colors.Pink };
                for(int i = 0; i < message.Length; i++)
                    output += colors[i % colors.Length] + message[i];
                return output;
            }*/
            public static string StripColors(string message)
            {
                for(int i = 0; i < 16; i++)
                    message = message.Replace("§" + i.ToString("x1"), "");
                return message;
            }
            public static void PrintMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.White;
                for(int i = 0; i < message.Length; i++)
                    if((short)message[i] == 0x00A7)
                        Console.ForegroundColor = Protocol.ChatColors[Convert.ToInt32(message[++i].ToString(), 16)];
                    else
                        Console.Write(message[i]);
                Console.WriteLine();
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
                        //ms.Write(Protocol.WriteShort((short)_Message.Length), 0, sizeof(short)); 
                        byte[] b_message = Protocol.WriteString16(_Message);
                        ms.Write(b_message, 0, b_message.Length);
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
                /*Console.ForegroundColor = ConsoleColor.White;
                for(int i = 0; i < _Message.Length; i++)
                {
                    if((short)_Message[i] == 0x00A7)
                    {
                        //i++;
                        Console.ForegroundColor = Protocol.ChatColors[Convert.ToInt32(_Message[++i].ToString(), 16)];
                    }
                    else
                        Console.Write(_Message[i]);
                }
                Console.WriteLine();*/
                PrintMessage(_Message);
                Console.ForegroundColor = ConsoleColor.Gray;
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
                        ms.Write(Protocol.WriteLong(_Time), 0, sizeof(long));
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
            private short _Slot, _ItemId, _Unknown;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public short Slot { get { return _Slot; } set { _Slot = value; } }
            public short ItemId { get { return _ItemId; } set { _ItemId = value; } }
            public short Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public EntityEquipment(int entityid, short slot, short itemid, short unknown)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_Slot), 0, sizeof(short));
                        ms.Write(Protocol.WriteShort(_ItemId), 0, sizeof(short));
                        ms.Write(Protocol.WriteShort(_Unknown), 0, sizeof(short));
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityEquipment Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                short slot = Protocol.ReadShort(stream);
                short itemid = Protocol.ReadShort(stream);
                short unknown = Protocol.ReadShort(stream);
                return new EntityEquipment(entityid, slot, itemid, unknown);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Slot: " + _Slot);
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
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
                        ms.Write(Protocol.WriteInt(_User), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Target), 0, sizeof(int));
                        ms.Write(Protocol.WriteBool(_LeftClick), 0, sizeof(byte));
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
                        ms.Write(Protocol.WriteShort(_Health), 0, sizeof(short));
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
                        ms.Write(Protocol.WriteBool(_OnGround), 0, sizeof(short));
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
                Console.WriteLine("  OnGround: " + _OnGround);
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
                        ms.Write(Protocol.WriteDouble(_X), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Y), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Stance), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Z), 0, sizeof(double));
                        ms.Write(Protocol.WriteBool(_OnGround), 0, 1);
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
                        ms.Write(Protocol.WriteFloat(_Yaw), 0, sizeof(float));
                        ms.Write(Protocol.WriteFloat(_Pitch), 0, sizeof(float));
                        ms.Write(Protocol.WriteBool(_OnGround), 0, 1);
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
                Console.WriteLine("  Onground: " + _OnGround);
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
                        ms.Write(Protocol.WriteDouble(_X), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Y), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Stance), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Z), 0, sizeof(double));
                        ms.Write(Protocol.WriteFloat(_Yaw), 0, sizeof(float));
                        ms.Write(Protocol.WriteFloat(_Pitch), 0, sizeof(float));
                        ms.Write(Protocol.WriteBool(_OnGround), 0, 1);
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
                Console.WriteLine("  Onground: " + _OnGround);
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
                        ms.Write(Protocol.WriteDouble(_X), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Stance), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Y), 0, sizeof(double));
                        ms.Write(Protocol.WriteDouble(_Z), 0, sizeof(double));
                        ms.Write(Protocol.WriteFloat(_Yaw), 0, sizeof(float));
                        ms.Write(Protocol.WriteFloat(_Pitch), 0, sizeof(float));
                        ms.Write(Protocol.WriteBool(_OnGround), 0, 1);
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
                Console.WriteLine("  Onground: " + _OnGround);
            }
        }
        public class PlayerDigging : Packet //0x0E
        {
            private const PacketId PACKET_ID = PacketId.PlayerDigging;

            private sbyte _Status, _Y, _Face;
            private int _X, _Z;
            public sbyte Status { get { return _Status; } set { _Status = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Face { get { return _Face; } set { _Face = value; } }
            public PlayerDigging(sbyte status, int x, sbyte y, int z, sbyte face)
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
                        ms.Write(Protocol.WriteByte(_Status), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Y), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Face), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerDigging Deserialize(Stream stream)
            {
                sbyte status = Protocol.ReadByte(stream);
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadByte(stream);
                int z = Protocol.ReadInt(stream);
                sbyte face = Protocol.ReadByte(stream);
                return new PlayerDigging(status, x, y, z, face);
            }
            public void Dump()
            {
                Console.WriteLine("  Status: " + _Status);
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Face: " + _Face);
            }
        }
        public class PlayerBlockPlacement : Packet //0x0F
        {
            private const PacketId PACKET_ID = PacketId.PlayerBlockPlacement;

            private sbyte _Y, _Direction, _Amount;
            private int _X, _Z;
            private short _BlockId, _Damage;
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Direction { get { return _Direction; } set { _Direction = value; } }
            public short BlockId { get { return _BlockId; } set { _BlockId = value; } }
            public sbyte Amount { get { return _Amount; } set { _Amount = value; } }
            public short Damage { get { return _Damage; } set { _Damage = value; } }
            public PlayerBlockPlacement(int x, sbyte y, int z, sbyte direction, short blockid, sbyte amount, short damage)
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Y), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Direction), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_BlockId), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Amount), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_Damage), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayerBlockPlacement Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadByte(stream);
                int z = Protocol.ReadInt(stream);
                sbyte direction = Protocol.ReadByte(stream);
                short blockid = Protocol.ReadShort(stream);
                sbyte amount = Protocol.ReadByte(stream);
                short damage = Protocol.ReadShort(stream);
                return new PlayerBlockPlacement(x, y, z, direction, blockid, amount, damage);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Y: " + _Y);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Direction: " + _Direction);
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
                        ms.Write(Protocol.WriteShort(_SlotId), 0, sizeof(sbyte));
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_InBed), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Y), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        return ms.GetBuffer();
                    }
                }
            }
            public static UseBed Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte inbed = Protocol.ReadByte(stream);
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadByte(stream);
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
            private sbyte _Animate;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte Animate { get { return _Animate; } set { _Animate = value; } }
            public Animation(int entityid, sbyte animate)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Animate), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static Animation Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte animate = Protocol.ReadByte(stream);
                return new Animation(entityid, animate);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
                Console.WriteLine("  Animate: " + _Animate);
            }
        }
        public class EntityAction : Packet //0x13
        {
            private const PacketId PACKET_ID = PacketId.EntityAction;

            private int _EntityId;
            private sbyte _Action;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public sbyte Action { get { return _Action; } set { _Action = value; } }
            public EntityAction(int entityid, sbyte action)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Action), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityAction Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte action = Protocol.ReadByte(stream);
                return new EntityAction(entityid, action);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        //ms.Write(Protocol.WriteShort((short)_PlayerName.Length), 0, sizeof(short));
                        byte[] b_playername = Protocol.WriteString16(_PlayerName);
                        ms.Write(b_playername, 0, b_playername.Length);
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Rotation), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Pitch), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_Item), 0, sizeof(short));
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
                sbyte rotation = Protocol.ReadByte(stream);
                sbyte pitch = Protocol.ReadByte(stream);
                short item = Protocol.ReadShort(stream);
                return new NamedEntitySpawn(entityid, playername, x, y, z, rotation, pitch, item);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
                Console.WriteLine("  PlayerName: " + _PlayerName);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_Item), 0, sizeof(short));
                        ms.Write(Protocol.WriteByte(_Count), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_DamageData), 0, sizeof(short));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Rotation), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Pitch), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Roll), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static PickupSpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                short item = Protocol.ReadShort(stream);
                sbyte count = Protocol.ReadByte(stream);
                short damagedata = Protocol.ReadShort(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                sbyte rotation = Protocol.ReadByte(stream);
                sbyte pitch = Protocol.ReadByte(stream);
                sbyte roll = Protocol.ReadByte(stream);
                return new PickupSpawn(entityid, item, count, damagedata, x, y, z, rotation, pitch, roll);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
                Console.WriteLine("  Item: " + _Item);
                Console.WriteLine("  Count: " + _Count);
                Console.WriteLine("  DamageData: " + _DamageData);
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
                        ms.Write(Protocol.WriteInt(_CollectedEntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_CollectorEntityId), 0, sizeof(int));
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
            private sbyte _Type;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Type { get { return _Type; } set { _Type = value; } }
            public AddObjectVehicle(int entityid, sbyte type, int x, int y, int z)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Type), 0, sizeof(byte));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        return ms.GetBuffer();
                    }
                }
            }
            public static AddObjectVehicle Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte type = Protocol.ReadByte(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                return new AddObjectVehicle(entityid, type, x, y, z);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
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
            private sbyte _Type, _Yaw, _Pitch;
            private byte[] _Metadata;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Type { get { return _Type; } set { _Type = value; } }
            public sbyte Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public byte[] Metadata { get { return _Metadata; } set { _Metadata = value; } }
            public MobSpawn(int entityid, sbyte type, int x, int y, int z, sbyte yaw, sbyte pitch, byte[] metadata)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Type), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Yaw), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Pitch), 0, sizeof(sbyte));
                        ms.Write(_Metadata, 0, _Metadata.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static MobSpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte type = Protocol.ReadByte(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                sbyte yaw = Protocol.ReadByte(stream);
                sbyte pitch = Protocol.ReadByte(stream);
                byte[] metadata = Protocol.ReadMetadata(stream);
                return new MobSpawn(entityid, type, x, y, z, yaw, pitch, metadata);
            }
            public void Dump()
            {
                Console.WriteLine("  EntityId: " + _EntityId);
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

            private int _EntityId, _X, _Y, _Z, _Direction;
            private string _Title;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public int Direction { get { return _Direction; } set { _Direction = value; } }
            public string Title { get { return _Title; } set { _Title = value; } }
            public EntityPainting(int entityid, string title, int x, int y, int z, int direction)
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        //ms.Write(Protocol.WriteShort((short)_Title.Length), 0, sizeof(short)); 
                        byte[] b_title = Protocol.WriteString16(_Title);
                        ms.Write(b_title, 0, b_title.Length);
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Direction), 0, sizeof(int));
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
                int direction = Protocol.ReadInt(stream);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_VX), 0, sizeof(short));
                        ms.Write(Protocol.WriteShort(_VY), 0, sizeof(short));
                        ms.Write(Protocol.WriteShort(_VZ), 0, sizeof(short));
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_dX), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_dY), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_dZ), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityRelativeMove Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte dx = Protocol.ReadByte(stream);
                sbyte dy = Protocol.ReadByte(stream);
                sbyte dz = Protocol.ReadByte(stream);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_dX), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_dY), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_dZ), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Yaw), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Pitch), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityLookAndRelativeMove Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte dx = Protocol.ReadByte(stream);
                sbyte dy = Protocol.ReadByte(stream);
                sbyte dz = Protocol.ReadByte(stream);
                sbyte yaw = Protocol.ReadByte(stream);
                sbyte pitch = Protocol.ReadByte(stream);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Yaw), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Pitch), 0, sizeof(sbyte));
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
                sbyte yaw = Protocol.ReadByte(stream);
                sbyte pitch = Protocol.ReadByte(stream);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Status), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static EntityStatus Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                sbyte status = Protocol.ReadByte(stream);
                return new EntityStatus(entityid, status);
            }
            public void Dump()
            {
                Console.WriteLine("  Entity ID: " + _EntityId);
                Console.WriteLine("  Entity Status: " + _Status);
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
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.WriteByte((byte)(_Mode ? 0x01 : 0x00));
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_Y), 0, sizeof(short));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Size_X), 0, sizeof(byte));
                        ms.Write(Protocol.WriteByte(_Size_Y), 0, sizeof(byte));
                        ms.Write(Protocol.WriteByte(_Size_Z), 0, sizeof(byte));
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
                        ms.Write(Protocol.WriteInt(_Chunk_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Chunk_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_ArraySize), 0, sizeof(short));
                        for(int i = 0; i < _CoordinateArray.Length; i++)
                            ms.Write(Protocol.WriteShort(_CoordinateArray[i]), 0, sizeof(short));
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
            private sbyte _Y, _BlockType, _BlockMetadata;
            public int X { get { return _X; } set { _X = value; } }
            public sbyte Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte BlockType { get { return _BlockType; } set { _BlockType = value; } }
            public sbyte BlockMetadata { get { return _BlockMetadata; } set { _BlockMetadata = value; } }
            public BlockChange(int x, sbyte y, int z, sbyte blocktype, sbyte blockmetadata)
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Y), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_BlockType), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_BlockMetadata), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static BlockChange Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                sbyte y = Protocol.ReadByte(stream);
                int z = Protocol.ReadInt(stream);
                sbyte blocktype = Protocol.ReadByte(stream);
                sbyte blockmetadata = Protocol.ReadByte(stream);
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
            private sbyte _Instrument, _Pitch;
            public int X { get { return _X; } set { _X = value; } }
            public short Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public sbyte Instrument { get { return _Instrument; } set { _Instrument = value; } }
            public sbyte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public PlayNoteBlock(int x, short y, int z, sbyte instrument, sbyte pitch)
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_Y), 0, sizeof(short));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Instrument), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteByte(_Pitch), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static PlayNoteBlock Deserialize(Stream stream)
            {
                int x = Protocol.ReadInt(stream);
                short y = Protocol.ReadShort(stream);
                int z = Protocol.ReadInt(stream);
                sbyte instrument = Protocol.ReadByte(stream);
                sbyte pitch = Protocol.ReadByte(stream);
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
        public class NewInvalidState : Packet //0x46
        {
            private const PacketId PACKET_ID = PacketId.NewInvalidState;

            private sbyte _Reason;
            public sbyte Reason { get { return _Reason; } set { _Reason = value; } }
            public NewInvalidState(sbyte reason)
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
                        ms.Write(Protocol.WriteByte(_Reason), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static NewInvalidState Deserialize(Stream stream)
            {
                sbyte reason = Protocol.ReadByte(stream);
                return new NewInvalidState(reason);
            }
            public void Dump()
            {
                Console.Write("  Reason: " + _Reason);
                Console.WriteLine(_Reason == 0 ? " - Invalid Bed" : (_Reason == 1 ? " - Begin raining" : (_Reason == 2 ? " - End raining" : "")));
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
                        ms.Write(Protocol.WriteByte(_WindowId), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_Slot), 0, sizeof(short));
                        ms.Write(Protocol.WriteShort(_ItemID), 0, sizeof(short));
                        if(_ItemID == -1)
                            return ms.GetBuffer();
                        ms.Write(Protocol.WriteByte(_ItemCount), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_ItemUses), 0, sizeof(short));
                        return ms.GetBuffer();
                    }
                }
            }
            public static SetSlot Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadByte(stream);
                short slot = Protocol.ReadShort(stream);
                short itemid = Protocol.ReadShort(stream);
                if(itemid == -1)
                    return new SetSlot(windowid, slot, itemid, 0, 0);
                sbyte itemcount = Protocol.ReadByte(stream);
                short itemuses = Protocol.ReadShort(stream);
                return new SetSlot(windowid, slot, itemid, itemcount, itemuses);
            }
            public void Dump()
            {
                Console.WriteLine("  WindowId: " + _WindowId);
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
                        ms.Write(Protocol.WriteByte(_WindowId), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(_Count), 0, sizeof(short));
                        for(uint i = 0; i < _Payload.Length; i++)
                            ms.Write(Protocol.WriteByte(_Payload[i]), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static WindowItems Deserialize(Stream stream)
            {
                sbyte windowid = Protocol.ReadByte(stream);
                short count = Protocol.ReadShort(stream);
                MemoryStream payload = new MemoryStream();
                for(int i = 0; i < count; i++)
                {
                    short item_id = Protocol.ReadShort(stream);
                    payload.Write(Protocol.WriteShort(item_id), 0, sizeof(short));
                    if(item_id != -1)
                    {
                        sbyte item_count = Protocol.ReadByte(stream);
                        short item_uses = Protocol.ReadShort(stream);
                        payload.Write(Protocol.WriteByte(item_count), 0, sizeof(sbyte));
                        payload.Write(Protocol.WriteShort(item_uses), 0, sizeof(short));
                    }
                }
                return new WindowItems(windowid, count, payload.GetBuffer());
            }
            public void Dump()
            {
                Console.WriteLine("  WindowId: " + _WindowId);
                Console.WriteLine("  Count: " + _Count);
                Console.Write("  Payload: ");
                for(int i = 0; i < _Payload.Length; i++)
                    Console.Write(_Payload[i].ToString("X2"));
                Console.WriteLine();
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
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort(_Y), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        byte[] b_text1 = Protocol.WriteString16(_Text1);
                        byte[] b_text2 = Protocol.WriteString16(_Text2);
                        byte[] b_text3 = Protocol.WriteString16(_Text3);
                        byte[] b_text4 = Protocol.WriteString16(_Text4);
                        ms.Write(b_text1, 0, b_text1.Length);
                        ms.Write(b_text2, 0, b_text2.Length);
                        ms.Write(b_text3, 0, b_text3.Length);
                        ms.Write(b_text4, 0, b_text4.Length);
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
            private const PacketId PACKET_ID = PacketId.UpdateSign;

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
                        ms.Write(Protocol.WriteInt(_StatisticId), 0, sizeof(int));
                        ms.Write(Protocol.WriteByte(_Amount), 0, sizeof(sbyte));
                        return ms.GetBuffer();
                    }
                }
            }
            public static IncrementStatistic Deserialize(Stream stream)
            {
                int statisticid = Protocol.ReadInt(stream);
                sbyte amount = Protocol.ReadByte(stream);
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
                        byte[] b_connectionhash = Protocol.WriteString16(_Reason);
                        ms.Write(Protocol.WriteShort((short)_Reason.Length), 0, sizeof(short));
                        ms.Write(b_connectionhash, 0, b_connectionhash.Length);
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