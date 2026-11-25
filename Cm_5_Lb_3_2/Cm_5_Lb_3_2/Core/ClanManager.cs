using Cm_5_Lb_2.Factories;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Decorators;
using System;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Core
{
    public class ClanManager
    {
        private readonly IClanFactory _factory;
        private readonly Random _random = new Random();

        private static readonly string[] Colors = { "червоний", "синій", "зелений", "чорний", "білий" };
        private static readonly string[] Clothes = { "броня", "плащ", "роба", "кольчуга" };

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

            ClanLeader.Appoint(clan[_random.Next(clan.Count)]);

            return clan;
        }

        private void SpawnGroup(List<ICharacter> clan, Func<ICharacter> createUnit, int count, int minX, int maxX, int maxHeight)
        {
            for (int i = 0; i < count; i++)
            {
                var unit = Decorate(createUnit());
                unit.X = _random.Next(minX, maxX);
                unit.Y = _random.Next(0, maxHeight);
                clan.Add(unit);
            }
        }

        // Decorator: особливості додаються до внесення в клан і до вибору глави
        private ICharacter Decorate(ICharacter unit)
        {
            unit = new ColorDecorator(unit, Colors[_random.Next(Colors.Length)]);
            unit = new HeightDecorator(unit, _random.Next(150, 200));
            if (_random.Next(2) == 0)
                unit = new ClothingDecorator(unit, Clothes[_random.Next(Clothes.Length)]);
            return unit;
        }
    }
}
