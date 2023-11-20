using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public abstract class Entity
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public State State { get; set; }
        public float Health { get; set; }
        public float Speed { get; set; } = 2;

        public Sprite Sprite { get; set; }

        protected Entity()
        {
            LoadSprite();
        }

        public abstract void LoadSprite();
        public void Kill() {
            Health = 0;
            State = State.Dead;
            //Remove from entities list.
        }
        public void Move(Vector2 velocity)
        {
            Velocity += velocity;

            if (Velocity != Vector2.Zero)
                Velocity.Normalize();

            Position += Velocity * Speed;
            Velocity = Vector2.Zero;
        }
    }
}
