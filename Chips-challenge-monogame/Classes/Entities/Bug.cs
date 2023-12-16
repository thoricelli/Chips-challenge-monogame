using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Bug : Enemy
    {
        public Bug(Vector2 position) : base((Objects)Enemies.BUG, position)
        {
        }
        public override void Update()
        {
            //this.AddPush()
        }
    }
}
