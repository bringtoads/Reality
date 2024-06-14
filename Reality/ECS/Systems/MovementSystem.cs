using Microsoft.Xna.Framework;
using Reality.ECS.Components.ComponentsServicec;
using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Systems
{
    public class MovementSystem : GameSystem
    {
        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var position = entity.GetComponent<PositionComponent>();
                var velocity = entity.GetComponent<VelocityComponent>();

                if (position != null && velocity != null)
                {
                    position.X += velocity.VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    position.Y += velocity.VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }
    }


}
