using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;

namespace Cm_5_Lb_2.Models.Characters
{
    public class Warrior : Character
    {
        public override Race RaceType => Race.Warrior;
        public override UnitSymbol Symbol => UnitSymbol.Warrior;

        public Warrior(IWeapon weapon, IMovement movement) : base(weapon, movement) { }
    }
}
