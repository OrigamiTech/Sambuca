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
        private static bool BitPatternMatch(byte b, string pattern)
        {
            if(pattern.Length != 8)
                return false;
            string input = Convert.ToString(b, 2).PadLeft(8, '0');
            for(int i = 0; i < 8; i++)
                if(input[i] != pattern[i] && pattern[i] != 'x')
                    return false;
            return true;
        }


        public static byte ReadByte(Stream stream)
        {
            return (byte)stream.ReadByte();
        }
        public static sbyte ReadSbyte(Stream stream)
        {
            return (sbyte)stream.ReadByte();
        }
        public static short ReadShort(Stream stream)
        {
            byte[] b = new byte[sizeof(short)];
            for(int i = 0; i < sizeof(short); i++)
                b[i] = (byte)stream.ReadByte();
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToInt16(ReverseByteArray(b), 0);
            return BitConverter.ToInt16(b, 0);
        }
        public static int ReadInt(Stream stream)
        {
            byte[] b = new byte[sizeof(int)];
            for(int i = 0; i < sizeof(int); i++)
                b[i] = (byte)stream.ReadByte();
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToInt32(ReverseByteArray(b), 0);
            return BitConverter.ToInt32(b, 0);
        }
        public static long ReadLong(Stream stream)
        {
            byte[] b = new byte[sizeof(long)];
            for(int i = 0; i < sizeof(long); i++)
                b[i] = (byte)stream.ReadByte();
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToInt64(ReverseByteArray(b), 0);
            return BitConverter.ToInt64(b, 0);
        }
        public static double ReadDouble(Stream stream)
        {
            byte[] b = new byte[sizeof(long)];
            for(int i = 0; i < sizeof(long); i++)
                b[i] = (byte)stream.ReadByte();
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToDouble(ReverseByteArray(b), 0);
            return BitConverter.ToDouble(b, 0);
        }
        public static float ReadFloat(Stream stream)
        {
            byte[] b = new byte[sizeof(float)];
            for(int i = 0; i < sizeof(float); i++)
                b[i] = (byte)stream.ReadByte();
            if(BitConverter.IsLittleEndian)
                return BitConverter.ToSingle(ReverseByteArray(b), 0);
            return BitConverter.ToSingle(b, 0);
        }
        public static bool ReadBool(Stream stream)
        {
            return ((byte)stream.ReadByte() & 0x01) == 0x01;
        }
        public static string ReadString16(Stream stream)
        {
            short len = ReadShort(stream);
            string s = "";
            for(int i = 0; i < len; i++)
                s += (char)ReadShort(stream);
            return s;
        }
        public static string ReadString8(Stream stream)
        {
            short len = ReadShort(stream);
            string s = "";
            for(int i = 0; i < len; i++)
            {
                byte b1 = (byte)ReadByte(stream);
                if(BitPatternMatch(b1,"0xxxxxxx"))
                    s += (char)(b1 & 0x7F);
                else if(BitPatternMatch(b1, "110xxxxx"))
                {
                    byte b2 = (byte)ReadByte(stream);
                    ushort c = 0;
                    c |= (ushort)(((ushort)(b2)) & 0x3F);
                    c |= (ushort)((((ushort)(b1)) & 0x1F) << 6);
                    s += c;
                }
                else if(BitPatternMatch(b1, "1110xxxx"))
                {
                    byte b2 = (byte)ReadByte(stream);
                    byte b3 = (byte)ReadByte(stream);
                    ushort c = 0;
                    c |= (ushort)(((ushort)(b3)) & 0x3F);
                    c |= (ushort)((((ushort)(b2)) & 0x3F) << 6);
                    c |= (ushort)((((ushort)(b1)) & 0x0F) << 12);
                    s += c;
                }
            }
            return s;
        }
        public static byte[] ReadMetadata(Stream stream)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                byte field_type;
                while((field_type = (byte)stream.ReadByte()) != 127)
                {
                    ms.WriteByte(field_type);
                    switch(field_type >> 5)
                    {
                        case 0:
                            Protocol.WriteByte(Protocol.ReadByte(stream), ms);
                            break;
                        case 1:
                            Protocol.WriteShort(Protocol.ReadShort(stream), ms);
                            break;
                        case 2:
                            Protocol.WriteInt(Protocol.ReadInt(stream), ms);
                            break;
                        case 3:
                            Protocol.WriteFloat(Protocol.ReadFloat(stream), ms);
                            break;
                        case 4:
                            Protocol.WriteString16(Protocol.ReadString16(stream), ms);
                            break;
                        case 5:
                            Protocol.WriteShort(Protocol.ReadShort(stream), ms);
                            Protocol.WriteByte(Protocol.ReadByte(stream), ms);
                            Protocol.WriteShort(Protocol.ReadShort(stream), ms);
                            break;
                        case 6:
                            Protocol.WriteInt(Protocol.ReadInt(stream), ms);
                            Protocol.WriteInt(Protocol.ReadInt(stream), ms);
                            Protocol.WriteInt(Protocol.ReadInt(stream), ms);
                            break;
                    }
                }
                return ms.GetBuffer();
            }
        }



        public static void WriteByte(byte b, Stream stream)
        {
            stream.WriteByte(b);
        }
        public static void WriteSbyte(sbyte b, Stream stream)
        {
            stream.WriteByte((byte)b);
        }
        public static void WriteShort(short s, Stream stream)
        {
            if(BitConverter.IsLittleEndian)
                stream.Write(ReverseByteArray(BitConverter.GetBytes(s)), 0, sizeof(short));
            stream.Write(BitConverter.GetBytes(s), 0, sizeof(short));
        }
        public static void WriteInt(int i, Stream stream)
        {
            if(BitConverter.IsLittleEndian)
                stream.Write(ReverseByteArray(BitConverter.GetBytes(i)), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(i), 0, sizeof(int));
        }
        public static void WriteLong(long l, Stream stream)
        {
            if(BitConverter.IsLittleEndian)
                stream.Write(ReverseByteArray(BitConverter.GetBytes(l)), 0, sizeof(long));
            stream.Write(BitConverter.GetBytes(l), 0, sizeof(long));
        }
        public static void WriteDouble(double d, Stream stream)
        {
            if(BitConverter.IsLittleEndian)
                stream.Write(ReverseByteArray(BitConverter.GetBytes(d)), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(d), 0, sizeof(double));
        }
        public static void WriteFloat(float f, Stream stream)
        {
            if(BitConverter.IsLittleEndian)
                stream.Write(ReverseByteArray(BitConverter.GetBytes(f)), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(f), 0, sizeof(float));
        }
        public static void WriteBool(bool b, Stream stream)
        {
            stream.WriteByte((byte)(b ? 0x01 : 0x00));
        }
        public static void WriteString16(string s, Stream stream)
        {
            Protocol.WriteShort((short)(s.Length), stream);
            for(int i = 0; i < s.Length; i++)
            {
                ushort char_ = (ushort)s[i];
                stream.WriteByte((byte)(char_ >> 8));
                stream.WriteByte((byte)(char_ & 0xFF));
            }
        }
        public static void WriteString8(string s, Stream stream)
        {
            Protocol.WriteShort((short)(s.Length), stream);
            for(int i = 0; i < s.Length; i++)
            {
                ushort c = (ushort)s[i];
                if(c >= 0x0001 && c <= 0x007F)
                    stream.WriteByte((byte)(c & 0x007F));
                else if(c == 0x0000 || (c >= 0x0080 && c <= 0x07FF))
                {
                    stream.WriteByte((byte)(0xC0 | (c >> 11)));
                    stream.WriteByte((byte)(0x80 | (c & 0x003F)));
                }
                else if(c >= 0x0800 && c <= 0xFFFF)
                {
                    stream.WriteByte((byte)(0xE0 | (c >> 12)));
                    stream.WriteByte((byte)(0x80 | ((c >> 6) & 0x003F)));
                    stream.WriteByte((byte)(0x80 | (c & 0x003F)));
                }
            }
        }
    }
}
