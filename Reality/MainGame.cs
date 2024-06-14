using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Reality.ECS.Managers;
using Reality.ECS.Scenes;
using System.Collections.Generic;
using Reality.ECS.Systems;
using System.Linq;
using Reality.ECS;
using Microsoft.Xna.Framework.Input;
using System;

namespace Reality
{
    public class MainGame : Game
    {
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public SceneManager SceneManager;
        public EntityManager EntityManager;
        public List<GameSystem> Systems;

        //showing fps
        private SpriteFont _font;
        private int _fps;
        private int _frameCount;
        private TimeSpan _elapsedTime;
        private const int FPS_UPDATE_INTERVAL = 1000; // Update FPS every 1 second

        public MainGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Graphics.PreferredBackBufferWidth = 1500; // Your desired width
            Graphics.PreferredBackBufferHeight = 1000; // Your desired height
            Graphics.ApplyChanges();// Apply the changes

            base.Initialize();
           
            EntityManager = new EntityManager();
            Systems = new List<GameSystem>();
            SceneManager = new SceneManager();

            // Instantiate and add your systems here
            Systems.Add(new CombatSystem(EntityManager));
            Systems.Add(new PowerSystem());
            Systems.Add(new MovementSystem());
            Systems.Add(new SpriteSystem(SpriteBatch, new Camera(Graphics.GraphicsDevice.Viewport)));


            SceneManager.ChangeScene(new SplashScreenScene(this));
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("inFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            SceneManager.Update(gameTime);
            foreach (var system in Systems)
            {
                system.Update(gameTime, EntityManager.GetAllEntities().ToList());
            }

            // Calculate FPS
            _elapsedTime += gameTime.ElapsedGameTime;
            _frameCount++;

            if (_elapsedTime >= TimeSpan.FromMilliseconds(FPS_UPDATE_INTERVAL))
            {
                _fps = _frameCount * 1000 / FPS_UPDATE_INTERVAL;
                _frameCount = 0;
                _elapsedTime -= TimeSpan.FromMilliseconds(FPS_UPDATE_INTERVAL);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Draw(gameTime);

            // Draw FPS
            SpriteBatch.Begin();
            string fpsText = $"FPS: {_fps}";
            Vector2 fpsPosition = new Vector2(10, 10); // Adjust position as needed
            SpriteBatch.DrawString(_font, fpsText, fpsPosition, Color.White);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }


}
