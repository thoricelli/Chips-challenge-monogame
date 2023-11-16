using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Trap
    {
        public short ButtonX;
        public short ButtonY;
        public short TrapX;
        public short TrapY;
        public short UNUSED;
    }
}
