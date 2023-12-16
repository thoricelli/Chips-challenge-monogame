using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using CHIPS_CHALLENGE.Classes.Entities.Enums;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public static class EnemyFactory
    {
        public static Enemy CreateObjectFromCode(Objects code, Vector2 position)
        {
            switch ((Enemies)code)
            {
                case Enemies.BUG:
                    return new Bug(position);
                default:
                    return new Enemy(code, position);
            }
        }
    }
}
