﻿using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHIPS_CHALLENGE.Classes.Drawing
{
    public class ChipDrawer : IDrawer
    {
        public int CameraX { get; set; }
        public int CameraY { get; set; }
        public int CameraXOffset { get; set; }
        public int CameraYOffset { get; set; }
        public Entity Target { get { return _target; } }
        public float ZoomModifier { get; set; } = 2;

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
            //Draw all entities
            DrawEntities(ChipGame.Entities);
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
                CameraX = -(int)_target.DisplayPosition.X;
                CameraXOffset = (graphics.Viewport.Width / 2);
                CameraY = -(int)_target.DisplayPosition.Y;
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
                    layer.objects[i] = GameUpdate.Update(item, layerIndex != ChipGame.chipInfo.layers.Count - 1 ? ChipGame.chipInfo.layers[layerIndex + 1].objects[i] : null, i);

                    if (layerIndex == 1 || (layerIndex == 0 && item.code != Objects.EMPTY))
                    {
                        spriteBatch.Draw(
                                item.Sprite.SpriteSheet.spriteSheet,
                                GeneralUtilities.CalculateModifiers(position, CameraX, CameraY, ZoomModifier, CameraXOffset, CameraYOffset),
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
            GameUpdate.ClearUpdateList();
        }

        private void DrawEntities(List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                switch (entity.State)
                {
                    case Entities.Enums.State.Alive:
                        spriteBatch.Draw(
                            entity.Sprite.SpriteSheet.spriteSheet,
                            GeneralUtilities.CalculateModifiers(entity.DisplayPosition, CameraX, CameraY, ZoomModifier, CameraXOffset, CameraYOffset),
                            entity.Sprite.SpriteRectangle,
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
        #endregion
    }
}
