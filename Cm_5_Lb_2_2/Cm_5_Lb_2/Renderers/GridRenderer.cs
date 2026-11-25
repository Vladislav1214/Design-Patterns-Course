using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Models.Characters;
using Cm_5_Lb_2.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cm_5_Lb_2.Renderers
{
    public class GridRenderer : IRenderer
    {
        public void Render(List<ICharacter> clan, int width, int height)
        {
            char[,] grid = new char[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    grid[x, y] = '.';

            foreach (var unit in clan)
                grid[unit.X, unit.Y] = (char)unit.Symbol;

            var leader = ClanLeader.Instance;
            grid[leader.Unit.X, leader.Unit.Y] = (char)UnitSymbol.Leader;

            Console.WriteLine("\n=== ГРАФІЧНЕ ПОЛЕ БОЮ ===");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    Console.Write($"[{grid[x, y]}] ");
                Console.WriteLine();
            }
            Console.WriteLine($"Легенда: [{(char)UnitSymbol.Warrior}]-{Race.Warrior.ToUaString()}, " +
                              $"[{(char)UnitSymbol.Elf}]-{Race.Elf.ToUaString()}, " +
                              $"[{(char)UnitSymbol.Dwarf}]-{Race.Dwarf.ToUaString()}, " +
                              $"[{(char)UnitSymbol.Leader}]-Лідер клану\n");
        }
    }
}
