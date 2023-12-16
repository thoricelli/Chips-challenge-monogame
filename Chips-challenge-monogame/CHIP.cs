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
using CHIPS_CHALLENGE.Classes.Utilities;
using CHIPS_CHALLENGE.Classes.Input;

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
        Desktop _desktop;
        Label label;
        Label index;
        Label positionString;
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            if (GraphicsDevice == null)
            {
                _graphics.ApplyChanges();
            }

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();

            MyraEnvironment.Game = this;

            _desktop = new Desktop();

            Panel _panel = new Panel();

            label = new Label()
            {
                Text = "Test"
            };

            index = new Label()
            {
                Top = 20
            };
            positionString = new Label()
            {
                Top = 40
            };

            _panel.Widgets.Add(label);
            _panel.Widgets.Add(index);
            _panel.Widgets.Add(positionString);


            _desktop.Root = _panel;
        }

        //Chip game related info & drawer
        private ChipDrawer chipDrawer;

        //Sprite basis
        private Sprite sprite;
        public static Spritesheet spritesheet; //Temporarily public, because we're using this as a default

        private Player thisPlayer;
        private PlayerInputHandler inputHandler;

        int curLevel = 1;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spritesheet = new Spritesheet(Content.Load<Texture2D>("ChipTiles"), 32, 32, 0, 0, 16);
            sprite = new Sprite(spritesheet, 152);

            ChipGame.LoadLevel(curLevel);

            chipDrawer = new ChipDrawer(_spriteBatch, _graphics.GraphicsDevice);

            //TESTPLAYER
            thisPlayer = new Player();
            ChipGame.AddPlayer(thisPlayer);
            chipDrawer.ChangeSubject(thisPlayer);

            inputHandler = new PlayerInputHandler(thisPlayer);
            ChipGame.thisPlayerInput = inputHandler; //TEMP
        }
        //TEMPORARY!
        bool upnext = true;//TEMP
        bool upprev = true;
        int previousScrollWheelValue = 0;
        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.F1) && upprev)
            {
                upprev = false;
                curLevel--;
                ChipGame.LoadLevel(curLevel);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2) && upnext)
            {
                upnext = false;
                curLevel++;
                ChipGame.LoadLevel(curLevel);
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

            label.Text = ChipGame.chipInfo.LevelNumber.ToString();
            index.Text = GeneralUtilities.ConvertFromVectorToIndex(thisPlayer.Position).ToString();
            positionString.Text = $"X: {thisPlayer.Position.X} Y: {thisPlayer.Position.Y}";

            ChipGame.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null);
            chipDrawer.Draw();
            _spriteBatch.End();

            //Render MRYA UI.
            _desktop.Render();
            base.Draw(gameTime);

        }
    }
}