using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CHIPS_CHALLENGE.Classes.Drawing
{
    public class ChipDrawer
    {
        public int CameraX { get; set; }
        public int CameraY { get; set; }

        private ChipGame chipGame;
        private SpriteBatch spriteBatch;

        public ChipDrawer(ChipGame chipGame, SpriteBatch spriteBatch)
        {
            this.chipGame = chipGame;
            this.spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            //Draw all layers with objects on them
            DrawLayers();
            //Draw players
            //Draw enemies
        }

        #region DRAWING
        private void DrawLayers()
        {
            for (int layerIndex = chipGame.chipInfo.layers.Count - 1; layerIndex >= 0; layerIndex--)
            {
                Layer layer = chipGame.chipInfo.layers[layerIndex];
                for (int i = 0; i < layer.objects.Length; i++)
                {
                    ChipObject item = layer.objects[i];

                    Vector2 position = new Vector2();
                    position.X = (i % layer.HorizontalSize) * item.Sprite.SpriteRectangle.Width + CameraX;
                    position.Y = (i / layer.VerticalSize) * item.Sprite.SpriteRectangle.Height + CameraY;

                    spriteBatch.Draw(
                            item.Sprite.SpriteSheet.spriteSheet,
                            position,
                            item.Sprite.SpriteRectangle,
                            Color.White
                        );
                }
            }
        }
        #endregion
    }
}
