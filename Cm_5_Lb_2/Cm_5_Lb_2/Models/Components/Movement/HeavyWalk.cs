using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Components.Movement
{
    public class HeavyWalk : IMovement 
    {
        public MovementType Type => MovementType.HeavyWalk;
        public string Name => "Важка хода";
        public int Speed => 1;
    }
}
