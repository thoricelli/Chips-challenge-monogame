using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Game
{
    public class Inventory
    {
        public ushort Blue { get; set; } = 0;
        public ushort Red { get; set; } = 0;
        public ushort Green { get; set; } = 0;
        public ushort Yellow { get; set; } = 0;
        public bool WaterShoe { get; set; } = false;
        public bool FireShoe { get; set; } = false;
        public bool IceShoe { get; set; } = false;
        public bool ForceShoe { get; set; } = false;
        public void ResetAllItems()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Yellow = 0;

            WaterShoe = false;
            FireShoe = false;
            IceShoe = false;
            ForceShoe = false;
        }
    }
}
