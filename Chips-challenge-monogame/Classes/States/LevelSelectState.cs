using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Myra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using CHIPS_CHALLENGE.Classes.Loader;
using System.ComponentModel;
using System.Xml.Linq;

namespace CHIPS_CHALLENGE.Classes.States
{
    public class LevelSelectState : GameState
    {
        public LevelSelectState(GraphicsDevice graphics, SpriteBatch spriteBatch, CHIP chip) : base(graphics, spriteBatch, chip)
        {
        }
        VerticalStackPanel container;
        public override void Initialize()
        {
            base.Initialize();

            container = new VerticalStackPanel
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

            List<ChipFileInformation> levels = ChipGame.chipFileLoader.GetAllLevels();

            var verticalMenu = new VerticalMenu();
            ScrollViewer scroll = new ScrollViewer();

            scroll.Content = verticalMenu;

            foreach (ChipFileInformation level in levels)
            {
                var levelItem = new MenuItem();
                levelItem.Text = level.MapTitle;
                levelItem.Selected += levelSelected;
                levelItem.AttachedPropertiesValues.Add(0, level.LevelNumber);
                verticalMenu.Items.Add(levelItem);
            }

            var backMenuItem = new MenuItem();
            backMenuItem.Text = "Back";
            backMenuItem.Selected += backSelected;

            verticalMenu.Items.Add(backMenuItem);

            container.Widgets.Add(scroll);

            _desktop.Root = container;
        }

        public override void LoadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        private void backSelected(object sender, EventArgs e)
        {
            //I don't know WHY, this is the only way to fix this.
            container.Visible = false;
            _desktop.Render();
            _graphics.Clear(Color.Black);
            _game.ChangeState(new MenuState(_graphics, _spriteBatch, _game));
        }
        private void levelSelected(object sender, EventArgs e)
        {
            container.Visible = false;
            _desktop.Render();
            _graphics.Clear(Color.Black);
            InGameState.Level = (ushort)((MenuItem)sender).AttachedPropertiesValues[0];
            _game.ChangeState(new InGameState(_graphics, _spriteBatch, _game));
        }
    }
}
