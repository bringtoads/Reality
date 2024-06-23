using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reality.ECS.Managers
{
    internal class ScreenManager
    {
        private Game _game;
        private List<IScreen> _screens = new List<IScreen>();
        private IScreen _currentScreen;

        public ScreenManager(Game game)
        {
            _game = game;
        }

        public void AddScreen(IScreen screen)
        {
            _screens.Add(screen);
        }

        public void SetCurrentScreen(IScreen screen)
        {
            _currentScreen = screen;
        }

        public void LoadContent()
        {
            foreach (var screen in _screens)
            {
                screen.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            _currentScreen?.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen?.Draw(spriteBatch);
        }
    }
}
