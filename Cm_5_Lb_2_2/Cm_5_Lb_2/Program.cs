using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Factories;
using Cm_5_Lb_2.Renderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int fieldWidth = 12;
            int fieldHeight = 8;

            Console.WriteLine("Оберіть клан: 1 - Світлий, 2 - Темний");
            Console.Write("> ");
            IClanFactory factory = Console.ReadLine() == "2"
                ? (IClanFactory)new DarkFactionFactory()
                : new LightFactionFactory();

            Console.WriteLine($"Генерація: {factory.Name}...");
            var manager = new ClanManager(factory);
            var clan = manager.GenerateClan(fieldWidth, fieldHeight);

            Console.WriteLine("Оберіть режим відображення: 1 - Графічний, 2 - Текстовий, 3 - Обидва");
            Console.Write("> ");
            string choice = Console.ReadLine();

            var renderers = new List<IRenderer>();
            if (choice == "1" || choice == "3") renderers.Add(new GridRenderer());
            if (choice == "2" || choice == "3") renderers.Add(new TextRenderer());

            foreach (var renderer in renderers)
                renderer.Render(clan, fieldWidth, fieldHeight);

            new LeaderRenderer().RenderDetails();

            Console.WriteLine("\nГенерацію завершено.");
        }
    }
}
