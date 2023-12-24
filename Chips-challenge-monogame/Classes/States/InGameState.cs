using CHIPS_CHALLENGE.Classes.Drawing;
using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Input;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
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

        public static GameUI gameUI;

        //Sprite basis
        private Sprite sprite;
        public static Spritesheet spritesheet; //Temporarily public, because we're using this as a default
        public static Spritesheet chipAni;

        private Player thisPlayer;
        private PlayerInputHandler inputHandler;

        //TEMPORARY!
        bool upnext = true;//TEMP
        bool upprev = true;
        bool upr = true;
        int previousScrollWheelValue = 0;

        //ugh...
        public static ushort Level = 0;

        private Label label;
        private Label index;
        private Label positionString;
        private Label chipsNeeded;

        public InGameState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip) : base(graphics, spriteBatch, chip)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            _graphics.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null);
            chipDrawer.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F1) && upprev)
            {
                upprev = false;
                ChipGame.chipInfo.LevelNumber--;
                ChipGame.LoadLevel(ChipGame.chipInfo.LevelNumber);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2) && upnext)
            {
                upnext = false;
                ChipGame.LoadNext();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R) && upr)
            {
                upr = false;
                ChipGame.RestartLevel();
            }

            if (Keyboard.GetState().IsKeyUp(Keys.F1))
                upprev = true;
            if (Keyboard.GetState().IsKeyUp(Keys.F2))
                upnext = true;
            if (Keyboard.GetState().IsKeyUp(Keys.R))
                upr = true;

            chipDrawer.Zoom(
                (float)(Mouse.GetState().ScrollWheelValue - previousScrollWheelValue)
                / 1000);

            previousScrollWheelValue = Mouse.GetState().ScrollWheelValue;


            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                sprite.NextSprite();*/

            label.Text = ChipGame.chipInfo.LevelNumber.ToString();
            index.Text = GeneralUtilities.ConvertFromVectorToIndex(thisPlayer.Position).ToString();
            positionString.Text = $"X: {thisPlayer.Position.X} Y: {thisPlayer.Position.Y}";
            chipsNeeded.Text = $"Chips needed: {ChipGame.chipInfo.ChipsToPickUp}";

            ChipGame.Update(gameTime);
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            spritesheet = new Spritesheet(_game.Content.Load<Texture2D>("ChipTiles"), 32, 32, 0, 0, 16);
            chipAni = new Spritesheet(_game.Content.Load<Texture2D>("Chip2Animations"), 32, 32, 0, 0, 8);
            
            sprite = new Sprite(spritesheet, 152);
            ChipGame.LoadLevel(Level);

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
            base.Initialize();
            Panel _panel = new Panel();

            label = new Label()
            {
                Text = "Test",
                TextColor = Color.Black,
            };

            index = new Label()
            {
                Top = 20,
                TextColor = Color.Black,
            };
            positionString = new Label()
            {
                Top = 40,
                TextColor = Color.Black,
            };
            chipsNeeded = new Label()
            {
                Top = 60,
                TextColor = Color.Black,
            };

            _panel.Widgets.Add(label);
            _panel.Widgets.Add(index);
            _panel.Widgets.Add(positionString);
            _panel.Widgets.Add(chipsNeeded);

            gameUI = new GameUI(_panel);
            gameUI.ShowMapTitle(ChipGame.chipInfo.MapTitle);

            _desktop.Root = _panel;
        }
    }
}
