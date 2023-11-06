using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Sprites;

namespace CHIPS_CHALLENGE.Classes
{
    public class ChipGame
    {
        public short CurrentLevel { get; set; }
        public short Timer { get; set; }
        public short ChipsNeeded { get; set; }

        public List<Layer> Layers { get; set; } = new List<Layer>()
        {
            new Layer(32, 32),
            new Layer(32, 32)
        };

        public Player Player { get; set; }

        public void LoadLevel()
        {
            //Use loader to load next level.
        }
        public void RestartLevel()
        {

        }
    }
}
