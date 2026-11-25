using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Renderers;
using System;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Views
{
    // Весь клан + окремо глава
    public class FullClanView : ClanView
    {
        public FullClanView(IRenderer renderer) : base(renderer) { }

        public override void Show(List<ICharacter> clan, ClanLeader leader, int width, int height)
        {
            if (leader == null) throw new ArgumentNullException(nameof(leader));

            Renderer.RenderUnits(clan, leader, width, height);
            Renderer.RenderLeader(leader);
        }
    }
}
