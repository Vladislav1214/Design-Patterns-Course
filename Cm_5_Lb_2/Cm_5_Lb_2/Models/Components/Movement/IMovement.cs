using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Components
{
    public interface IMovement
    {
        MovementType Type { get; }
        string Name { get; }
        int Speed { get; }
    }
}
