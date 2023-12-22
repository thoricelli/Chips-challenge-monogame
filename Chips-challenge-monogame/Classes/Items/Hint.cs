using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Hint : ChipObject
    {
        public Hint() : base(Objects.HINT)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            InGameState.gameUI.ShowHintPanel(ChipGame.chipInfo.HintText);
        }
        public override bool MovingFrom(Entity entity)
        {
            InGameState.gameUI.HideHintPanel();
            return base.MovingFrom(entity);
        }
    }
}
