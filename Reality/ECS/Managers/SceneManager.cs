using Microsoft.Xna.Framework;
using Reality.ECS.Scenes;

namespace Reality.ECS.Managers
{
    // screen and scene are same i just created two folders because i am dumb
    public class SceneManager
    {
        private Scene _currentScene;

        public void ChangeScene(Scene newScene)
        {
            _currentScene?.UnloadContent();
            _currentScene = newScene;
            _currentScene.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            _currentScene?.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _currentScene?.Draw(gameTime);
        }
    }

}
