using CHIPS_CHALLENGE.Classes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.States
{
    public abstract class GameState : IGameState
    {
        protected GraphicsDevice _graphics;
        protected SpriteBatch _spriteBatch;
        protected CHIP _game;
        protected Desktop _desktop;
        protected GameState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip)
        {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
            this._game = chip;
            this.LoadContent();
            this.Initialize();
        }
        public virtual void Initialize() {
            MyraEnvironment.Game = this._game;

            _desktop = new Desktop();
            _graphics.Clear(Color.Black);
            _desktop.Render();
        }
        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public virtual void Draw(GameTime gameTime)
        {
            //Render MRYA UI.
            _desktop.Render();
        }
    }
}
