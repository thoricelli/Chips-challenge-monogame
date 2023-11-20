using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CHIPS_CHALLENGE.Classes.Drawing
{
    public class ChipDrawer
    {
        public int CameraX { get; set; }
        public int CameraY { get; set; }

        public float ZoomModifier { get; set; } = 0.5F;

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
            DrawPlayers();
            //Draw enemies
        }

        //Be able to ZOOM out or into the level
        public void Zoom(float zoomAmount = 1)
        {
            ZoomModifier += zoomAmount;
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
                    position.X = (i % layer.HorizontalSize)
                                 * item.Sprite.SpriteRectangle.Width;

                    position.Y = (i / layer.VerticalSize)
                                 * item.Sprite.SpriteRectangle.Height;

                    spriteBatch.Draw(
                            item.Sprite.SpriteSheet.spriteSheet,
                            CalculateModifiers(position),
                            item.Sprite.SpriteRectangle,
                            Color.White,
                            0,
                            Vector2.Zero,
                            ZoomModifier,
                            SpriteEffects.None,
                            0
                        );
                }
            }
        }

        private void DrawPlayers()
        {
            foreach (Player player in chipGame.Players)
            {
                switch (player.State)
                {
                    case Entities.Enums.State.Alive:
                        spriteBatch.Draw(
                            player.Sprite.SpriteSheet.spriteSheet,
                            CalculateModifiers(player.Position),
                            player.Sprite.SpriteRectangle,
                            Color.White,
                            0,
                            Vector2.Zero,
                            ZoomModifier,
                            SpriteEffects.None,
                            0
                        );
                        break;
                }
            }
        }

        //TODO, other class??
        private Vector2 CalculateModifiers(Vector2 vector) //Is this not by reference?
        {
            return new Vector2((vector.X + CameraX) * ZoomModifier, (vector.Y + CameraY) * ZoomModifier);
        }
        #endregion
    }
}
