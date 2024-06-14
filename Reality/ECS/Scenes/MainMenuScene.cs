using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Reality.ECS.Scenes
{
    public class MainMenuScene : Scene
    {
        private SpriteFont _font;

        public MainMenuScene(MainGame game) : base(game) { }

        public override void LoadContent()
        {
            _font = game.Content.Load<SpriteFont>("inFont");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.SceneManager.ChangeScene(new StoryScene(game));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
            game.SpriteBatch.Begin();
            game.SpriteBatch.DrawString(_font, "Press Enter to Start New Game", new Vector2(100, 100), Color.White);
            game.SpriteBatch.DrawString(_font, "Press Esc to Exit", new Vector2(100, 150), Color.White);
            game.SpriteBatch.End();
        }
    }
}
