using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class GreenKey : ChipObject
    {
        public GreenKey() : base(Objects.GREEN_KEY)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            this.ChangeObjectInto(Objects.EMPTY);
            ChipGame.Inventory.Green = true;
            return base.MovingTo(entity);
        }
    }
}
