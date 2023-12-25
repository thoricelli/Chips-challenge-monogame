using CHIPS_CHALLENGE.Classes.Audio.Enums;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Interfaces
{
    public interface ISoundEffectPlayable
    {
        public void PlaySoundEffect(SoundEffects soundEffect);
        public void AddSoundEffect(SoundEffect effect, SoundEffects soundEffect);
    }
}
