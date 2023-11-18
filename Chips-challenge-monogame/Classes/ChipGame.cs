using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using CHIPS_CHALLENGE.Classes.Sprites;

namespace CHIPS_CHALLENGE.Classes
{
    public class ChipGame
    {
        public ChipFileInformation chipInfo;

        public List<Player> Players { get; set; } = new List<Player>(); //Multiplayer is a TODO.

        public void LoadLevel()
        {
            //Use loader to load next level.
        }
        public void RestartLevel()
        {

        }
    }
}
