using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Game.Enums;
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
    public abstract class Entity : Animator
    {
        public Objects Code;
        public Vector2 Position;
        public Vector2 Velocity;
        public State State { get; set; }
        public bool MovementEnabled { get; set; } = true;
        //Will update very PUSH update. (Which is configurable how fast)
        public Push QueuedPush { get { return _queuedPush; } }
        //Will be true if waiting for release.
        public bool waitToBeReleased = false;
        public bool Trapped = false;

        private Push _queuedPush { get; set; } = null;

        protected Entity(Objects code, Sprite North, Sprite East, Sprite South, Sprite West) : base (North, East, South, West)
        {
            this.Code = code;
        }
        public virtual void Kill(Objects killedBy) {
            State = State.Dead;
            //Don't draw
        }
        public void Revive()
        {
            State = State.Alive;
            Velocity = new Vector2(0,0);
        }
        /// <summary>
        /// Moves the entity N tile.
        /// </summary>
        /// <param name="velocity"></param>
        public virtual bool Move(Vector2 velocity)
        {
            bool move = false;
            if (this.State != State.Dead && MovementEnabled && _queuedPush == null)
            {
                Velocity += velocity;

                //We should probably have a handler or something for this...
                //Idk.

                if (CheckMoveFromThisTile())
                { //Can entity move from current tile?
                    if (CheckMoveToTile())
                    { //Can entity move to the tile it wants?
                        Position += (Velocity * 32);
                        ChangeDirection(GeneralUtilities.VelocityToFacing(velocity));
                        move = true;

                        if (this is Player)
                            ChipGame.PlayerMoved(this as Player);
                    }
                }
                
                Vector2 oldVelocity = Velocity;
                Velocity = Vector2.Zero;

                //Well, this is used for the force items, but with no delay, this will look to be instant...
                FireHasMoved(oldVelocity);
            } else if (_queuedPush != null && _queuedPush.Type == PushType.FORCE)
            {
                _queuedPush.QueuedMove = velocity;
            }
            return move;
        }

        private Status UpdateTile(Vector2 position)
        {
            return ChipGame.UpdateTile(position);
        }
        private void FireHasMoved(Vector2 oldVelocity)
        {
            List<ChipObject> touchedObjects = ChipGame.CheckCollision(Position);
            foreach (ChipObject item in touchedObjects)
            {
                item.HasMovedTo(this, oldVelocity);
            }
        }

        private bool CheckMoveFromThisTile()
        {
            bool move = true;
            List<ChipObject> touchedObjects = ChipGame.CheckCollision(Position);

            foreach (ChipObject item in touchedObjects)
            {
                if (!item.MovingFrom(this))
                    move = false;
            }
            UpdateTile(Position);
            return move;
        }
        private bool CheckMoveToTile()
        {
            bool move = true;
            List<ChipObject> touchedObjects = ChipGame.CheckCollision(Position + (Velocity * 32));

            foreach (ChipObject item in touchedObjects)
            {
                if (!item.MovingTo(this))
                    move = false;
            }
            if (UpdateTile(Position + (Velocity * 32)) == Status.MoveBlocked)
                move = false;
            return move;
        }
        public void AddPush(Push push)
        {
            _queuedPush = push;
        }
        public void HandlePush()
        {
            if (_queuedPush != null)
            {
                if (_queuedPush.Type == PushType.ICE && this is Player)
                    ChipGame.thisPlayerInput.DisableInput();

                Vector2 savedPush = _queuedPush.Velocity + _queuedPush.QueuedMove;
                _queuedPush = null;
                if (!Move(savedPush) && _queuedPush.Type == PushType.ICE)
                {
                    _queuedPush = null;
                    Move(new Vector2(-savedPush.X, -savedPush.Y));
                }

                if ((_queuedPush == null || _queuedPush.Type == PushType.FORCE) && this is Player)
                    ChipGame.thisPlayerInput.EnableInput();
            }
        }
        public void ReleaseEntity()
        {
            Trapped = false;
            waitToBeReleased = false;
        }
        public void TrapEntity()
        {
            Trapped = true;
        }
    }
}
