using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reality
{
    internal class MovingSprite : ScaledSprite
    {
        private float _speed;
        public MovingSprite(Texture2D texture, Vector2 position, float speed) : base(texture, position)
        {
            _speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            //base.Update();
            _position.X += _speed;
        }
    }
}
