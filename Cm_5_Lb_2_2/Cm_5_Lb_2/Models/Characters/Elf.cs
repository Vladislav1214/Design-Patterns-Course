using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;

namespace Cm_5_Lb_2.Models.Characters
{
    public class Elf : Character
    {
        public override Race RaceType => Race.Elf;
        public override UnitSymbol Symbol => UnitSymbol.Elf;

        public Elf(IWeapon weapon, IMovement movement) : base(weapon, movement) { }
    }
}
