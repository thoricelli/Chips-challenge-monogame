using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Enemy : Entity
    {
        public Enemy(Objects code, Vector2 position) : base(code)
        {
            this.Position = position;
        }

        //Update enemy movement
        public virtual void Update()
        {

        }
        public override void LoadSprite()
        {
            this.Sprite = new Sprite(CHIP.spritesheet, 4, (int)Code);
        }
    }
}
