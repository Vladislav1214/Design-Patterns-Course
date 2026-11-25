using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Renderers
{
    public class GridRenderer : IRenderer
    {
        public void RenderUnits(List<ICharacter> units, ClanLeader leader, int width, int height)
        {
            char[,] grid = new char[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    grid[x, y] = '.';

            foreach (var unit in units)
                grid[unit.X, unit.Y] = (char)unit.Symbol;

            // Глава малюється, тільки якщо він серед переданих юнітів
            if (leader != null && units.Contains(leader.Unit))
                grid[leader.Unit.X, leader.Unit.Y] = (char)UnitSymbol.Leader;

            Console.WriteLine("\n=== ГРАФІЧНЕ ПОЛЕ БОЮ ===");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write($"[{grid[x, y]}] ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Легенда: [{(char)UnitSymbol.Warrior}]-{Race.Warrior.ToUaString()}, " +
                              $"[{(char)UnitSymbol.Elf}]-{Race.Elf.ToUaString()}, " +
                              $"[{(char)UnitSymbol.Dwarf}]-{Race.Dwarf.ToUaString()}, " +
                              $"[{(char)UnitSymbol.Leader}]-Лідер клану\n");
        }

        public void RenderLeader(ClanLeader leader)
        {
            Console.WriteLine($"[{(char)UnitSymbol.Leader}] {leader.Title} у [{leader.Unit.X}, {leader.Unit.Y}] | {string.Join(", ", leader.Unit.Traits)}");
        }
    }
}
