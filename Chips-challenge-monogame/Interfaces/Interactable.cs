using CHIPS_CHALLENGE.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Interfaces
{
    public interface Interactable
    {
        public void EntityTouched(Entity entity);
    }
}
