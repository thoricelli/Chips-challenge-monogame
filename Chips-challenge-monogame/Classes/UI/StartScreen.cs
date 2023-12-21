using Myra.Graphics2D.UI;
using Myra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CHIPS_CHALLENGE.Classes.UI
{
    public class StartScreen
    {
        public void ShowStartMenu(Panel panel)
        {
            /*if (desktop.ContextMenu != null)
            {
                // Dont show if it's already shown
                return;
            }*/

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
            menuItem1.Selected += (s, a) =>
            {
                // "Start New Game" selected
            };

            /*var menuItem2 = new MenuItem();
            menuItem2.Text = "Options";*/

            var menuItem3 = new MenuItem();
            menuItem3.Text = "Quit";

            var verticalMenu = new VerticalMenu();

            verticalMenu.Items.Add(menuItem1);
            //verticalMenu.Items.Add(menuItem2);
            verticalMenu.Items.Add(menuItem3);

            container.Widgets.Add(verticalMenu);

            panel.Widgets.Add(container);
        }
    }
}
