using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Reality.ECS.Entities;
using System;
using Reality.ECS.Components.ComponentsService;
using Microsoft.Xna.Framework.Input;

namespace Reality.ECS.Scenes
{
    public class BattleScene : Scene
    {
        private Entity _playerEntity;
        private SpriteFont _font;
        private Entity _monsterEntity;

        public BattleScene(MainGame game, Entity playerEntity) : base(game)
        {
            _playerEntity = playerEntity;
        }

        public override void LoadContent()
        {
            _font = game.Content.Load<SpriteFont>("inFont");
            _monsterEntity = CreateMonsterEntity(game);
        }

        public override void Update(GameTime gameTime)
        {
            // Handle battle logic
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                // Fight logic
                // Award gold and exp
                game.SceneManager.ChangeScene(new WorldScene(game));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                // Run logic (chance-based)
                if (new Random().NextDouble() < 0.5) // 50% chance to run
                {
                    game.SceneManager.ChangeScene(new WorldScene(game));
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.SpriteBatch.Begin();
            game.SpriteBatch.DrawString(_font, "Battle! Press F to Fight, R to Run", new Vector2(50, 50), Color.White);
            game.SpriteBatch.End();
        }

        private Entity CreateMonsterEntity(MainGame game)
        {
            var monsterEntity = new Entity();
            monsterEntity.AddComponent(new PositionComponent { X = 200, Y = 200 });
            monsterEntity.AddComponent(new SpriteComponent { Texture = game.Content.Load<Texture2D>("joker") });
            monsterEntity.AddComponent(new PowerComponent(50));
            game.EntityManager.CreateEntity(monsterEntity);
            return monsterEntity;
        }
    }

}