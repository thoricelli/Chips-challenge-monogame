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
    public class RedDoor : ChipObject, IOpenAble
    {
        public RedDoor() : base(Objects.RED_DOOR)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            if (ChipGame.Inventory.Red > 0)
            {
                Open();
                return base.MovingTo(entity);
            }
            return false;
        }

        public void Open()
        {
            this.ChangeObjectInto(Objects.EMPTY);
            ChipGame.Inventory.Red--;
        }
    }
}
