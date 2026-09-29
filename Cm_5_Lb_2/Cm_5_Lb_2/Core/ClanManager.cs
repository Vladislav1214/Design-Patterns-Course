using Cm_5_Lb_2.Factories;
using Cm_5_Lb_2.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2.Core
{
    public class ClanManager
    {
        private readonly IClanFactory _factory;
        private readonly Random _random = new Random();

        public ClanManager(IClanFactory factory)
        {
            _factory = factory;
        }

        public List<ICharacter> GenerateClan(int fieldWidth, int fieldHeight)
        {
            var clan = new List<ICharacter>();

            SpawnGroup(clan, () => _factory.CreateWarrior(), _random.Next(3, 8), fieldWidth / 2, fieldWidth, fieldHeight);
            SpawnGroup(clan, () => _factory.CreateElf(), _random.Next(3, 8), 0, fieldWidth / 3, fieldHeight);
            SpawnGroup(clan, () => _factory.CreateDwarf(), _random.Next(3, 8), fieldWidth / 3, fieldWidth / 2, fieldHeight);

            ClanLeader.Reset();
            var randomUnit = clan[_random.Next(clan.Count)];
            ClanLeader.GetInstance(randomUnit);

            return clan;
        }

        private void SpawnGroup(List<ICharacter> clan, Func<ICharacter> createUnit, int count, int minX, int maxX, int maxHeight)
        {
            for (int i = 0; i < count; i++)
            {
                var unit = createUnit();
                unit.X = _random.Next(minX, maxX);
                unit.Y = _random.Next(0, maxHeight);
                clan.Add(unit);
            }
        }
    }
}
