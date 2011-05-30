using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sambuca
{
    public static class Protocol
    {
        private static byte[] ReverseByteArray(byte[] b)
        {
            byte[] b2 = new byte[b.Length];
            for(int i = 0; i < b.Length; i++)
                b2[b2.Length - 1 - i] = b[i];
            return b2;
        }
        public static sbyte ReadByte(byte[] b)
        {
            return (sbyte)b[0];
        }
        public static sbyte ReadByte(Stream stream)
        {
            return (sbyte)stream.ReadByte();
        }
        public static short ReadShort(byte[] b)
        {
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToInt16(ReverseByteArray(b), 0);
            return BitConverter.ToInt16(b, 0);
        }
        public static short ReadShort(Stream stream)
        {
            byte[] b = new byte[sizeof(short)];
            for(int i = 0; i < sizeof(short); i++)
                b[i] = (byte)stream.ReadByte();
            return ReadShort(b);
        }
        public static int ReadInt(byte[] b)
        {
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToInt32(ReverseByteArray(b), 0);
            return BitConverter.ToInt32(b, 0);
        }
        public static int ReadInt(Stream stream)
        {
            byte[] b = new byte[sizeof(int)];
            for(int i = 0; i < sizeof(int); i++)
                b[i] = (byte)stream.ReadByte();
            return ReadInt(b);
        }
        public static long ReadLong(byte[] b)
        {
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToInt64(ReverseByteArray(b), 0);
            return BitConverter.ToInt64(b, 0);
        }
        public static long ReadLong(Stream stream)
        {
            byte[] b = new byte[sizeof(long)];
            for(int i = 0; i < sizeof(long); i++)
                b[i] = (byte)stream.ReadByte();
            return ReadLong(b);
        }
        public static double ReadDouble(byte[] b)
        {
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToDouble(ReverseByteArray(b), 0);
            return BitConverter.ToDouble(b, 0);
        }
        public static double ReadDouble(Stream stream)
        {
            byte[] b = new byte[sizeof(long)];
            for(int i = 0; i < sizeof(long); i++)
                b[i] = (byte)stream.ReadByte();
            return ReadDouble(b);
        }
        public static float ReadFloat(byte[] b)
        {
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToSingle(ReverseByteArray(b), 0);
            return BitConverter.ToSingle(b, 0);
        }
        public static float ReadFloat(Stream stream)
        {
            byte[] b = new byte[sizeof(float)];
            for(int i = 0; i < sizeof(float); i++)
                b[i] = (byte)stream.ReadByte();
            return ReadFloat(b);
        }
        public static bool ReadBool(byte[] b)
        {
            return b[0] == 0x01;
        }
        public static bool ReadBool(Stream stream)
        {
            return ReadBool(new byte[] { (byte)stream.ReadByte() });
        }
        public static string ReadString16(byte[] b)
        {
            string s = "";
            for(int i = 0; i < b.Length / 2; i++)
                s += (char)ReadShort(new byte[2] { b[i * 2], b[i * 2 + 1] });
            return s;
        }
        public static string ReadString16(Stream stream)
        {
            short len = ReadShort(stream);
            byte[] b = new byte[len * sizeof(short)];
            for(int i = 0; i < b.Length; i++)
                b[i] = (byte)ReadByte(stream);
            return ReadString16(b);
        }
        public static byte[] ReadMetadata(Stream stream)
        {
            MemoryStream ms = new MemoryStream();
            /*
              let x = 0 of type byte
                 while (x = read byte from stream) does not equal 127:
                     select based on value of (x >> 5):
                         case 0: read byte from stream
                         case 1: read short from stream
                         case 2: read int from stream
                         case 3: read float from stream
                         case 4: read string from stream
                         case 5: read short, byte, short from stream; save as item stack (id, count, damage, respectively)
                         case 6: read int, int, int from stream; save as extra entity information.
                     end select
                 end while
             */
            byte field_type;
            while((field_type = (byte)stream.ReadByte()) != 127)
            {
                ms.WriteByte(field_type);
                switch(field_type >> 5)
                {
                    case 0:
                        ms.Write(Protocol.WriteByte(Protocol.ReadByte(stream)), 0, sizeof(sbyte));
                        break;
                    case 1:
                        ms.Write(Protocol.WriteShort(Protocol.ReadShort(stream)), 0, sizeof(short));
                        break;
                    case 2:
                        ms.Write(Protocol.WriteInt(Protocol.ReadInt(stream)), 0, sizeof(int));
                        break;
                    case 3:
                        ms.Write(Protocol.WriteFloat(Protocol.ReadFloat(stream)), 0, sizeof(float));
                        break;
                    case 4:
                        byte[] b_string = Protocol.WriteString16(Protocol.ReadString16(stream));
                        ms.Write(b_string, 0, b_string.Length);
                        break;
                    case 5:
                        ms.Write(Protocol.WriteShort(Protocol.ReadShort(stream)), 0, sizeof(short));
                        ms.Write(Protocol.WriteByte(Protocol.ReadByte(stream)), 0, sizeof(sbyte));
                        ms.Write(Protocol.WriteShort(Protocol.ReadShort(stream)), 0, sizeof(short));
                        break;
                    case 6:
                        ms.Write(Protocol.WriteInt(Protocol.ReadInt(stream)), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(Protocol.ReadInt(stream)), 0, sizeof(int));
                        ms.Write(Protocol.WriteInt(Protocol.ReadInt(stream)), 0, sizeof(int));
                        break;
                }
            }
            return ms.GetBuffer();
        }



        public static byte[] WriteByte(byte b)
        {
            return new byte[] { b };
        }
        public static byte[] WriteByte(sbyte b)
        {
            return new byte[] { (byte)b };
        }
        public static byte[] WriteShort(short s)
        {
            if(BitConverter.IsLittleEndian)
                return ReverseByteArray(BitConverter.GetBytes(s));
            return BitConverter.GetBytes(s);
        }
        public static byte[] WriteInt(int i)
        {
            if(BitConverter.IsLittleEndian)
                return ReverseByteArray(BitConverter.GetBytes(i));
            return BitConverter.GetBytes(i);
        }
        public static byte[] WriteLong(long l)
        {
            if(BitConverter.IsLittleEndian)
                return ReverseByteArray(BitConverter.GetBytes(l));
            return BitConverter.GetBytes(l);
        }
        public static byte[] WriteDouble(double d)
        {
            if(BitConverter.IsLittleEndian)
                return ReverseByteArray(BitConverter.GetBytes(d));
            return BitConverter.GetBytes(d);
        }
        public static byte[] WriteFloat(float f)
        {
            if(BitConverter.IsLittleEndian)
                return ReverseByteArray(BitConverter.GetBytes(f));
            return BitConverter.GetBytes(f);
        }
        public static byte[] WriteBool(bool b)
        {
            return new byte[] { (byte)(b ? 0x01 : 0x00) };
        }
        public static byte[] WriteString16(string s)
        {
            /*byte[] data = new byte[s.Length * 2 + sizeof(short)];
            byte[] len = Protocol.WriteShort((short)s.Length);
            for(int i=0;i<sizeof(short);i++)
                data[i] = len[i];
            for(int i = 0; i < s.Length; i++)
            {
                byte[] b = WriteShort((short)s[i]);
                data[i * 2 + sizeof(short)] = b[0];
                data[i * 2 + sizeof(short) + 1] = b[1];
            }
            return data;*/
            MemoryStream data = new MemoryStream();
            data.Write(Protocol.WriteShort((short)(s.Length)), 0, sizeof(short));
            for(int i = 0; i < s.Length; i++)
            {
                ushort char_ = (ushort)s[i];
                data.WriteByte((byte)(char_ >> 8));
                data.WriteByte((byte)(char_ & 0xFF));
            }
            return data.GetBuffer();
        }



        public static ConsoleColor[] ChatColors = new ConsoleColor[]{
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.White
        };
    }
}
