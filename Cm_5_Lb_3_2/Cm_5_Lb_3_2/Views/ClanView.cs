using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Renderers;
using System;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Views
{
    // Bridge: Abstraction — "що" виводити; тримає Implementor (IRenderer)
    public abstract class ClanView
    {
        protected readonly IRenderer Renderer;

        protected ClanView(IRenderer renderer)
        {
            Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public abstract void Show(List<ICharacter> clan, ClanLeader leader, int width, int height);
    }
}
