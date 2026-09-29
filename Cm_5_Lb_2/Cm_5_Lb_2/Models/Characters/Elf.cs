using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Characters
{
    public class Elf : ICharacter
    {
        public Race RaceType => Race.Elf;
        public UnitSymbol Symbol => UnitSymbol.Elf;
        public int X { get; set; }
        public int Y { get; set; }
        public IWeapon Weapon { get; private set; }
        public IMovement Movement { get; private set; }

        public Elf(IWeapon weapon, IMovement movement)
        {
            Weapon = weapon;
            Movement = movement;
        }

        public ICharacter Clone() => (ICharacter)this.MemberwiseClone();
    }
}
