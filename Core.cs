using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sambuca
{
    public static class Core
    {
        public enum Dimension : sbyte
        {
            Nether = -1,
            Overworld = 0
        }
        public enum EquipmentSlot : short
        {
            Equipped = 0,
            Helmet = 1,
            Torso = 2,
            Trousers = 3,
            Boots = 4
        }
        public enum Direction : sbyte
        {
            Y_minus = 0,
            Y_plus = 1,
            Z_minus = 2,
            Z_plus = 3,
            X_minus = 4,
            X_plus = 5
        }
        public enum DiggingStatus : sbyte
        {
            StartedDigging = 0,
            FinishedDigging = 2,
            DropItem = 4
        }
        public enum Animation : sbyte
        {
            NoAnimation = 0,
            SwingArm = 1,
            Damage = 2,
            LeaveBed = 3,
            Crouch = 104,
            UnCrouch = 105
        }
        public enum EntityAction : sbyte
        {
            Crouch = 0,
            UnCrouch = 2,
            LeaveBed = 3
        }
        public enum ObjectType : sbyte
        {
            Boats = 1,
            Minecart = 10,
            StorageCart = 11,
            PoweredCart = 12,
            ActivatedTNT = 50,
            Arrow = 60,
            ThrownSnowball = 61,
            ThrownEgg = 62,
            FallingSand = 70,
            FallingGravel = 71,
            FishingFloat = 90
        }
        public enum MobType : sbyte
        {
            Creeper = 50,
            Skeleton = 51,
            Spider = 52,
            GiantZombie = 53,
            Zombie = 54,
            Slime = 55,
            Ghast = 56,
            ZombiePigman = 57,
            Pig = 90,
            Sheep = 91,
            Cow = 92,
            Chicken = 93,
            Squid = 94,
            Wolf = 95
        }
        public enum WoolColor : byte
        {
            White = 0,
            Orange = 1,
            Magenta = 2,
            LightBlue = 3,
            Yellow = 4,
            Lime = 5,
            Pink = 6,
            Gray = 7,
            LightGray = 8,
            Cyan = 9,
            Purple = 10,
            Blue = 11,
            Brown = 12,
            Green = 13,
            Red = 14,
            Black = 15
        }
        public enum EntityStateBitmask : byte
        {
            OnFire = 0x01,
            Crouched = 0x02,
            Riding = 0x04
        }
        public enum WolfStateBitmask : byte
        {
            SittingDown = 0x01,
            Agressive = 0x02,
            Tamed = 0x04
        }
        public enum PaintingDirection : int
        {
            Z_minus = 0,
            X_minus = 1,
            Z_plus = 2,
            X_plus = 3
        }
        public enum NoteBlockInstrument : sbyte
        {
            Harp = 0,
            DoubleBass = 1,
            SnareDrum = 2,
            Clicks = 3,
            BassDrum = 4
        }
        public enum NewInvalidState : sbyte
        {
            InvalidBed = 0,
            BeginRaining = 1,
            EndRaining = 2
        }
        public enum InventoryType : sbyte
        {
            Chest = 0,
            Workbench = 1,
            Furnace = 2,
            Dispenser = 3
        }
        public static readonly ConsoleColor[] ChatColors = new ConsoleColor[]{
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