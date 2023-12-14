using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Thief : ChipObject
    {
        public Thief() : base(Objects.THIEF)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            ChipGame.ResetAllItems();
            return base.MovingTo(entity);
        }
    }
}
