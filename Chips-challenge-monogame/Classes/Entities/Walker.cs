using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Walker : Enemy
    {
        public Walker() 
            : base((Objects)Enemies.WALKER,
                  new List<Direction> { Direction.UP })
        {
        }
        public override Direction GetDirection(int tries)
        {
            Random random = new Random();
            if (tries == 0)
                return base.GetDirection(tries);
            else
                return (Direction)random.Next(1, 5);
        }
        public override bool CanStillMove(int tries)
        {
            return tries < 10;
        }
    }
}
