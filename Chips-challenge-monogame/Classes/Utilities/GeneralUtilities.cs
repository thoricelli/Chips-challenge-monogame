using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHIPS_CHALLENGE.Classes.Sprites;

namespace CHIPS_CHALLENGE.Classes.Utilities
{
    public static class GeneralUtilities
    {
        //another TODO! :D
        public static Vector2 ConvertFromIndexToVector(int index)
        {

            Layer layer = ChipGame.chipInfo.layers[0];
            return new Vector2(
                //Kind of a hack botch-job, but eh.
                (index % layer.HorizontalSize) * layer.objects[0].Sprite.SpriteRectangle.Width,
                (index / layer.VerticalSize) * layer.objects[0].Sprite.SpriteRectangle.Height
                );
        }
    }
}
