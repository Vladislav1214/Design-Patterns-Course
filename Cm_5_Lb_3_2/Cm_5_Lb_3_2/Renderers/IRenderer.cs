using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Renderers
{
    // Bridge: Implementor — "як" виводити.
    // Главу рендерер отримує ззовні
    public interface IRenderer
    {
        void RenderUnits(List<ICharacter> units, ClanLeader leader, int width, int height);
        void RenderLeader(ClanLeader leader);
    }
}
