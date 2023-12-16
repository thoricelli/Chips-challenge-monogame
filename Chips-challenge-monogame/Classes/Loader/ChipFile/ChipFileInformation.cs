using CHIPS_CHALLENGE.Classes.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile
{
    public class ChipFileInformation
    {
        public ushort NumberOfLevels { get; set; }

        public ushort LevelNumber { get; set; }
        public ushort Time { get; set; }
        public ushort ChipsToPickUp { get; set; }
        public string MapTitle { get; set; }
        public string Password { get; set; }
        public string HintText { get; set; }
        public List<Trap> Traps { get; set; } = new List<Trap>();
        public List<CloneMachine> CloneMachines { get; set; } = new List<CloneMachine>();
        //Enemies are in ChipGame

        public List<Layer> layers = new List<Layer>();

        
    }
}
