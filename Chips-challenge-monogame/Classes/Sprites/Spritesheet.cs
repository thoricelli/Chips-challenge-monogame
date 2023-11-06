using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Sprites
{
    public class Spritesheet
    {
        public Texture2D spriteSheet;
        
        public int TileHeight;
        public int TileWidth;

        //These offsets, are here for tiles that have spaces in between.
        public int TileOffsetH; //----
        public int TileOffsetV; //|

        public Spritesheet(Texture2D spriteSheet, int tileHeight, int tileWidth, int tileOffsetH, int tileOffsetV)
        {
            this.spriteSheet = spriteSheet;
            TileHeight = tileHeight;
            TileWidth = tileWidth;
            TileOffsetH = tileOffsetH;
            TileOffsetV = tileOffsetV;
        }
    }
}
