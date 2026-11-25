using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Components.Movement;
using Cm_5_Lb_2.Models.Components.Weapon;

namespace Cm_5_Lb_2.Factories
{
    // Конкретна фабрика. Тримає прототипи й видає їхні клони (Prototype)
    public class DarkFactionFactory : IClanFactory
    {
        private readonly ICharacter _warriorPrototype;
        private readonly ICharacter _elfPrototype;
        private readonly ICharacter _dwarfPrototype;

        public string Name => "Темний клан";

        public DarkFactionFactory()
        {
            _warriorPrototype = new Warrior(new Spear(), new HeavyWalk());
            _elfPrototype = new Elf(new Dagger(), new FastRun());
            _dwarfPrototype = new Dwarf(new Hammer(), new LightStep());
        }

        public ICharacter CreateWarrior() => _warriorPrototype.Clone();
        public ICharacter CreateElf() => _elfPrototype.Clone();
        public ICharacter CreateDwarf() => _dwarfPrototype.Clone();
    }
}
