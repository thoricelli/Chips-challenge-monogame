using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Interfaces
{
    public interface IInputHandler
    {
        public void HandleInput();
        public void EnableInput();
        public void DisableInput();
    }
}
