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
    public class FireShoe : ChipObject, IPickUpAble
    {
        public FireShoe() : base(Objects.FIRE_SHOE)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            PickUp();
            return base.MovingTo(entity);
        }

        public void PickUp()
        {
            this.ChangeObjectInto(Objects.EMPTY);
            ChipGame.Inventory.FireShoe = true;
        }
    }
}
