using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Chip : ChipObject
    {
        public Chip() : base(Objects.COMPUTER_CHIP)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            this.changeInto = Objects.EMPTY;
            ChipGame.ChipPickedUp();
            return true;
        } 
    }
}
