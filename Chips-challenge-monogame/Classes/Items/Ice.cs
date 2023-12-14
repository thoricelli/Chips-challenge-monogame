using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Ice : ChipObject
    {
        public Ice() : base(Objects.ICE)
        {
        }
        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            //BETTER idea, -> Queue in ChipGame, function called AddPush(time, velocity), update will do it for us.
            //Requires no extra code, and will allow for enabling input when there are no more pushes.

            /*TODO!
            //Disable (input) movement
            //ChipGame.thisPlayerInput.DisableInput();
            //Wait X seconds
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                //Move entity
                entity.Move(oldVelocity);
                //Enable input, this will cause glitches?
                //How should I solve this...
            });*/
        }
    }
}
