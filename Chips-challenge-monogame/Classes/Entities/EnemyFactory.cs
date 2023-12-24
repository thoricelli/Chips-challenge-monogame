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
            Enemy enemy = null;
            int face = 0;
            do
            {
                switch ((Enemies)code - face)
                {
                    case Enemies.BUG:
                        enemy = new Bug();
                        break;
                    case Enemies.FIREBALL:
                        enemy = new Sentry();
                        break;
                    case Enemies.BALL:
                        enemy = new Ball();
                        break;
                    case Enemies.TANK:
                        enemy = new Tank();
                        break;
                    case Enemies.GLIDER:
                        enemy = new Rocket();
                        break;
                    case Enemies.TEETH:
                        enemy = new Teeth();
                        break;
                    case Enemies.WALKER:
                        enemy = new Walker();
                        break;
                    case Enemies.BLOB:
                        enemy = new Blob();
                        break;
                    case Enemies.PARAMECIUM:
                        //TODO!
                        break;
                }
                face++;
            } while (face < 4 && enemy == null);

            if (enemy == null)
                enemy = new Enemy(code);

            enemy.ChangeDirection((Facing)face-1);
            enemy.Position = position;

            return enemy;
        }
    }
}
