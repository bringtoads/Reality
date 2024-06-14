using Microsoft.Xna.Framework;
using Reality.ECS.Components.ComponentsServicec;
using Reality.ECS.Entities;
using Reality.ECS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Systems
{
    public class CombatSystem : GameSystem
    {
        private EntityManager _entityManager;

        public CombatSystem(EntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var health = entity.GetComponent<HealthComponent>();
                var monster = entity.GetComponent<MonsterComponent>();

                if (health != null && health.CurrentHealth <= 0 && monster != null)
                {
                    var player = GetPlayerEntity(entities);
                    if (player != null)
                    {
                        var playerGold = player.GetComponent<GoldComponent>();
                        var playerExp = player.GetComponent<ExpComponent>();

                        if (playerGold != null) playerGold.Amount += monster.GoldReward;
                        if (playerExp != null) playerExp.Amount += monster.ExpReward;
                    }

                    // Remove the defeated monster entity
                    _entityManager.RemoveEntity(entity);
                }
            }
        }

        private Entity GetPlayerEntity(List<Entity> entities)
        {
            return entities.FirstOrDefault(e => e.HasComponent<PlayerComponent>());
        }
    }

}
