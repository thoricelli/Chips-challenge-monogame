using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public static class EnemyFactory
    {
        public static Enemy CreateObjectFromCode(Objects code, Vector2 position)
        {
            Enemy enemy;
            switch (code)
            {
                default:
                    enemy = new Enemy(position);
                    break;
            }
            return enemy;
        }
    }
}
