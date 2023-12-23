using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ClonerButton : ChipObject
    {
        public ClonerButton() : base(Objects.CLONER_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            //Allow entity to move thats on cloner, clone new entity
            //Get cloner linked to this button
            CloneMachine? cloner = ChipGame.GetCloneFromButtonPosition(entity.Position);
            //Get entity on the cloner.
            Enemy cloneEntity = ChipGame.CheckEntityTouched(new Vector2(cloner.Value.ObjectX * 32, cloner.Value.ObjectY * 32)) as Enemy;

            ChipGame.CloneEnemy(cloneEntity);

            cloneEntity.waitToBeReleased = true;
            cloneEntity.Update();

            base.HasMovedTo(entity, oldVelocity);
        }
    }
}
