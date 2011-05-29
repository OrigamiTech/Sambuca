using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sambuca
{
    public static class About
    {
        public static System.Reflection.AssemblyName AssemblyName
        { get { return System.Reflection.Assembly.GetAssembly(typeof(About)).GetName(); } }
    }
}
