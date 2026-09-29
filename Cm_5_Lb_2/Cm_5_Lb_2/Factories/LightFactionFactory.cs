using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Components.Movement;
using Cm_5_Lb_2.Models.Components.Weapon;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Factories
{
    public class LightFactionFactory : IClanFactory
    {
        private readonly ICharacter _warriorPrototype;
        private readonly ICharacter _elfPrototype;
        private readonly ICharacter _dwarfPrototype;

        public LightFactionFactory()
        {
            _warriorPrototype = new Warrior(new Sword(), new FastRun());
            _elfPrototype = new Elf(new Bow(), new LightStep());
            _dwarfPrototype = new Dwarf(new Axe(), new HeavyWalk());
        }

        public ICharacter CreateWarrior() => _warriorPrototype.Clone();
        public ICharacter CreateElf() => _elfPrototype.Clone();
        public ICharacter CreateDwarf() => _dwarfPrototype.Clone();
    }
}
