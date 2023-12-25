using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Interfaces
{
    internal interface IMusicPlayable
    {
        public void PlayMusic();
        public void StopMusic();
        public void AddMusic(Song music);
        public void NextSong();
    }
}
