using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Ice : ChipObject
    {
        public Ice() : base(Objects.ICE)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            //TODO!
            //Disable (input) movement

            //Wait X seconds
            Task.Delay(1000);
            //Move entity

            return base.MovingTo(entity);
        }
    }
}
