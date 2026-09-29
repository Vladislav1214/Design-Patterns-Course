using Cm_5_Lb_2.Core;
using Cm_5_Lb_2.Factories;
using Cm_5_Lb_2.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int fieldWidth = 12;
            int fieldHeight = 8;

            Console.WriteLine("Ініціалізація генератора кланів...");

            IClanFactory factory = new LightFactionFactory();

            var manager = new ClanManager(factory);
            var clan = manager.GenerateClan(fieldWidth, fieldHeight);

            Console.WriteLine("Оберіть режим відображення: 1 - Графічний, 2 - Текстовий, 3 - Обидва");
            Console.Write("> ");
            string choice = Console.ReadLine();

            List<IRenderer> renderers = new List<IRenderer>();
            if (choice == "1" || choice == "3") renderers.Add(new GridRenderer());
            if (choice == "2" || choice == "3") renderers.Add(new TextRenderer());

            foreach (var renderer in renderers)
            {
                renderer.Render(clan, fieldWidth, fieldHeight);
            }

            var leaderRenderer = new LeaderRenderer();
            leaderRenderer.RenderDetails();

            Console.WriteLine("\nГенерацію завершено.");
        }
    }
}
