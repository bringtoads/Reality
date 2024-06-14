using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Managers
{
    public class EntityManager
    {
        private readonly List<Entity> _entities = new List<Entity>();

        public Entity CreateEntity()
        {
            var entity = new Entity();
            _entities.Add(entity);
            return entity;
        }

        public void CreateEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<Entity> GetAllEntities()
        {
            return _entities;
        }
    }

}
