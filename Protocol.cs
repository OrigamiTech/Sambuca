using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sambuca
{
    public static class Protocol
    {
        public static short ReadShort(byte[] b)
        {
            short s = 0;
            for(int i = 0; i < sizeof(short); i++)
            {
                s <<= 8;
                s |= b[i];
            }
            return s;
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
            int s = 0;
            for(int i = 0; i < sizeof(int); i++)
            {
                s <<= 8;
                s |= b[i];
            }
            return s;
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
            long s = 0;
            for(int i = 0; i < sizeof(long); i++)
            {
                s <<= 8;
                s |= b[i];
            }
            return s;
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
            /*byte[] b2 = new byte[b.Length];
            for(int i = 0; i < b.Length; i++)
                b2[i] = b[b.Length - i - 1];
            return BitConverter.ToDouble(b2, 0);*/
            return BitConverter.Int64BitsToDouble(ReadLong(b));
        }
        public static double ReadDouble(Stream stream)
        {
            /*byte[] b = new byte[sizeof(double)];
            for(int i = 0; i < sizeof(double); i++)
                b[b.Length - i - 1] = (byte)stream.ReadByte();
            return BitConverter.ToDouble(b, 0);*/
            return BitConverter.Int64BitsToDouble(ReadLong(stream));        // no idea if this shit works
        }
        public static float ReadFloat(byte[] b)
        {
            return BitConverter.ToSingle(b, 0);        // no idea if this shit works either
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
            return stream.ReadByte() == 0x01;
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
            byte[] b = new byte[sizeof(short)];
            for(int j = 0; j < sizeof(short); j++)
                b[j] = (byte)((s >> ((sizeof(short) - j - 1) * 8)) & 0xFF);
            return b;
        }
        public static byte[] WriteInt(int i)
        {
            byte[] b = new byte[sizeof(int)];
            for(int j = 0; j < sizeof(int); j++)
                b[j] = (byte)((i >> ((sizeof(int) - j - 1) * 8)) & 0xFF);
            return b;
        }
        public static byte[] WriteLong(long l)
        {
            byte[] b = new byte[sizeof(long)];
            for(int j = 0; j < sizeof(long); j++)
                b[j] = (byte)((l >> ((sizeof(long) - j - 1) * 8)) & 0xFF);
            return b;
        }
        public static byte[] WriteDouble(double d)
        {
            return BitConverter.GetBytes(d);
        }
        public static byte[] WriteFloat(float f)
        {
            return BitConverter.GetBytes(f);
        }
        public static byte[] WriteBool(bool b)
        {
            return new byte[] { (byte)(b ? 0x01 : 0x00) };
        }
        public static byte[] WriteString16(string s)
        {
            //return Encoding.BigEndianUnicode.GetBytes(s); 
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
