using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reality.ECS.Components.ComponentsService;
using Reality.ECS.Entities;
using Reality.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Reality.ECS.Scenes
{
    public class WorldScene : Scene
    {
        private Camera _camera;
        private Entity _playerEntity;
        private List<Entity> _trees;
        private Random _random = new Random();
        private MovementSystem _movementSystem;

        private const float PlayerSpeed = 2.0f; // Adjust as needed

        public WorldScene(MainGame game) : base(game)
        {
            _movementSystem = new MovementSystem();
        }

        public override void LoadContent()
        {
            _camera = new Camera(game.GraphicsDevice.Viewport);
            _playerEntity = CreatePlayerEntity(game);
            _playerEntity.AddComponent(new PositionComponent { X = 100, Y = 100 });
            _playerEntity.AddComponent(new VelocityComponent { VelocityX = 0, VelocityY = 0 });

            _trees = CreateTrees(game);
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            var playerPosition = _playerEntity.GetComponent<PositionComponent>();
            var velocity = _playerEntity.GetComponent<VelocityComponent>();

            // Handle player movement
            if (keyboardState.IsKeyDown(Keys.W))
            {
                Debug.WriteLine("w");
                velocity.VelocityY = -PlayerSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                Debug.WriteLine("s");
                velocity.VelocityY = PlayerSpeed;
            }
            else
            {
                velocity.VelocityY = 0;
            }


            if (keyboardState.IsKeyDown(Keys.A))
            {
                Debug.WriteLine("a");
                velocity.VelocityX = -PlayerSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                Debug.WriteLine("d");
                velocity.VelocityX = PlayerSpeed;
            }
            else
            {
                velocity.VelocityX = 0;
            }

            // Update player position based on velocity
            playerPosition.X += velocity.VelocityX;
            playerPosition.Y += velocity.VelocityY;

            // Clamp player position within bounds if needed
            // Example: playerPosition.X = MathHelper.Clamp(playerPosition.X, minX, maxX);
            _movementSystem.Update(gameTime, new List<Entity> { _playerEntity });
            // Check for collision with trees and initiate battle
            if (CheckCollisionWithTrees(_playerEntity))
            {
                if (_random.NextDouble() < 0.1) // 10% chance
                {
                    game.SceneManager.ChangeScene(new BattleScene(game, _playerEntity));
                }
            }

            _camera.Update(new Vector2(playerPosition.X, playerPosition.Y));

            //base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Green);
            game.SpriteBatch.Begin(transformMatrix: _camera.Transform);

            // Draw world
            // Example: game.SpriteBatch.Draw(texture, position, Color.White);

            // Draw trees
            foreach (var tree in _trees)
            {
                var position = tree.GetComponent<PositionComponent>();
                var sprite = tree.GetComponent<SpriteComponent>();
                if (position != null && sprite != null)
                {
                    game.SpriteBatch.Draw(sprite.Texture, new Vector2(position.X, position.Y), Color.White);
                }
            }

            // Draw player
            var playerPosition = _playerEntity.GetComponent<PositionComponent>();
            var playerSprite = _playerEntity.GetComponent<SpriteComponent>();
            if (playerPosition != null && playerSprite != null)
            {
                game.SpriteBatch.Draw(playerSprite.Texture, new Vector2(playerPosition.X, playerPosition.Y), Color.White);
            }

            game.SpriteBatch.End();

            // Note: Removed base.Draw(gameTime);
        }

        private bool CheckCollisionWithTrees(Entity playerEntity)
        {
            var playerPosition = playerEntity.GetComponent<PositionComponent>();
            var playerSprite = playerEntity.GetComponent<SpriteComponent>();

            foreach (var tree in _trees)
            {
                var treePosition = tree.GetComponent<PositionComponent>();
                var treeSprite = tree.GetComponent<SpriteComponent>();

                if (playerPosition != null && playerSprite != null &&
                    treePosition != null && treeSprite != null)
                {
                    // Simple AABB collision detection
                    var playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Texture.Width, playerSprite.Texture.Height);
                    var treeRect = new Rectangle((int)treePosition.X, (int)treePosition.Y, treeSprite.Texture.Width, treeSprite.Texture.Height);

                    if (playerRect.Intersects(treeRect))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private Entity CreatePlayerEntity(MainGame game)
        {
            var playerEntity = new Entity();
            playerEntity.AddComponent(new PositionComponent { X = 100, Y = 100 });
            playerEntity.AddComponent(new VelocityComponent { VelocityX = 0, VelocityY = 0 });
            playerEntity.AddComponent(new SpriteComponent { Texture = game.Content.Load<Texture2D>("batman") });
            playerEntity.AddComponent(new PowerComponent(100));
            playerEntity.AddComponent(new PlayerComponent());
            game.EntityManager.CreateEntity(playerEntity);
            return playerEntity;
        }

        private List<Entity> CreateTrees(MainGame game)
        {
            var trees = new List<Entity>();

            // Create and add tree entities
            for (int i = 0; i < 5; i++)
            {
                var treeEntity = new Entity();
                treeEntity.AddComponent(new PositionComponent { X = 300 + i * 200, Y = 300 });
                treeEntity.AddComponent(new SpriteComponent { Texture = game.Content.Load<Texture2D>("treetexture") });
                trees.Add(treeEntity);
                game.EntityManager.CreateEntity(treeEntity);
            }

            return trees;
        }
    }
}