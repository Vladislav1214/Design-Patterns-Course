using Cm_5_Lb_2.Models.Characters;
using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_2.Models.Decorators
{
    public class HeightDecorator : CharacterDecorator
    {
        public int Height { get; }
        public HeightDecorator(ICharacter inner, int height) : base(inner) { Height = height; }
        public override IReadOnlyList<string> Traits => Inner.Traits.Concat(new[] { $"зріст: {Height} см" }).ToList();
        protected override ICharacter Rewrap(ICharacter inner) => new HeightDecorator(inner, Height);
    }
}
