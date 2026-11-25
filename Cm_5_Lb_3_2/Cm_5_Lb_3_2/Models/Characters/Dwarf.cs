using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;

namespace Cm_5_Lb_2.Models.Characters
{
    public class Dwarf : Character
    {
        public override Race RaceType => Race.Dwarf;
        public override UnitSymbol Symbol => UnitSymbol.Dwarf;

        public Dwarf(IWeapon weapon, IMovement movement) : base(weapon, movement) { }
    }
}
