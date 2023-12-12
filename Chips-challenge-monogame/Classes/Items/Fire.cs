using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Fire : ChipObject
    {
        public Fire() : base(Objects.FIRE)
        {

        }

        public override bool Touched(Entity entity)
        {
            entity.Kill();
            return true;
        }
    }
}
