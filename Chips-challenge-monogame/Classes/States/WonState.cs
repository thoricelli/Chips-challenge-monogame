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
    public class WonState : GameState
    {
        public WonState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip) : base(graphics, spriteBatch, chip)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        Panel panel;
        public override void Initialize()
        {
            base.Initialize();

            panel = new Panel();

            Label text = new Label()
            {
                Text = "You won!",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var container = new VerticalStackPanel
            {
                Spacing = 4,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Top = 40,
            };

            var titleContainer = new Panel
            {
                Background = DefaultAssets.UITextureRegionAtlas["button"],
            };
            container.Widgets.Add(titleContainer);

            var menuItem1 = new MenuItem();
            menuItem1.Text = "Back to the main menu.";
            menuItem1.Selected += RetryGame;

            var verticalMenu = new VerticalMenu();

            verticalMenu.Items.Add(menuItem1);

            container.Widgets.Add(verticalMenu);

            panel.Widgets.Add(container);
            panel.Widgets.Add(text);

            _desktop.Root = panel;
        }

        public override void LoadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        private void RetryGame(object sender, EventArgs e)
        {
            panel.Visible = false;
            _graphics.Clear(Color.Black);
            _desktop.Render();
            _game.ChangeState(new MenuState(_graphics, _spriteBatch, _game));
        }
    }
}
