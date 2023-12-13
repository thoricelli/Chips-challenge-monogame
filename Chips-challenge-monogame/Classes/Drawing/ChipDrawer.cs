using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CHIPS_CHALLENGE.Classes.Drawing
{
    public class ChipDrawer
    {
        //Vector2 is giving me a headache...
        public int CameraX { get; set; }
        public int CameraY { get; set; }
        public int CameraXOffset { get; set; }
        public int CameraYOffset { get; set; }
        public Entity Target { get { return _target; } }
        public float ZoomModifier { get; set; } = 1;

        private SpriteBatch spriteBatch;
        private GraphicsDevice graphics;
        private Entity _target;

        public ChipDrawer(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
        }

        public void Draw()
        {
            //Update the camera to target
            UpdateCamera();
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
        public void ChangeSubject(Entity entity)
        {
            _target = entity;
        }

        #region DRAWING
        private void UpdateCamera()
        {
            if (_target != null)
            {
                CameraX = -(int)_target.Position.X;
                CameraXOffset = (graphics.Viewport.Width / 2);
                CameraY = -(int)_target.Position.Y;
                CameraYOffset = (graphics.Viewport.Height / 2);
            }
        }
        private void DrawLayers()
        {
            for (int layerIndex = ChipGame.chipInfo.layers.Count - 1; layerIndex >= 0; layerIndex--)
            {
                Layer layer = ChipGame.chipInfo.layers[layerIndex];
                for (int i = 0; i < layer.objects.Length; i++)
                {
                    ChipObject item = layer.objects[i];
                    Vector2 position = GeneralUtilities.ConvertFromIndexToVector(i);

                    //For now this a temporary way of doing this
                    //Cause I can't come up with a proper way of doing this.
                    //The drawer shouldn't even be responsible for this???
                    if (item.changeInto.HasValue)
                        item = ItemFactory.CreateObjectFromCode(item.changeInto.Value);
                    if (item.goToDirection.HasValue)
                    {
                        //Check if we can move to something (will HAVE to be an empty tile)
                        Vector2 pos = (position + new Vector2(item.goToDirection.Value.X, item.goToDirection.Value.Y*32));
                        int index = GeneralUtilities.ConvertFromVectorToIndex(pos);
                        if (layer.objects[index].code == Objects.EMPTY)
                        {
                            layer.objects[index] = ItemFactory.CreateObjectFromCode(item.code);
                            layer.objects[i] = ItemFactory.CreateObjectFromCode(Objects.EMPTY);
                            i = index;
                        }
                        item.goToDirection = null;
                    }

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
            foreach (Player player in ChipGame.Players)
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
            return new Vector2(
                ((vector.X + CameraX) * ZoomModifier) + CameraXOffset, 
                ((vector.Y + CameraY) * ZoomModifier) + CameraYOffset
            );
        }
        #endregion
    }
}
