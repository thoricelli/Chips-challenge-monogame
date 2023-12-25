using CHIPS_CHALLENGE.Classes.Audio.Enums;
using CHIPS_CHALLENGE.Classes.Interfaces;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Audio
{
    public class AudioPlayer : ISoundEffectPlayable, IMusicPlayable, IUpdatable
    {
        private bool _playing = false;
        private List<Song> _music = new List<Song>();
        private int _musicIndex = 0;

        private float _soundEffectVolume = 0.5F;

        private Dictionary<int, SoundEffect> _soundEffects = new Dictionary<int, SoundEffect>();

        public void AddMusic(Song music)
        {
            _music.Add(music);
        }

        public void AddSoundEffect(SoundEffect effect, SoundEffects soundEffect)
        {
            _soundEffects[(int)soundEffect] = effect;
        }

        public void PlayMusic()
        {
            MediaPlayer.Play(_music[_musicIndex]);
            _playing = true;
        }

        public void PlaySoundEffect(SoundEffects soundEffect)
        {
            SoundEffect effect = _soundEffects[(int)soundEffect];
            effect.Play();
        }

        public void StopMusic()
        {
            MediaPlayer.Stop();
        }

        public void Update()
        {
            if (MediaPlayer.State == MediaState.Stopped && _playing)
            {
                NextSong();
            }
        }
        public void NextSong()
        {
            if (_musicIndex <= _music.Count-1)
            {
                _musicIndex++;
                PlayMusic();
            } else
            {
                _musicIndex = 0;
                PlayMusic();
            }
        }
    }
}
