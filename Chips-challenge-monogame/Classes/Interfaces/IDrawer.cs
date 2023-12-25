using CHIPS_CHALLENGE.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Interfaces
{
    public interface IDrawer
    {
        public void Draw();
        public void Zoom(float zoomAmount = 1);
        public void ChangeSubject(Entity entity);
    }
}
