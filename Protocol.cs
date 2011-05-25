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
            string s = "";
            short len = ReadShort(stream);
            for(int i = 0; i < len; i++)
                s += (char)ReadShort(stream);
            return s;
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
            byte[] data = new byte[s.Length * 2];
            for(int i = 0; i < s.Length; i++)
            {
                byte[] b = WriteShort((short)s[i]);
                data[i * 2] = b[0];
                data[i * 2 + 1] = b[1];
            }
            return data;
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
