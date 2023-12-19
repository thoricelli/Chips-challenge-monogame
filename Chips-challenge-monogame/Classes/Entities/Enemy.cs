using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Enemy : Entity
    {
        //AI.
        private List<Objects> allowedObjects = 
            new List<Objects>() { 
                Objects.EMPTY, 
                Objects.WALL_BUTTON, 
                Objects.CLONER_BUTTON, 
                Objects.TOGGLE_WALL_ON,
                Objects.TOGGLE_WALL_OFF,
                Objects.TRAP_BUTTON,
                Objects.SENTRY_BUTTON,
                Objects.TELEPORT_BUTTON};
        private List<Direction> directions = new List<Direction>();
        public Enemy(Objects code, Vector2 position, Facing facing)
            : base(code,
                  new Sprite(CHIP.spritesheet, 1, (int)code), //N
                  new Sprite(CHIP.spritesheet, 1, (int)code + 1), //E
                  new Sprite(CHIP.spritesheet, 1, (int)code + 2), //S
                  new Sprite(CHIP.spritesheet, 1, (int)code + 3),
                  facing) //W
        {
            this.Position = position;
        }
        public Enemy(Objects code, Vector2 position, List<Direction> directions, List<Objects> allowedObjects, Facing facing)
            : base(code,
                  new Sprite(CHIP.spritesheet, 1, (int)code), //N
                  new Sprite(CHIP.spritesheet, 1, (int)code + 1), //E
                  new Sprite(CHIP.spritesheet, 1, (int)code + 2), //S
                  new Sprite(CHIP.spritesheet, 1, (int)code + 3), //W
                  facing)
        {
            this.Position = position;
            this.directions = directions;
            this.allowedObjects = allowedObjects;
        }
        public Enemy(Objects code, Vector2 position, List<Direction> directions, Facing facing)
            : base(code,
                  new Sprite(CHIP.spritesheet, 1, (int)code), //N
                  new Sprite(CHIP.spritesheet, 1, (int)code + 1), //E
                  new Sprite(CHIP.spritesheet, 1, (int)code + 2), //S
                  new Sprite(CHIP.spritesheet, 1, (int)code + 3), //W
                  facing)
        {
            this.Position = position;
            this.directions = directions;
        }
        public Enemy(Objects code, Vector2 position, Sprite North, Sprite East, Sprite South, Sprite West, List<Direction> directions, List<Objects> allowedObjects, Facing facing)
            : base(code, North, East, South, West, facing)
        {
            this.Position = position;
            this.directions = directions;
            this.allowedObjects = allowedObjects;
        }
        public override bool Move(Vector2 velocity)
        {
            bool move = base.Move(velocity);
            Player playerHit = ChipGame.CheckPlayerTouched(this.Position);
            if (playerHit != null)
                playerHit.Kill();
            return move;
        }
        //Update enemy movement
        public virtual void Update()
        {
            if (allowedObjects.Count != 0 && directions.Count != 0)
            {
                int triedDirections = 0;
                bool blocked = false;
                do
                {
                    blocked = false;

                    Vector2 velocity = GeneralUtilities.SpriteFacingToVector(
                                                    directions[triedDirections],
                                                    this.Facing
                                                    );
                    List<ChipObject> chipObjects =
                        ChipGame.CheckCollision(this.Position + velocity * 32);
                    foreach (ChipObject item in chipObjects)
                    {
                        if (!allowedObjects.Contains(item.code))
                        {
                            blocked = true;
                        }
                        else if (!blocked)
                        {
                            Move(velocity);
                            break; //TODO, remove...
                        }
                    }
                    triedDirections++;
                } while (triedDirections < directions.Count && blocked);
            }
        }
    }
}
