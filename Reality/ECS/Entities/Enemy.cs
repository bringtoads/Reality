using Reality.ECS.Components.ComponentsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Entities
{
    internal class Enemy : Entity
    {
        public Enemy()
        {
            AddComponent(new PositionComponent());
            AddComponent(new VelocityComponent());
            AddComponent(new SpriteComponent());
            AddComponent(new StatsComponent { Health = 50, MaxHealth = 50, Attack = 5, Defense = 2 });
        }
    }
}
