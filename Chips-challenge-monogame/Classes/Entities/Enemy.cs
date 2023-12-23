using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.States;
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
                Objects.TANK_BUTTON,
                Objects.TELEPORT_BUTTON,
                Objects.BOMB,
                Objects.TRAP,
                Objects.FORCE_FLOOR_RANDOM,
                Objects.FORCE_NORTH,
                Objects.FORCE_EAST,
                Objects.FORCE_SOUTH,
                Objects.FORCE_WEST,
                Objects.WATER,
            };
        private List<Direction> directions = new List<Direction>();
        public Enemy(Objects code)
            : base(code,
                  new Sprite(InGameState.spritesheet, 1, (int)code), //N
                  new Sprite(InGameState.spritesheet, 1, (int)code + 1), //E
                  new Sprite(InGameState.spritesheet, 1, (int)code + 2), //S
                  new Sprite(InGameState.spritesheet, 1, (int)code + 3)) //W
        {
        }
        public Enemy(Objects code, List<Direction> directions)
            : base(code,
                  new Sprite(InGameState.spritesheet, 1, (int)code), //N
                  new Sprite(InGameState.spritesheet, 1, (int)code + 1), //E
                  new Sprite(InGameState.spritesheet, 1, (int)code + 2), //S
                  new Sprite(InGameState.spritesheet, 1, (int)code + 3)) //W
        {
            this.directions = directions;
        }
        public override bool Move(Vector2 velocity)
        {
            bool move = base.Move(velocity);
            Player playerHit = ChipGame.CheckPlayerTouched(this.Position);
            if (playerHit != null)
                playerHit.Kill(this.Code);
            return move;
        }
        //Update enemy movement
        public virtual void Update()
        {
            if (allowedObjects.Count != 0)
            {
                int triedDirections = 0;
                bool blocked = false;
                do
                {
                    blocked = false;

                    Vector2 velocity = GeneralUtilities.SpriteFacingToVector(
                                                    GetDirection(triedDirections),
                                                    this.Facing
                                                    );
                    Vector2 movingTo = this.Position + velocity * 32;
                    List<ChipObject> chipObjects =
                        ChipGame.CheckCollision(movingTo);
                    foreach (ChipObject item in chipObjects)
                    {
                        if (!CanMove(item.code, movingTo))
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
                } while (CanStillMove(triedDirections) && blocked);
            }
        }
        public virtual bool CanMove(Objects code, Vector2 movingTo)
        {
            return allowedObjects.Contains(code) && ChipGame.CheckEntityTouched(movingTo) == null;
        }
        public virtual Direction GetDirection(int tries)
        {
            if (directions.Count != 0)
                return directions[tries];
            else
                return Direction.UP;
        }
        public virtual bool CanStillMove(int tries)
        {
            return tries < directions.Count;
        }

        public override void Kill(Objects killedBy)
        {
            base.Kill(killedBy);
            ChipGame.RemoveEnemy(this);
        }
    }
}
