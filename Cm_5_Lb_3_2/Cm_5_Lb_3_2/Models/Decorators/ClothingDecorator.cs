using Cm_5_Lb_2.Models.Characters;
using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_2.Models.Decorators
{
    public class ClothingDecorator : CharacterDecorator
    {
        public string Clothing { get; }
        public ClothingDecorator(ICharacter inner, string clothing) : base(inner) { Clothing = clothing; }
        public override IReadOnlyList<string> Traits => Inner.Traits.Concat(new[] { $"одяг: {Clothing}" }).ToList();
        protected override ICharacter Rewrap(ICharacter inner) => new ClothingDecorator(inner, Clothing);
    }
}
