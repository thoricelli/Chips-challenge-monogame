using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.States
{
    public abstract class GameState
    {
        protected GraphicsDevice _graphics;
        protected SpriteBatch _spriteBatch;
        protected CHIP _game;
        protected GameState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip)
        {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
            this.chip = chip;
        }
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
