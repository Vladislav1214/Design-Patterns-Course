using Cm_5_Lb_2.Models.Characters;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Renderers
{
    public interface IRenderer
    {
        void Render(List<ICharacter> clan, int width, int height);
    }
}
