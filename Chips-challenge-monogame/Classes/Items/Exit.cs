using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Exit : ChipObject
    {
        public Exit() : base(Objects.EXIT)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            ChipGame.LoadNext();
            return base.MovingTo(entity);
        }
    }
}
