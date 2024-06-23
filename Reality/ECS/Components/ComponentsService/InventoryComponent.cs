using Reality.ECS.Components.IComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Components.ComponentsService
{
    internal class InventoryComponent : IComponent
    {
        public List<Item> Items { get; set; } = new List<Item>();
    }

    internal class Item
    { 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
