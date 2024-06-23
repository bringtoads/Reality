using Reality.ECS.Components.ComponentsService;

namespace Reality.ECS.Entities
{
    internal class Player : Entity
    {
        public Player()
        {
            AddComponent(new PositionComponent());
            AddComponent(new VelocityComponent());
            AddComponent(new SpriteComponent());
            AddComponent(new StatsComponent { Health = 100, MaxHealth = 100, Attack = 10, Defense = 5 });
            AddComponent(new InventoryComponent());
        }
    }
}
