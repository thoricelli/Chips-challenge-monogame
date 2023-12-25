using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class YellowDoor : ChipObject, IOpenAble
    {
        public YellowDoor() : base(Objects.YELLOW_DOOR)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            if (ChipGame.Inventory.Yellow > 0)
            {
                Open();
                return base.MovingTo(entity);
            }
            return false;
        }

        public void Open()
        {
            this.ChangeObjectInto(Objects.EMPTY);
            ChipGame.Inventory.Yellow--;
        }
    }
}
