using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sambuca
{
    public class Player
    {
        private int _EntityId;
        private double _X, _Y, _Z, _Stance;
        private float _Yaw, _Pitch;
        private bool _OnGround;
        public int EntityId { get { return _EntityId; } set { _EntityId = value; } }
        public double X { get { return _X; } set { _X = value; } }
        public double Y { get { return _Y; } set { _Y = value; } }
        public double Z { get { return _Z; } set { _Z = value; } }
        public double Stance { get { return _Stance; } set { _Stance = value; } }
        public float Yaw { get { return _Yaw; } set { _Yaw = value; } }
        public float Pitch { get { return _Pitch; } set { _Pitch = value; } }
        public bool OnGround { get { return _OnGround; } set { _OnGround = value; } }
    }
}
