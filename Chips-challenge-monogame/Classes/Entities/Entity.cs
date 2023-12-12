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

        public Sprite Sprite { get; set; }

        protected Entity()
        {
            LoadSprite();
        }

        public abstract void LoadSprite();
        public void Kill() {
            Health = 0;
            State = State.Dead;
            //Don't draw
        }
        /// <summary>
        /// Moves the entity N tile.
        /// </summary>
        /// <param name="velocity"></param>
        public void Move(Vector2 velocity)
        {
            if (this.State != State.Dead)
            {
                Velocity += velocity;

                if (Velocity != Vector2.Zero)
                    Velocity.Normalize();

                //We should probably have a handler or something for this...
                //Idk.
                List<ChipObject> touchedObjects = ChipGame.CheckCollision(Position + (Velocity * 32));

                bool move = true; //Temp?

                foreach (ChipObject item in touchedObjects)
                {
                    if (!item.Touched(this) && move)
                        move = false;
                }

                if (move)
                    Position += (Velocity * 32);

                Velocity = Vector2.Zero;
                //CheckCollision -> Ask the game if where this entity wants to move, is possible
                //If NOT, then position wont be changed.
                //Then we look for the touched events, checkcollision should give back the item its colliding with :)
            }
        }

        /*Every entity will have a top, down, left, right sprite
          Animated will be later.
          So, why not define them here, have them programmed by the entity
          class! */
    }
}
