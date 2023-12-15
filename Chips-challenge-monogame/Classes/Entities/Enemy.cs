using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public abstract class Enemy : Entity
    {
        //Update enemy movement
        public abstract void Update();
    }
}
