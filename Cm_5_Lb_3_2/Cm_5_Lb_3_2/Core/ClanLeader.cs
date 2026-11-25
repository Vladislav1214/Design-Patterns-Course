using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Enums;
using System;

namespace Cm_5_Lb_2.Core
{
    // Singleton: у грі рівно один глава клану.
    public sealed class ClanLeader
    {
        private static ClanLeader _instance;

        public ICharacter Unit { get; }
        public string Title { get; }

        private ClanLeader(ICharacter unit)
        {
            Unit = unit;
            Title = $"Верховний {unit.RaceType.ToUaString()}-Лідер";
        }

        public static ClanLeader Instance
        {
            get
            {
                if (_instance == null)
                    throw new InvalidOperationException("Главу клану ще не призначено. Спочатку викличте ClanLeader.Appoint().");
                return _instance;
            }
        }

        public static ClanLeader Appoint(ICharacter unit)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            if (_instance != null)
                throw new InvalidOperationException("Главу клану вже призначено, він може бути лише один.");

            _instance = new ClanLeader(unit);
            return _instance;
        }
    }
}
