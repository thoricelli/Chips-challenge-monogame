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
    public class Blob : Enemy
    {
        //TODO, sentry can't die to fire...
        public Blob() 
            : base((Objects)Enemies.BLOB)
        {
        }
        public override Direction GetDirection(int tries)
        {
            Random random = new Random();
            return (Direction)random.Next(1, 5);
        }
        public override bool CanStillMove(int tries)
        {
            return tries < 10;
        }
    }
}
