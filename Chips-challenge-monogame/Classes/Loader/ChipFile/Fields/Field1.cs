﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields
{
    //LEVEL TIME
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Field1
    {
        public ushort Time;
    }
}
