using Reality.ECS.Components.IComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Components.ComponentsService
{
    internal class StatsComponent : IComponent
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    }
}
