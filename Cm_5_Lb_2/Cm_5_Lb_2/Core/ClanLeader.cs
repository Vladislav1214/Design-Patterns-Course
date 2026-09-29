using Cm_5_Lb_2.Factories;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Core
{
    public sealed class ClanLeader
    {
        private static ClanLeader _instance;

        public ICharacter Unit { get; private set; }
        public string Title { get; private set; }

        private ClanLeader(ICharacter unit)
        {
            Unit = unit;
            Title = $"Верховний {EnumExtensions.ToUaString(unit.RaceType)}-Лідер";
        }

        public static ClanLeader GetInstance(ICharacter selectedUnit = null)
        {
            if (_instance == null)
            {
                if (selectedUnit == null) throw new ArgumentNullException("Для створення лідера потрібен юніт.");
                _instance = new ClanLeader(selectedUnit);
            }
            return _instance;
        }

        public static void Reset() => _instance = null;
    }
}
