using CHIPS_CHALLENGE.Classes;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CHIPS_CHALLENGE.Classes.Loader;
using System.Collections.Generic;
using CHIPS_CHALLENGE.Classes.Drawing;

namespace CHIPS_CHALLENGE
{
    public class CHIP : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public CHIP()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        //Chip game related info & drawer
        private ChipGame ChipGame;
        private ChipDrawer chipDrawer;

        //Sprite basis
        private Sprite sprite;
        public static Spritesheet spritesheet; //Temporarily public, because we're using this as a default

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spritesheet = new Spritesheet(Content.Load<Texture2D>("ChipTiles"), 32, 32, 0, 0, 16);
            sprite = new Sprite(spritesheet, 152);

            ChipGame = new ChipGame();
            ChipGame.chipInfo = ChipFileLoader.LoadLevelFromFile("C:\\Users\\roanh\\Desktop\\CHIPS.DAT", 0);

            chipDrawer = new ChipDrawer(ChipGame, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                chipDrawer.CameraY++;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                chipDrawer.CameraY--;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                chipDrawer.CameraX++;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                chipDrawer.CameraX--;

                /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    sprite.NextSprite();*/

                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            chipDrawer.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}