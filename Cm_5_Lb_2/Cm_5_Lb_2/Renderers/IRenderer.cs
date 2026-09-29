using Cm_5_Lb_2.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Renderers
{
    public interface IRenderer
    {
        void Render(List<ICharacter> clan, int width, int height);
    }
}
