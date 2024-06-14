using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reality
{
    internal class ColoredSprite : ScaledSprite
    {
        public Color _color;
        public ColoredSprite(Texture2D texture, Vector2 position,Color color) : base(texture, position)
        {
            _color = color;
        }
    }
}
