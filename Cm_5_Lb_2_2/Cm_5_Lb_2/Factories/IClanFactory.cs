using Cm_5_Lb_2.Models.Characters;

namespace Cm_5_Lb_2.Factories
{
    // Abstract Factory: сімейство продуктів — воїн, ельф, гном
    public interface IClanFactory
    {
        string Name { get; }
        ICharacter CreateWarrior();
        ICharacter CreateElf();
        ICharacter CreateDwarf();
    }
}
