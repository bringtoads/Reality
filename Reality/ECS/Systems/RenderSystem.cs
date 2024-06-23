using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reality.ECS.Components.ComponentsService;
using Reality.ECS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reality.ECS.Systems
{
    internal class RenderSystem : ISystem
    {
        private SpriteBatch _spriteBatch;

        public RenderSystem(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Update(List<Entity> entities, GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                if (entity.HasComponent<PositionComponent>() && entity.HasComponent<SpriteComponent>())
                {
                    var position = entity.GetComponent<PositionComponent>();
                    var sprite = entity.GetComponent<SpriteComponent>();

                    _spriteBatch.Draw(sprite.Texture, new Vector2(position.X, position.Y), Color.White);
                }
            }
        }
    }
}
