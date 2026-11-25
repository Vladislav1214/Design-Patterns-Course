using Cm_5_Lb_2.Models.Characters;
using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_2.Models.Decorators
{
    public class ColorDecorator : CharacterDecorator
    {
        public string Color { get; }
        public ColorDecorator(ICharacter inner, string color) : base(inner) { Color = color; }
        public override IReadOnlyList<string> Traits => Inner.Traits.Concat(new[] { $"колір: {Color}" }).ToList();
        protected override ICharacter Rewrap(ICharacter inner) => new ColorDecorator(inner, Color);
    }
}
