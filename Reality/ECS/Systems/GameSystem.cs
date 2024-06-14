using Microsoft.Xna.Framework;
using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Systems
{
    public abstract class GameSystem
    {
        public abstract void Update(GameTime gameTime, List<Entity> entities);
    }

}
