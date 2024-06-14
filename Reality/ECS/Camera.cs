using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reality.ECS
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        private Vector2 center;
        private Viewport viewport;

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
        }

        public void Update(Vector2 playerPosition)
        {
            center = new Vector2(playerPosition.X - (viewport.Width / 2), playerPosition.Y - (viewport.Height / 2));
            Transform = Matrix.CreateTranslation(new Vector3(-center, 0));
        }
    }

}
