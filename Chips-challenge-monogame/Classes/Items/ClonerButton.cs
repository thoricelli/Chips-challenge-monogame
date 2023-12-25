using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using CHIPS_CHALLENGE.Classes.Utilities;
using info.lundin.math;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ClonerButton : ChipObject, IPressable
    {
        public ClonerButton() : base(Objects.CLONER_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            //Allow entity to move thats on cloner, clone new entity
            //Get cloner linked to this button
            Clone(entity.Position);

            base.HasMovedTo(entity, oldVelocity);
        }

        private void Clone(Vector2 position)
        {
            CloneMachine? cloner = ChipGame.GetCloneFromButtonPosition(position);
            if (cloner.HasValue)
            {
                //Get entity on the cloner.
                Vector2 clonePosition = new Vector2(cloner.Value.ObjectX * 32, cloner.Value.ObjectY * 32);
                Enemy cloneEntity = ChipGame.CheckEntityTouched(clonePosition) as Enemy;
                Objects objectOnTop = ChipGame.GetObjectFromIndex(0, GeneralUtilities.ConvertFromVectorToIndex(clonePosition));

                if (cloneEntity != null)
                {
                    ChipGame.CloneEnemy(cloneEntity);

                    cloneEntity.waitToBeReleased = true;
                    cloneEntity.Update();
                }
                else
                {
                    Enemy enemy = ChipGame.AddEnemy(objectOnTop, clonePosition);

                    enemy.waitToBeReleased = true;
                    enemy.Update();
                }
            }
        }

        public Object Press(Vector2 position)
        {
            Clone(position);
            return null;
        }
    }
}
