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
        public State State { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }

        public Sprite Sprite { get; set; }

        protected Entity()
        {
            LoadSprite();
        }

        public abstract void LoadSprite();

        /*
         TODO: Add functions for movement
         Movement is VEEERY stiff, and SLOW...
         */
    }
}
