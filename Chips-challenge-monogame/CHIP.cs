﻿using CHIPS_CHALLENGE.Classes;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CHIPS_CHALLENGE.Classes.Loader;
using System.Collections.Generic;
using CHIPS_CHALLENGE.Classes.Drawing;
using CHIPS_CHALLENGE.Classes.Entities;
using Myra.Graphics2D.UI;
using Myra;
using CHIPS_CHALLENGE.Classes.Utilities;
using CHIPS_CHALLENGE.Classes.Input;
using CHIPS_CHALLENGE.Classes.States;
using SharpDX.Direct3D9;

namespace CHIPS_CHALLENGE
{
    public class CHIP : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState state;
        public void ChangeState(GameState state)
        {
            this.state = state;
        }

        public CHIP()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        
        protected override void Initialize()
        {
            if (GraphicsDevice == null)
            {
                _graphics.ApplyChanges();
            }

            Window.AllowUserResizing = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            /*InGameState inGameState = new InGameState(GraphicsDevice, _spriteBatch, this);
            state = inGameState;*/

            MenuState menuState = new MenuState(GraphicsDevice, _spriteBatch, this);
            this.ChangeState(menuState);

            base.Initialize();
        }

        protected override void LoadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            state.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}