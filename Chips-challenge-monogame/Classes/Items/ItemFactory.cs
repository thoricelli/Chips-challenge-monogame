using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    //Static for now.
    public static class ItemFactory
    {
        public static ChipObject CreateObjectFromCode(Objects code)
        {
            //Replace with an array maybe? Idk.
            switch (code)
            {
                case Objects.WALL:
                    return new Wall();
                    break;
                case Objects.COMPUTER_CHIP:
                    return new Chip();
                    break;
                default:
                    return new ChipObject(code);
                    break;
            }
        }
    }
}
