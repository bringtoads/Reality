using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Managers
{
    public class EntityManager
    {
        private readonly List<Entity> _entities = new List<Entity>();

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        public List<Entity> GetEntities()
        {
            return _entities;
        }
    }

}
