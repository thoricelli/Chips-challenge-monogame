﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields
{
    //CLONING MACHINE CONTROLS
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Field5
    {
        public CloneMachine[] cloneMachines;
    }
}
