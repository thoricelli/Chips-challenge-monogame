using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class RetractedButton : ChipObject, IPressable
    {
        public RetractedButton() : base(Objects.RETRACTED_BUTTON)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            Press(Vector2.Zero);
            return base.MovingTo(entity);
        }

        public Object Press(Vector2 position)
        {
            this.ChangeObjectInto(Objects.WALL);
            return null;
        }
    }
}
