using Cm_5_Lb_2.Core;
using System;

namespace Cm_5_Lb_2.Renderers
{
    public class LeaderRenderer
    {
        public void RenderDetails()
        {
            var leader = ClanLeader.Instance;

            Console.WriteLine("\n===== ІНФОРМАЦІЯ ПРО ГЛАВУ КЛАНУ =====");
            Console.WriteLine($"Титул:       {leader.Title}");
            Console.WriteLine($"Координати:  [X:{leader.Unit.X}, Y:{leader.Unit.Y}]");
            Console.WriteLine($"Озброєння:   {leader.Unit.Weapon.Name} (Шкода: {leader.Unit.Weapon.Damage})");
            Console.WriteLine($"Пересування: {leader.Unit.Movement.Name} (Швидкість: {leader.Unit.Movement.Speed})");
            Console.WriteLine("======================================\n");
        }
    }
}
