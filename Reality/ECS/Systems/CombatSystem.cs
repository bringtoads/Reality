using Microsoft.Xna.Framework;
using Reality.ECS.Components.ComponentsService;
using Reality.ECS.Entities;
using Reality.ECS.Managers;
using System.Collections.Generic;
using System.Linq;

namespace Reality.ECS.Systems
{
    public class CombatSystem : ISystem 
    {
        //private EntityManager _entityManager;

        //public CombatSystem(EntityManager entityManager)
        //{
        //    _entityManager = entityManager;
        //}

        //public override void Update(GameTime gameTime, List<Entity> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        var health = entity.GetComponent<HealthComponent>();
        //        var monster = entity.GetComponent<MonsterComponent>();

        //        if (health != null && health.CurrentHealth <= 0 && monster != null)
        //        {
        //            var player = GetPlayerEntity(entities);
        //            if (player != null)
        //            {
        //                var playerGold = player.GetComponent<GoldComponent>();
        //                var playerExp = player.GetComponent<ExpComponent>();

        //                if (playerGold != null) playerGold.Amount += monster.GoldReward;
        //                if (playerExp != null) playerExp.Amount += monster.ExpReward;
        //            }

        //            // Remove the defeated monster entity
        //            _entityManager.RemoveEntity(entity);
        //        }
        //    }
        //}

        //public void Update(List<Entity> entities, GameTime gameTime)
        //{
        //    throw new System.NotImplementedException();
        //}

        //private Entity GetPlayerEntity(List<Entity> entities)
        //{
        //    return entities.FirstOrDefault(e => e.HasComponent<PlayerComponent>());
        //}

        public void Update(List<Entity> entities, GameTime gameTime)
        {
            // Simplified combat logic
            // In a real game, you'd have more complex logic for detecting collisions, etc.
            foreach (var entity1 in entities)
            {
                if (entity1.HasComponent<StatsComponent>())
                {
                    foreach (var entity2 in entities)
                    {
                        if (entity1 != entity2 && entity2.HasComponent<StatsComponent>())
                        {
                            if (IsColliding(entity1, entity2))
                            {
                                PerformCombat(entity1, entity2);
                            }
                        }
                    }
                }
            }
        }

        private bool IsColliding(Entity entity1, Entity entity2)
        {
            // Simplified collision detection
            var pos1 = entity1.GetComponent<PositionComponent>();
            var pos2 = entity2.GetComponent<PositionComponent>();
            return Vector2.Distance(new Vector2(pos1.X, pos1.Y), new Vector2(pos2.X, pos2.Y)) < 32; // Assuming 32 pixel collision radius
        }

        private void PerformCombat(Entity attacker, Entity defender)
        {
            var attackerStats = attacker.GetComponent<StatsComponent>();
            var defenderStats = defender.GetComponent<StatsComponent>();

            int damage = attackerStats.Attack - defenderStats.Defense;
            if (damage > 0)
            {
                defenderStats.Health -= damage;
            }
        }
    }

}
