using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using Myra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Interfaces
{
    internal interface IGameState
    {
        void Initialize();
        void LoadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
