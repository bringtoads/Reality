using Microsoft.Xna.Framework;
using Reality.ECS.Components.ComponentsService;
using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Systems
{
    public class MovementSystem : GameSystem , ISystem
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

        public void Update(List<Entity> entities, GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                if (entity.HasComponent<PositionComponent>() && entity.HasComponent<VelocityComponent>())
                {
                    var position = entity.GetComponent<PositionComponent>();
                    var velocity = entity.GetComponent<VelocityComponent>();

                    position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    position.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }
    }


}
