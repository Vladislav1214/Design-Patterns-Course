using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Models.Enums
{
    public static class EnumExtensions
    {
        public static string ToUaString(this Race race)
        {
            switch (race)
            {
                case Race.Warrior:
                    return "Воїн";
                case Race.Elf:
                    return "Ельф";
                case Race.Dwarf:
                    return "Гном";
                default:
                    return "Невідомо";
            }
        }
    }
}
