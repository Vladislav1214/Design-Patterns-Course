using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Enums;
using Cm_5_Lb_2.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_2.Views
{
    // Тільки один загін (за расою).
    // Главу показуємо лише якщо він належить до цього загону.
    public class SquadView : ClanView
    {
        private readonly Race _race;

        public SquadView(IRenderer renderer, Race race) : base(renderer)
        {
            _race = race;
        }

        public override void Show(List<ICharacter> clan, ClanLeader leader, int width, int height)
        {
            if (leader == null) throw new ArgumentNullException(nameof(leader));

            var squad = clan.Where(u => u.RaceType == _race).ToList();
            Renderer.RenderUnits(squad, leader, width, height);

            if (leader.Unit.RaceType == _race)
                Renderer.RenderLeader(leader);
        }
    }
}
