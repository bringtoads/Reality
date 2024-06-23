using Microsoft.Xna.Framework;
using Reality.ECS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Systems
{
    internal interface ISystem
    {
        void Update(List<Entity> entities, GameTime gameTime);
    }
}
