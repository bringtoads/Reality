using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Reality.ECS.Scenes
{
    public class StoryScene : Scene
    {
        private SpriteFont _font;
        private string _storyText = "In the beginning, two kingdoms clashed for power: Zeneya, a land of advanced technology, and Hamdil, home of ancient wisdom and mastery of the Chakra, the circle of life.\r\n\r\nAmidst the turmoil, the prince of Zeneya, raised to despise the Hamdilans, lost his memory during a fierce battle with monsters.\r\n\r\nSaved by the very people he was taught to hate, he began a new life in Hamdil, learning their ways and hunting the monsters that threatened them.\r\n\r\nUnbeknownst to him, the prince's journey would uncover hidden truths about his own kingdom's dark past and the true nature of the Hamdilans.";
        private TimeSpan _displayTime = TimeSpan.FromSeconds(5);
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public StoryScene(MainGame game) : base(game) { }

        public override void LoadContent()
        {
            _font = game.Content.Load<SpriteFont>("inFont");
        }

        public override void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;
            if (_elapsedTime >= _displayTime)
            {
                game.SceneManager.ChangeScene(new WorldScene(game));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.SpriteBatch.Begin();
            game.SpriteBatch.DrawString(_font, _storyText, new Vector2(50, 50), Color.White);
            game.SpriteBatch.End();
        }
    }

}
