using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;

namespace Cm_5_Lb_2.Models.Characters
{
    // Спільна частина всіх гравців: позиція, зброя, пересування, клонування
    public abstract class Character : ICharacter
    {
        public abstract Race RaceType { get; }
        public abstract UnitSymbol Symbol { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public IWeapon Weapon { get; }
        public IMovement Movement { get; }

        protected Character(IWeapon weapon, IMovement movement)
        {
            Weapon = weapon;
            Movement = movement;
        }

        // Поверхневе копіювання безпечне: зброя й пересування незмінні, X/Y — значення
        public ICharacter Clone() => (ICharacter)MemberwiseClone();
    }
}
