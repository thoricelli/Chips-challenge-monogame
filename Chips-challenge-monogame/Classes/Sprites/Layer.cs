using CHIPS_CHALLENGE.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Sprites
{
    public class Layer
    {
        public int VerticalSize = 32;
        public int HorizontalSize = 32;

        public ChipObject[] objects;

        public Layer(int verticalSize, int horizontalSize)
        {
            VerticalSize = verticalSize;
            HorizontalSize = horizontalSize;
            objects = new ChipObject[verticalSize * horizontalSize];
        }
    }
}
