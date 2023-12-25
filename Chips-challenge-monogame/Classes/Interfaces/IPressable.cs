using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Interfaces
{
    public interface IPressable
    {
        /// <summary>
        /// When a button gets pressed.
        /// </summary>
        /// <param name="index">The index of the button itself. (Can be 0)</param>
        public Object Press(Vector2 position);
    }
}
