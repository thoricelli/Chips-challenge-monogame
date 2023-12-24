using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Myra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.States
{
    public class MenuState : GameState
    {
        public MenuState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip) : base(graphics, spriteBatch, chip)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();

            var container = new VerticalStackPanel
            {
                Spacing = 4,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var titleContainer = new Panel
            {
                Background = DefaultAssets.UITextureRegionAtlas["button"],
            };
            container.Widgets.Add(titleContainer);

            var menuItem1 = new MenuItem();
            menuItem1.Text = "Start New Game";
            menuItem1.Selected += NewGameSelected;

            var menuItem2 = new MenuItem();
            menuItem2.Text = "Level select";
            menuItem2.Selected += LevelSelectSelected;

            var menuItem3 = new MenuItem();
            menuItem3.Text = "Quit";
            menuItem3.Selected += QuitGameSelected;

            var verticalMenu = new VerticalMenu();

            verticalMenu.Items.Add(menuItem1);
            verticalMenu.Items.Add(menuItem2);
            verticalMenu.Items.Add(menuItem3);

            container.Widgets.Add(verticalMenu);

            _desktop.Root = container;
        }

        public override void LoadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        private void NewGameSelected(object sender, EventArgs e)
        {
            _game.ChangeState(new InGameState(_graphics, _spriteBatch, _game));
        }
        private void QuitGameSelected(object sender, EventArgs e)
        {
            _game.Exit();
        }
        private void LevelSelectSelected(object sender, EventArgs e)
        {
            InGameState.Level = 1;
            _game.ChangeState(new LevelSelectState(_graphics, _spriteBatch, _game));
        }
    }
}
