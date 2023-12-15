using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class WaterShoe : ChipObject
    {
        public WaterShoe() : base(Objects.WATER_SHOE)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            this.ChangeObjectInto(Objects.EMPTY);
            ChipGame.Inventory.WaterShoe = true;
            return base.MovingTo(entity);
        }
    }
}
