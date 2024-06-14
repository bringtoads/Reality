using Microsoft.Xna.Framework;

namespace Reality.ECS.Scenes
{
    public abstract class Scene
    {
        protected MainGame game;

        public Scene(MainGame game)
        {
            this.game = game;
        }

        public virtual void LoadContent() { }

        public virtual void UnloadContent() { }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }

}
