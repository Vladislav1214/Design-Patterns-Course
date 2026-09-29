using Cm_5_Lb_2.Models.Components;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Characters
{
    public interface ICharacter
    {
        Race RaceType { get; }
        UnitSymbol Symbol { get; }
        int X { get; set; }
        int Y { get; set; }
        IWeapon Weapon { get; }
        IMovement Movement { get; }

        ICharacter Clone();
    }
}
