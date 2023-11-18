using CHIPS_CHALLENGE.Classes;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CHIPS_CHALLENGE.Classes.Loader;
using System.Collections.Generic;

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

        ChipGame ChipGame;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //LOAD MAP.
            base.Initialize();
        }
        private Sprite sprite;
        public static Spritesheet spritesheet;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spritesheet = new Spritesheet(Content.Load<Texture2D>("ChipTiles"), 32, 32, 0, 0, 7);
            sprite = new Sprite(spritesheet, 152);

            ChipGame = new ChipGame();
            ChipGame.chipInfo = ChipFileLoader.LoadLevelFromFile("C:\\Users\\roanh\\Desktop\\CHIPS.DAT", 0);
        }

        int cameraX = 0;
        int cameraY = 0;

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cameraY--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cameraY++;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cameraX--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cameraX++;

                /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    sprite.NextSprite();*/

                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (Layer layer in ChipGame.chipInfo.layers)
            {
                for (int i = 0; i < layer.objects.Length; i++)
                {
                    ChipObject item = layer.objects[i];

                    //Calculate X & Y from i, H and V size;
                    //Special case for entities.

                    //This should be in a seperate draw class... -> REFACTOR!
                    //Because we need the camera added to this too, chips position too, etc...
                    //For now this is a bit more of a test.
                    Vector2 position = new Vector2();
                    position.X = (i % layer.HorizontalSize) * item.Sprite.SpriteRectangle.Width + cameraX;
                    position.Y = (i / layer.VerticalSize) * item.Sprite.SpriteRectangle.Height + cameraY;

                    _spriteBatch.Draw(
                        item.Sprite.SpriteSheet.spriteSheet,
                        position, 
                        item.Sprite.SpriteRectangle, 
                        Color.White
                    );
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}