using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Sprites
{
    /*
     * Sprites, can have a spritesheet, 
     * it is up to the sprite itself to choose which sprite in the spritesheet it is.
     * A sprite, can also just be a singular image.
     */
    public class Sprite
    {
        #region SPRITE_BASE
        private Spritesheet _spriteSheet;
        public Spritesheet SpriteSheet { 
            get { return _spriteSheet; } 
        }
        public Rectangle _spriteRectangle;
        public Rectangle SpriteRectangle
        {
            get { return _spriteRectangle; }
        }
        #endregion

        private int _spriteIndex;
        public int SpriteIndex
        {
            get
            {
                return _spriteIndex;
            }
        }

        private int _totalSprites;

        public Sprite(Spritesheet spriteSheet, int totalSprites, int spriteIndex = 0)
        {
            _spriteSheet = spriteSheet;
            _totalSprites = totalSprites - 1;
            _spriteIndex = spriteIndex;
            UpdateSprite();
        }

        #region FUNCTIONS
        #region CHANGING_SPRITES
        public void ChangeSprite(int index)
        {
            _spriteIndex = index;
            UpdateSprite();
        }
        public void NextSprite()
        {
            if (_spriteIndex < _totalSprites)
                _spriteIndex++;
            else
                _spriteIndex = 0;
            UpdateSprite();
        }
        public void PreviousSprite()
        {
            if (_spriteIndex >= _totalSprites)
                _spriteIndex--;
            else
                _spriteIndex = _totalSprites;
            UpdateSprite();
        }
        #endregion

        private void UpdateSprite()
        {
            int X = 
                _spriteSheet.TileOffsetH + (_spriteSheet.TileOffsetH * SpriteIndex)
                + _spriteSheet.TileWidth * SpriteIndex;
            int Y =
                _spriteSheet.TileOffsetV;

            //WHAT HAPPENS IF THE SPRITE IS BELOW?
            //Y LOGIC NEEDS TO BE ACCOUNTED FOR.
            _spriteRectangle = new Rectangle(X, Y, _spriteSheet.TileWidth, _spriteSheet.TileHeight);
        }
        #endregion
    }
}
