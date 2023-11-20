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
     * 
     * Note: Having to add spritesheets everytime is annoying... -> Factory pattern??
     * Another note: Animations are TODO, plus adding a way to specify multiple sprites over the spritesheet!
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

        public Sprite(Spritesheet spriteSheet, int totalSprites = 1, int spriteIndex = 0)
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
            int spriteIndexX = (SpriteIndex / _spriteSheet.HorizontalTiles);
            int spriteIndexY = (SpriteIndex % _spriteSheet.HorizontalTiles);

            int X = 
                _spriteSheet.TileOffsetH + (_spriteSheet.TileOffsetH * spriteIndexX)
                + _spriteSheet.TileWidth * spriteIndexX;
            int Y =
                _spriteSheet.TileOffsetV + (_spriteSheet.TileOffsetV * spriteIndexY)
                + _spriteSheet.TileHeight * spriteIndexY;

            _spriteRectangle = new Rectangle(X, Y, _spriteSheet.TileWidth, _spriteSheet.TileHeight);
        }
        #endregion
    }
}
