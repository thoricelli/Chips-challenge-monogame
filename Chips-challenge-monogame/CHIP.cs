using CHIPS_CHALLENGE.Classes;
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
            MyraEnvironment.Game = this;

            if (GraphicsDevice == null)
            {
                _graphics.ApplyChanges();
            }

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            Label label = new Label();

            label.Text = "TESTING!";

            base.Initialize();
        }

        //Chip game related info & drawer
        private ChipDrawer chipDrawer;

        //Sprite basis
        private Sprite sprite;
        public static Spritesheet spritesheet; //Temporarily public, because we're using this as a default

        private Player thisPlayer;

        int curLevel = 0;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spritesheet = new Spritesheet(Content.Load<Texture2D>("ChipTiles"), 32, 32, 0, 0, 16);
            sprite = new Sprite(spritesheet, 152);

            ChipGame.chipInfo = ChipFileLoader.LoadLevelFromFile(".\\Content\\CHIPS.DAT", curLevel);

            chipDrawer = new ChipDrawer(_spriteBatch, _graphics.GraphicsDevice);

            //TESTPLAYER
            thisPlayer = new Player();
            ChipGame.Players.Add(thisPlayer);
            chipDrawer.ChangeSubject(thisPlayer);
        }
        //TEMPORARY!
        bool upprev = true;
        bool upnext = true;//TEMP
        bool upkey = true;
        int previousScrollWheelValue = 0;
        protected override void Update(GameTime gameTime)
        {
            //MOVE THIS TO INPUT CLASS LATER!
            if (upkey)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    thisPlayer.Move(new Vector2(0, -1));
                    upkey = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    thisPlayer.Move(new Vector2(0, 1));
                    upkey = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    thisPlayer.Move(new Vector2(-1, 0));
                    upkey = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    thisPlayer.Move(new Vector2(1, 0));
                    upkey = false;
                }
            }

            if (
                Keyboard.GetState().IsKeyUp(Keys.Up) 
                && Keyboard.GetState().IsKeyUp(Keys.Down) 
                && Keyboard.GetState().IsKeyUp(Keys.Left) 
                && Keyboard.GetState().IsKeyUp(Keys.Right))
                upkey = true;

            if (Keyboard.GetState().IsKeyDown(Keys.F1) && upprev)
            {
                upprev = false;
                curLevel--;
                ChipGame.chipInfo = ChipFileLoader.LoadLevelFromFile(".\\Content\\CHIPS.DAT", curLevel);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2) && upnext)
            {
                upnext = false;
                curLevel++;
                ChipGame.chipInfo = ChipFileLoader.LoadLevelFromFile(".\\Content\\CHIPS.DAT", curLevel);
            }

            if (Keyboard.GetState().IsKeyUp(Keys.F1))
                upprev = true;
            if (Keyboard.GetState().IsKeyUp(Keys.F2))
                upnext = true;

            chipDrawer.Zoom(
                (float)(Mouse.GetState().ScrollWheelValue - previousScrollWheelValue)
                /1000);

            previousScrollWheelValue = Mouse.GetState().ScrollWheelValue;


            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                sprite.NextSprite();*/

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null);
            chipDrawer.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}