using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_2.Renderers
{
    public class TextRenderer : IRenderer
    {
        public void RenderUnits(List<ICharacter> units, ClanLeader leader, int width, int height)
        {
            var regularUnits = leader == null
                ? units
                : units.Where(u => u != leader.Unit).ToList();

            Console.WriteLine("=== СКЛАД (БЕЗ УРАХУВАННЯ ГЛАВИ) ===");

            foreach (var group in regularUnits.GroupBy(u => u.RaceType))
            {
                Console.WriteLine($"\n--- Загін: {EnumExtensions.ToUaString(group.Key)} ({group.Count()} од.) ---");
                foreach (var unit in group)
                {
                    Console.WriteLine($"[{(char)unit.Symbol}] [{unit.X}, {unit.Y}] | Зброя: {unit.Weapon.Name} | {string.Join(", ", unit.Traits)}");
                }
            }
        }

        public void RenderLeader(ClanLeader leader)
        {
            Console.WriteLine("\n===== ІНФОРМАЦІЯ ПРО ГЛАВУ КЛАНУ =====");
            Console.WriteLine($"Титул:       {leader.Title}");
            Console.WriteLine($"Координати:  [X:{leader.Unit.X}, Y:{leader.Unit.Y}]");
            Console.WriteLine($"Озброєння:   {leader.Unit.Weapon.Name} (Шкода: {leader.Unit.Weapon.Damage})");
            Console.WriteLine($"Пересування: {leader.Unit.Movement.Name} (Швидкість: {leader.Unit.Movement.Speed})");
            Console.WriteLine($"Особливості: {string.Join(", ", leader.Unit.Traits)}");
            Console.WriteLine("======================================\n");
        }
    }
}
