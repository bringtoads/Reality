using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Reality.ECS.Scenes
{
    public class SplashScreenScene : Scene
    {
        private Texture2D _splashTexture;
        private TimeSpan _duration = TimeSpan.FromSeconds(3);
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public SplashScreenScene(MainGame game) : base(game) { }

        public override void LoadContent()
        {
            //_splashTexture = game.Content.Load<Texture2D>("SplashScreen");
            _splashTexture = game.Content.Load<Texture2D>("frame_0");
        }

        public override void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;
            if (_elapsedTime >= _duration)
            {
                game.SceneManager.ChangeScene(new MainMenuScene(game));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.SpriteBatch.Begin();
            game.SpriteBatch.Draw(_splashTexture, new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height), Color.White);
            game.SpriteBatch.End();
        }
    }

}
