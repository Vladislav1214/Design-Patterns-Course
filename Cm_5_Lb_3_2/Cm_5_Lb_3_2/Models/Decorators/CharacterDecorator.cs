using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Models.Decorators
{
    public abstract class CharacterDecorator : ICharacter
    {
        protected readonly ICharacter Inner;

        protected CharacterDecorator(ICharacter inner) { Inner = inner; }

        public Race RaceType => Inner.RaceType;
        public UnitSymbol Symbol => Inner.Symbol;
        public int X { get => Inner.X; set => Inner.X = value; }
        public int Y { get => Inner.Y; set => Inner.Y = value; }
        public IWeapon Weapon => Inner.Weapon;
        public IMovement Movement => Inner.Movement;
        public virtual IReadOnlyList<string> Traits => Inner.Traits;

        // Prototype + Decorator: клон обгортки = та сама обгортка навколо клона внутрішнього об'єкта
        protected abstract ICharacter Rewrap(ICharacter inner);
        public ICharacter Clone() => Rewrap(Inner.Clone());
    }
}
