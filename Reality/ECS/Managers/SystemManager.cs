using Microsoft.Xna.Framework;
using Reality.ECS.Entities;
using Reality.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Managers
{
    internal class SystemManager
    {
        private List<ISystem> _systems = new List<ISystem>();

        public void AddSystem(ISystem system)
        {
            _systems.Add(system);
        }

        public void UpdateAllSystems(List<Entity> entities, GameTime gameTime)
        {
            foreach (var system in _systems)
            {
                system.Update(entities, gameTime);
            }
        }
    }
}
