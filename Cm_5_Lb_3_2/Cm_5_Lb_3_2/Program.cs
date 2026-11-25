using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Factories;
using Cm_5_Lb_2.Models.Enums;
using Cm_5_Lb_2.Renderers;
using Cm_5_Lb_2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cm_5_Lb_2
{
    public class Program
    {
        private const string DefaultClan = "1";   // Світлий
        private const string DefaultMode = "3";   // Обидва виводи
        private const string DefaultScope = "1";  // Весь клан

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int fieldWidth = 12;
            int fieldHeight = 8;

            string clanChoice = ReadChoice(
                "Оберіть клан: 1 - Світлий, 2 - Темний", 
                DefaultClan, "1", "2");

            IClanFactory factory = clanChoice == "2" 
                ? (IClanFactory)new DarkFactionFactory() 
                : new LightFactionFactory();

            Console.WriteLine($"Генерація: {factory.Name}...");
            var manager = new ClanManager(factory);
            var clan = manager.GenerateClan(fieldWidth, fieldHeight);

            var leader = ClanLeader.Instance;

            string mode = ReadChoice(
                "Оберіть режим відображення: 1 - Графічний, 2 - Текстовий, 3 - Обидва", 
                DefaultMode, "1", "2", "3");

            var renderers = new List<IRenderer>();
            if (mode == "1" || mode == "3") renderers.Add(new GridRenderer());
            if (mode == "2" || mode == "3") renderers.Add(new TextRenderer());

            string scope = ReadChoice(
                "Що показати: 1 - Весь клан, 2 - Лише воїнів, 3 - Лише ельфів, 4 - Лише гномів", 
                DefaultScope, "1", "2", "3", "4");

            Race? race = scope switch
            {
                "2" => Race.Warrior,
                "3" => Race.Elf,
                "4" => Race.Dwarf,
                _ => (Race?)null
            };

            foreach (var renderer in renderers)
            {
                ClanView view = race.HasValue
                    ? new SquadView(renderer, race.Value)
                    : new FullClanView(renderer);

                view.Show(clan, leader, fieldWidth, fieldHeight);
            }

            Console.WriteLine("\nГенерацію завершено.");
        }

        private static string ReadChoice(string prompt, string defaultValue, params string[] valid)
        {
            Console.WriteLine($"{prompt} (Enter = {defaultValue})");
            Console.Write("> ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input) || !valid.Contains(input))
            {
                if (!string.IsNullOrEmpty(input))
                    Console.WriteLine($"Невідомий варіант \"{input}\", використано за замовчуванням: {defaultValue}");
                return defaultValue;
            }
            return input;
        }
    }
}