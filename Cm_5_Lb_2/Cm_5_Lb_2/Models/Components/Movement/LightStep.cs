using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Components.Movement
{
    public class LightStep : IMovement 
    { 
        public MovementType Type => MovementType.LightStep;
        public string Name => "Легкий крок";
        public int Speed => 2;
    }
}
