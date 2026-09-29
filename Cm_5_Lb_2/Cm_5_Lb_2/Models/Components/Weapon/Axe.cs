using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Components.Weapon
{
    public class Axe : IWeapon 
    {
        public WeaponType Type => WeaponType.Axe;
        public string Name => "Бойова сокира"; 
        public int Damage => 30;
    }
}
