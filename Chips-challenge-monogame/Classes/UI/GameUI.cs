using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.UI
{
    public class GameUI
    {
        public Panel _mainPanel;

        private Panel HintPanel;
        private Label HintText;

        private Label MapTitle;

        public GameUI(Panel main)
        {
            _mainPanel = main;

            HintPanel = new Panel()
            {
                Background = new SolidBrush(Color.DarkGray),
                Width = 250,
                Height = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            HintText = new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Wrap = true,
            };

            HintPanel.Widgets.Add(HintText);

            HintPanel.Visible = false;

            MapTitle = new Label()
            {
                Text = "Testing!",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlign = FontStashSharp.RichText.TextHorizontalAlignment.Center,
                Height = 25,
                Background = new SolidBrush(Color.Black)
            };

            _mainPanel.Widgets.Add(HintPanel);
            _mainPanel.Widgets.Add(MapTitle);
        }
        public void ShowMapTitle(string text)
        {
            MapTitle.Text = text;
            MapTitle.Visible = true;
        }
        public void HideMapTitle()
        {
            MapTitle.Visible = false;
        }
        public void LevelChanged()
        {
            HideHintPanel();
        }
        public void ShowHintPanel(string text)
        {
            HintText.Text = text;
            HintPanel.Visible = true;
        }
        public void HideHintPanel()
        {
            HintPanel.Visible = false;
        }
    }
}
