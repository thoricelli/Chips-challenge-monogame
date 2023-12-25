using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Block : ChipObject
    {
        public Block() : base(Objects.BLOCK)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            this.MoveObjectInDirection(entity.Velocity);
            return true; //Depending on if it's moved or not.....
        }

        public override Objects? TileMove(Objects obj)
        {
            switch (obj)
            {
                case Objects.WATER:
                    InGameState.audioPlayer.PlaySoundEffect(Audio.Enums.SoundEffects.SPLASH);
                    return Objects.DIRT;
                case Objects.TELEPORT_BUTTON:
                    return code;
                case Objects.BOMB:
                    return Objects.EMPTY;
            }
            return base.TileMove(obj);
        }
    }
}
