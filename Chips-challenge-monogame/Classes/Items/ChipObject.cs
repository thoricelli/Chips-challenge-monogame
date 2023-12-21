using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public /*abstract*/ class ChipObject
    {
        /*
         REFER to https://www.seasip.info/ccfile.html
         */
        public Objects code;
        
        public Sprite Sprite;

        //This field, allows the class to mutate itself on the next update
        //If a Chip gets picked up and needs to change to a tile, then it'll use this.
        public Objects? ChangeInto { get { return changeInto; } }
        //This field will allow the entity to move itself to another tile
        //The value will be the direction it moves to on the next update.
        public Vector2? GoToDirection { get { return goToDirection; } }

        private Objects? changeInto = null;
        private Vector2? goToDirection = null;
        public ChipObject(Objects code, Sprite sprite)
        {
            this.code = code;
            Sprite = sprite;
        }

        public ChipObject(Objects code)
        {
            this.code = code;
            Sprite = new Sprite(InGameState.spritesheet, 1, (int)code); //REPLACE THIS LATER!
        }
        /// <summary>
        /// Fired when the object is touched by a entity
        /// </summary>
        /// <param name="entity">Entity that is going to move to this tile</param>
        /// <returns>If the entity can move through it</returns>
        public virtual bool MovingTo(Entity entity) {
            return true;
        }
        /// <summary>
        /// Fired when an entity moves to another tile.
        /// </summary>
        /// <param name="entity">Entity that moves from this tile</param>
        /// <returns>If the entity can move from the current tile</returns>
        public virtual bool MovingFrom(Entity entity)
        {
            return true;
        }
        /// <summary>
        /// Fired when an entity has succesfully moved to a tile.
        /// </summary>
        /// <param name="entity">Entity that moved onto this tile</param>
        public virtual void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {

        }
        /// <summary>
        /// Fired when a tile wants to move position.
        /// </summary>
        /// <param name="obj">The object it's moving to</param>
        /// <returns>Returns the item that it has to turn into. Null if you can't move.</returns>
        public virtual Objects? TileMove(Objects obj)
        {
            switch (obj)
            {
                case Objects.EMPTY:
                    return code;
                default:
                    return null;
            }
        }
        public virtual void ChangeObjectInto(Objects? obj)
        {
            changeInto = obj;
        }
        public virtual void MoveObjectInDirection(Vector2? direction)
        {
            goToDirection = direction;
        }
    }
}
