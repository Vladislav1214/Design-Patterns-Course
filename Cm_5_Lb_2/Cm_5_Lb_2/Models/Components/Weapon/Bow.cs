using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Components.Weapon
{
    public class Bow : IWeapon
    {
        public WeaponType Type => WeaponType.Bow;
        public string Name => "Довгий лук";
        public int Damage => 15;
    }
}
