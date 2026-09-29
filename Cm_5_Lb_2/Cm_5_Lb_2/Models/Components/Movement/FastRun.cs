using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Components.Movement
{
    public class FastRun : IMovement 
    {
        public MovementType Type => MovementType.FastRun;
        public string Name => "Швидкий біг";
        public int Speed => 3;
    }
}
