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
        public void Render(List<ICharacter> clan, int width, int height)
        {
            var leader = ClanLeader.Instance;
            var regularUnits = clan.Where(u => u != leader.Unit);

            Console.WriteLine("=== СКЛАД КЛАНУ (БЕЗ УРАХУВАННЯ ГЛАВИ) ===");

            foreach (var group in regularUnits.GroupBy(u => u.RaceType))
            {
                Console.WriteLine($"\n--- Загін: {group.Key.ToUaString()} ({group.Count()} од.) ---");
                foreach (var unit in group)
                {
                    Console.WriteLine($"[{(char)unit.Symbol}] Координати: [{unit.X}, {unit.Y}] | Зброя: {unit.Weapon.Name} | Пересування: {unit.Movement.Name}");
                }
            }
        }
    }
}
