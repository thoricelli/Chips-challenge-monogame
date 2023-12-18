using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Entities.Enums;

namespace CHIPS_CHALLENGE.Classes.Utilities
{
    public static class GeneralUtilities
    {
        public static Vector2 ConvertFromIndexToVector(int index)
        {

            //Layer layer = ChipGame.chipInfo.layers[0];
            return new Vector2(
                //Kind of a hack botch-job, but eh.
                (index % 32/*layer.HorizontalSize*/) * 32,//layer.objects[0].Sprite.SpriteRectangle.Width,
                (index / 32/*layer.VerticalSize*/) * 32//layer.objects[0].Sprite.SpriteRectangle.Height
                );
        }
        public static int ConvertFromVectorToIndex(Vector2 position)
        {

            return (int)((position.X / 32) + (position.Y));
        }
        public static Vector2 SpriteFacingToVector(Direction direction, Facing face)
        {
            Vector2 position = new Vector2();

            switch (direction)
            {
                case Direction.UP:
                    position = new Vector2(0,-1);
                    break;
                case Direction.DOWN:
                    position = new Vector2(0, 1);
                    break;
                case Direction.LEFT:
                    position = new Vector2(-1, 0);
                    break;
                case Direction.RIGHT:
                    position = new Vector2(1, 0);
                    break;
                default:
                    break;
            }

            switch (face)
            {
                case Facing.NORTH:
                    //We're all good.
                    break;
                case Facing.WEST:
                    Vector2.Transform(position, Matrix.CreateRotationX(270));
                    break;
                case Facing.SOUTH:
                    Vector2.Transform(position, Matrix.CreateRotationX(180));
                    break;
                case Facing.EAST:
                    Vector2.Transform(position, Matrix.CreateRotationX(90));
                    break;
                default:
                    break;
            }

            return position;
        }
    }
}
