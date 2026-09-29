using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Characters
{
    public class Dwarf : ICharacter
    {
        public Race RaceType => Race.Dwarf;
        public UnitSymbol Symbol => UnitSymbol.Dwarf;
        public int X { get; set; }
        public int Y { get; set; }
        public IWeapon Weapon { get; private set; }
        public IMovement Movement { get; private set; }

        public Dwarf(IWeapon weapon, IMovement movement)
        {
            Weapon = weapon;
            Movement = movement;
        }

        public ICharacter Clone() => (ICharacter)this.MemberwiseClone();
    }
}
