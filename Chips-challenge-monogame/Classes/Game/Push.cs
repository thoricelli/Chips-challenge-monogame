using CHIPS_CHALLENGE.Classes.Game.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Game
{
    public class Push
    {
        public Vector2 Velocity;
        public Vector2 QueuedMove;
        public PushType Type;

        public Push(Vector2 velocity, PushType type)
        {
            Velocity = velocity;
            Type = type;
        }
    }
}
