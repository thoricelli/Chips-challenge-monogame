using CHIPS_CHALLENGE.Classes.Drawing;
using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Input;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.UI;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.States
{
    public class InGameState : GameState
    {
        //Chip game related info & drawer
        private ChipDrawer chipDrawer;

        //Sprite basis
        private Sprite sprite;
        public static Spritesheet spritesheet; //Temporarily public, because we're using this as a default

        private Player thisPlayer;
        private PlayerInputHandler inputHandler;

        int curLevel = 23;

        //TEMPORARY!
        bool upnext = true;//TEMP
        bool upprev = true;
        int previousScrollWheelValue = 0;

        private Desktop _desktop;
        private Label label;
        private Label index;
        private Label positionString;

        public InGameState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip) : base(graphics, spriteBatch, chip)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            _graphics.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null);
            chipDrawer.Draw();
            _spriteBatch.End();

            //Render MRYA UI.
            _desktop.Render();
        }

        public override void Update(GameTime gameTime)
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
                / 1000);

            previousScrollWheelValue = Mouse.GetState().ScrollWheelValue;


            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                sprite.NextSprite();*/

            // TODO: Add your update logic here

            label.Text = ChipGame.chipInfo.LevelNumber.ToString();
            index.Text = GeneralUtilities.ConvertFromVectorToIndex(thisPlayer.Position).ToString();
            positionString.Text = $"X: {thisPlayer.Position.X} Y: {thisPlayer.Position.Y}";

            ChipGame.Update(gameTime);
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            spritesheet = new Spritesheet(_game.Content.Load<Texture2D>("ChipTiles"), 32, 32, 0, 0, 16);
            sprite = new Sprite(spritesheet, 152);
            ChipGame.LoadLevel(curLevel);

            chipDrawer = new ChipDrawer(_spriteBatch, _graphics);

            //TESTPLAYER
            thisPlayer = new Player();
            ChipGame.AddPlayer(thisPlayer);
            chipDrawer.ChangeSubject(thisPlayer);

            inputHandler = new PlayerInputHandler(thisPlayer);
            ChipGame.thisPlayerInput = inputHandler; //TEMP
        }

        public override void Initialize()
        {
            MyraEnvironment.Game = this._game;

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

            StartScreen screen = new StartScreen();
            screen.ShowStartMenu(_panel);

            _desktop.Root = _panel;
        }
    }
}
