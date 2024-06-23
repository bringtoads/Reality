using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reality.ECS.Components.ComponentsService;
using Reality.ECS.Entities;
using System.Collections.Generic;

namespace Reality.ECS.Systems
{
    public class SpriteSystem : GameSystem
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Camera _camera;

        public SpriteSystem(SpriteBatch spriteBatch, Camera camera)
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            foreach (var entity in entities)
            {
                var position = entity.GetComponent<PositionComponent>();
                var sprite = entity.GetComponent<SpriteComponent>();

                if (position != null && sprite != null)
                {
                    _spriteBatch.Draw(sprite.Texture, new Vector2(position.X, position.Y),
                    Color.White);
                }
            }

            _spriteBatch.End();
        }
    }

}
