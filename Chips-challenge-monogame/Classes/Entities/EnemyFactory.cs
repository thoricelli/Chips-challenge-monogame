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
            for (int i = 0; i < 4; i++)
            {
                switch ((Enemies)code-i)
                {
                    case Enemies.BUG:
                        return new Bug(position, (Facing)i);
                    case Enemies.SENTRY:
                        return new Sentry(position, (Facing)i);
                    case Enemies.BALL:
                        return new Ball(position, (Facing)i);
                }
            }
            return new Enemy(code, position, Facing.NORTH);
        }
    }
}
