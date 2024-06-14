using Microsoft.Xna.Framework;
using Reality.ECS.Components.ComponentsServicec;
using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Systems
{

    public class PowerSystem : GameSystem
    {
        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var power = entity.GetComponent<PowerComponent>();
                if (power != null)
                {   // Handle power logic (e.g., recharge over time, use power for abilities)
                    power.RechargePower(1); // Example recharge logic
                }
            }
        }
    }

}
