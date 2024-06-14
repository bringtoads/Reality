using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reality
{
    internal class ScaledSprite : Sprite
    {
        public Rectangle Rect 
        {
            get 
            { 
                return new Rectangle((int)_position.X,(int)_position.Y,100,200); 
            }
        }
        public ScaledSprite(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }
    }
}
