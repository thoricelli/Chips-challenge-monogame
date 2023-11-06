using CHIPS_CHALLENGE.Classes;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            ChipGame = new ChipGame();
            //LOAD MAP.
            base.Initialize();
        }
        private Sprite sprite;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Spritesheet spritesheet = new Spritesheet(Content.Load<Texture2D>("ChipTest"), 32, 32, 2, 2);
            sprite = new Sprite(spritesheet, 4);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                sprite.NextSprite();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Layer layer in ChipGame.Layers)
            {
                for (int i = 0; i < layer.objects.Length; i++)
                {
                    ChipObject item = layer.objects[i];

                    //Calculate X & Y from i, H and V size;
                    //Special case for entities.

                    _spriteBatch.Draw(
                        item.Sprite.SpriteSheet.spriteSheet, 
                        new Vector2(0, 0), 
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