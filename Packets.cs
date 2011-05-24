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
            EntityEquipment = 0x05,
            SpawnPosition = 0x06,           //
            UseEntity = 0x07,
            UpdateHealth = 0x08,
            Respawn = 0x09,
            Player = 0x0A,
            PlayerPosition = 0x0B,
            PlayerLook = 0x0C,
            PlayerPositionAndLook = 0x0D,   //
            PlayerDigging = 0x0E,
            PlayerBlockPlacement = 0x0F,
            HoldingChange = 0x10,
            UseBed = 0x11,
            Animation = 0x12,
            EntityAction = 0x13,
            NamedEntitySpawn = 0x14,        // DO THIS NEXT
            PickupSpawn = 0x15,             //
            CollectItem = 0x16,
            AddObjectVehicle = 0x17,        //
            MobSpawn = 0x18,                //
            EntityPainting = 0x19,          //
            UNKNOWN_1B = 0x1B,
            EntityVelocity = 0x1C,          //
            DestroyEntity = 0x1D,
            Entity = 0x1E,
            EntityRelativeMove = 0x1F,
            EntityLook = 0x20,
            EntityLookAndRelativeMove = 0x21,
            EntityTeleport = 0x22,
            EntityStatus = 0x26,
            AttachEntity = 0x27,
            EntityMetadata = 0x28,
            PreChunk = 0x32,                //
            MapChunk = 0x33,
            MultiBlockChange = 0x34,
            BlockChange = 0x35,
            PlayNoteBlock = 0x36,
            Explosion = 0x3C,
            NewInvalidState = 0x46,         //
            Weather = 0x47,
            OpenWindow = 0x64,
            CloseWindow = 0x65,
            WindowClick = 0x66,
            SetSlot = 0x67,
            WindowItems = 0x68,             //
            UpdateProgressBar = 0x69,
            Transaction = 0x6A,
            UpdateSign = 0x82,
            IncrementStatistic = 0xC8,
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
                case PacketId.SpawnPosition:
                    return SpawnPosition.Deserialize(stream);           //0x06
                case PacketId.PlayerPositionAndLook:
                    return PlayerPositionAndLookIncoming.Deserialize(stream);   //0x0D
                case PacketId.PickupSpawn:
                    return PickupSpawn.Deserialize(stream);             //0x15
                case PacketId.AddObjectVehicle:
                    return AddObjectVehicle.Deserialize(stream);        //0x17
                case PacketId.MobSpawn:
                    return MobSpawn.Deserialize(stream);                //0x18
                case PacketId.EntityPainting:
                    return EntityPainting.Deserialize(stream);          //0x19
                case PacketId.EntityVelocity:
                    return EntityVelocity.Deserialize(stream);          //0x1C
                case PacketId.PreChunk:
                    return PreChunk.Deserialize(stream);                //0x32
                case PacketId.NewInvalidState:
                    return NewInvalidState.Deserialize(stream);         //0x46
                case PacketId.WindowItems:
                    return WindowItems.Deserialize(stream);             //0x68
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
            private byte _Dimension;
            public int ProtocolVersion { get { return _ProtocolVersion; } set { _ProtocolVersion = value; } }
            public string Username { get { return _Username; } set { _Username = value; } }
            public long MapSeed { get { return _MapSeed; } set { _MapSeed = value; } }
            public byte Dimension { get { return _Dimension; } set { _Dimension = value; } }
            public LoginRequestOutgoing(int protocolversion, string username, long mapseed, byte dimension)
            {
                this._ProtocolVersion= protocolversion;
                this._Username= username;
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
                        byte[] b_username = Protocol.WriteString16(_Username);
                        ms.Write(Protocol.WriteInt(_ProtocolVersion), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort((short)_Username.Length), 0, sizeof(short));
                        ms.Write(b_username, 0, b_username.Length);
                        ms.Write(Protocol.WriteLong(_MapSeed), 0, sizeof(long));
                        ms.WriteByte(_Dimension);
                        return ms.GetBuffer();
                    }
                }
            }
            public static LoginRequestOutgoing Deserialize(Stream stream)
            {
                int protocolversion = Protocol.ReadInt(stream);
                string username = Protocol.ReadString16(stream);
                long mapseed = Protocol.ReadLong(stream);
                byte dimension = (byte)stream.ReadByte();
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
            private byte _Dimension;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public string Unknown { get { return _Unknown; } set { _Unknown = value; } }
            public long MapSeed { get { return _MapSeed; } set { _MapSeed = value; } }
            public byte Dimension { get { return _Dimension; } set { _Dimension = value; } }
            public LoginRequestIncoming(int entityid, string unknown, long mapseed, byte dimension)
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
                        byte[] b_username = Protocol.WriteString16(_Unknown);
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
                        ms.Write(Protocol.WriteShort((short)_Unknown.Length), 0, sizeof(short));
                        ms.Write(b_username, 0, b_username.Length);
                        ms.Write(Protocol.WriteLong(_MapSeed), 0, sizeof(long));
                        ms.WriteByte(_Dimension);
                        return ms.GetBuffer();
                    }
                }
            }
            public static LoginRequestIncoming Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                string unknown = Protocol.ReadString16(stream);
                long mapseed = Protocol.ReadLong(stream);
                byte dimension = (byte)stream.ReadByte();
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
                        byte[] b_username = Protocol.WriteString16(_Username);
                        ms.Write(Protocol.WriteShort((short)_Username.Length), 0, sizeof(short));
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
                        byte[] b_connectionhash = Protocol.WriteString16(_ConnectionHash);
                        ms.Write(Protocol.WriteShort((short)_ConnectionHash.Length), 0, sizeof(short));
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

            public static class Colors
            {
                private const string COLOR_KEYCHAR = "§";
                public const string
                    Black = COLOR_KEYCHAR + "0",
                    DarkBlue = COLOR_KEYCHAR + "1",
                    DarkGreen = COLOR_KEYCHAR + "2",
                    DarkTeal = COLOR_KEYCHAR + "3",
                    DarkRed = COLOR_KEYCHAR + "4",
                    Purple = COLOR_KEYCHAR + "5",
                    Gold = COLOR_KEYCHAR + "6",
                    Gray = COLOR_KEYCHAR + "7",
                    DarkGray = COLOR_KEYCHAR + "8",
                    Blue = COLOR_KEYCHAR + "9",
                    BrightGreen = COLOR_KEYCHAR + "a",
                    Teal = COLOR_KEYCHAR + "b",
                    Red = COLOR_KEYCHAR + "c",
                    Pink = COLOR_KEYCHAR + "d",
                    Yellow = COLOR_KEYCHAR + "e",
                    White = COLOR_KEYCHAR + "f";
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
                Console.Write("  Message: ");
                Console.ForegroundColor = ConsoleColor.White;
                for(int i = 0; i < _Message.Length; i++)
                {
                    if((short)_Message[i] == 0x00A7)
                    {
                        i++;
                        Console.ForegroundColor = Protocol.ChatColors[Convert.ToInt32(_Message[i].ToString(), 16)];
                    }
                    else
                        Console.Write(_Message[i]);
                }
                Console.WriteLine();
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
        public class PlayerPositionAndLookOutgoing : Packet //0x0D
        {
            private const PacketId PACKET_ID = PacketId.PlayerPositionAndLook;

            private double _X, _Y, _Z, _Stance;
            private float _Yaw, _Pitch;
            private bool _OnGround;
            public double X { get { return _X; } set { _X = value; } }
            public double Y { get { return _Y; } set { _Y = value; } }
            public double Z { get { return _Z; } set { _Z = value; } }
            public double Stance { get { return _Stance; } set { _Stance = value; } }
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

            private double _X, _Y, _Z, _Stance;
            private float _Yaw, _Pitch;
            private bool _OnGround;
            public double X { get { return _X; } set { _X = value; } }
            public double Y { get { return _Y; } set { _Y = value; } }
            public double Z { get { return _Z; } set { _Z = value; } }
            public double Stance { get { return _Stance; } set { _Stance = value; } }
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
        public class PickupSpawn : Packet //0x15
        {
            private const PacketId PACKET_ID = PacketId.PickupSpawn;

            private int _EntityId, _X, _Y, _Z;
            private short _Item, _DamageData;
            private byte _Count, _Rotation, _Pitch, _Roll;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public short Item { get { return _Item; } set { _Item = value; } }
            public byte Count { get { return _Count; } set { _Count = value; } }
            public short DamageData { get { return _DamageData; } set { _DamageData = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public byte Rotation { get { return _Rotation; } set { _Rotation = value; } }
            public byte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public byte Roll { get { return _Roll; } set { _Roll = value; } }
            public PickupSpawn(int entityid, short type, byte count, short damagedata, int x, int y, int z, byte rotation, byte pitch, byte roll)
            {
                this._EntityId = entityid;
                this._Item = type;
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
                        ms.WriteByte(_Count);
                        ms.Write(Protocol.WriteShort(_DamageData), 0, sizeof(short));
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.WriteByte(_Rotation);
                        ms.WriteByte(_Pitch);
                        ms.WriteByte(_Roll);
                        return ms.GetBuffer();
                    }
                }
            }
            public static PickupSpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                short item = Protocol.ReadShort(stream);
                byte count = (byte)stream.ReadByte();
                short damagedata = Protocol.ReadShort(stream);
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                byte rotation = (byte)stream.ReadByte();
                byte pitch = (byte)stream.ReadByte();
                byte roll = (byte)stream.ReadByte();
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
        public class AddObjectVehicle : Packet //0x17
        {
            private const PacketId PACKET_ID = PacketId.AddObjectVehicle;

            private int _EntityId, _X, _Y, _Z;
            private byte _Type;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public byte Type { get { return _Type; } set { _Type = value; } }
            public AddObjectVehicle(int entityid, byte type, int x, int y, int z)
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
                        ms.WriteByte(_Type);
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
                byte type = (byte)stream.ReadByte();
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
            private byte _Type, _Yaw, _Pitch;
            private byte[] _Metadata;
            public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
            public int X { get { return _X; } set { _X = value; } }
            public int Y { get { return _Y; } set { _Y = value; } }
            public int Z { get { return _Z; } set { _Z = value; } }
            public byte Type { get { return _Type; } set { _Type = value; } }
            public byte Yaw { get { return _Yaw; } set { _Yaw = value; } }
            public byte Pitch { get { return _Pitch; } set { _Pitch = value; } }
            public byte[] Metadata { get { return _Metadata; } set { _Metadata = value; } }
            public MobSpawn(int entityid, byte type, int x, int y, int z, byte yaw, byte pitch, byte[] metadata)
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
                        ms.WriteByte(_Type);
                        ms.Write(Protocol.WriteInt(_X), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Y), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(_Z), 0, sizeof(int));
                        ms.WriteByte(_Yaw);
                        ms.WriteByte(_Pitch);
                        ms.Write(_Metadata, 0, _Metadata.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static MobSpawn Deserialize(Stream stream)
            {
                int entityid = Protocol.ReadInt(stream);
                byte type = (byte)stream.ReadByte();
                int x = Protocol.ReadInt(stream);
                int y = Protocol.ReadInt(stream);
                int z = Protocol.ReadInt(stream);
                byte yaw = (byte)stream.ReadByte();
                byte pitch = (byte)stream.ReadByte();
                List<byte> metadata = new List<byte>();
                byte b;
                while((b = (byte)stream.ReadByte()) != 127)
                    metadata.Add(b);
                return new MobSpawn(entityid, type, x, y, z, yaw, pitch, metadata.ToArray());
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
                    Console.Write(_Metadata[i].ToString("X2"));
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
                        byte[] b_title = Protocol.WriteString16(_Title);
                        ms.Write(Protocol.WriteInt(_EntityId), 0, sizeof(int));
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
                bool mode = (byte)stream.ReadByte() == 0x01;
                return new PreChunk(x, z, mode);
            }
            public void Dump()
            {
                Console.WriteLine("  X: " + _X);
                Console.WriteLine("  Z: " + _Z);
                Console.WriteLine("  Mode: " + _Mode);
            }
        }
        public class NewInvalidState : Packet //0x32
        {
            private const PacketId PACKET_ID = PacketId.NewInvalidState;

            private byte _Reason;
            public byte Reason { get { return _Reason; } set { _Reason= value; } }
            public NewInvalidState(byte reason)
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
                        ms.WriteByte(_Reason);
                        return ms.GetBuffer();
                    }
                }
            }
            public static NewInvalidState Deserialize(Stream stream)
            {
                byte reason = (byte)stream.ReadByte();
                return new NewInvalidState(reason);
            }
            public void Dump()
            {
                Console.Write("  Reason: " + _Reason);
                Console.WriteLine(_Reason == 0 ? " - Invalid Bed" : (_Reason == 1 ? " - Begin raining" : (_Reason == 2 ? " - End raining" : "")));
            }
        }

        public class WindowItems : Packet //0x68
        {
            private const PacketId PACKET_ID = PacketId.WindowItems;

            private byte _WindowId;
            private short _Count;
            private byte[] _Payload;
            public byte WindowId { get { return _WindowId; } set { _WindowId = value; } }
            public short Count { get { return _Count; } set { _Count = value; } }
            public byte[] Payload { get { return _Payload; } set { _Payload = value; } }
            public WindowItems(byte windowid, short count, byte[] payload)
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
                        ms.WriteByte(_WindowId);
                        ms.Write(Protocol.WriteShort(_Count), 0, sizeof(short));
                        ms.Write(_Payload, 0, _Payload.Length);
                        return ms.GetBuffer();
                    }
                }
            }
            public static WindowItems Deserialize(Stream stream)
            {
                byte windowid = (byte)stream.ReadByte();
                short count = Protocol.ReadShort(stream);
                MemoryStream payload = new MemoryStream();
                for(int i = 0; i < count; i++)
                {
                    short item_id = Protocol.ReadShort(stream);
                    payload.Write(Protocol.WriteShort(item_id), 0, sizeof(short));
                    if(item_id != -1)
                    {
                        byte item_count = (byte)stream.ReadByte();
                        short item_uses = Protocol.ReadShort(stream);
                        payload.WriteByte(item_count);
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
