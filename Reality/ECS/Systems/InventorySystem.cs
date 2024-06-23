using Microsoft.Xna.Framework;
using Reality.ECS.Components.ComponentsService;
using Reality.ECS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Systems
{
    internal class InventorySystem : ISystem
    {
        public void Update(List<Entity> entities, GameTime gameTime)
        {
            // In a real game, you might handle picking up items, using items, etc. here
            throw new NotImplementedException();
        }
        public void AddItem(Entity entity, Item item)
        {
            if (entity.HasComponent<InventoryComponent>())
            {
                var inventory = entity.GetComponent<InventoryComponent>();
                inventory.Items.Add(item);
            }
        }

        public void RemoveItem(Entity entity, Item item)
        {
            if (entity.HasComponent<InventoryComponent>())
            {
                var inventory = entity.GetComponent<InventoryComponent>();
                inventory.Items.Remove(item);
            }
        }
    }
}
