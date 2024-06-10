using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.WIC;
using System.Collections.Generic;
using System.Diagnostics;
using SamplerState = Microsoft.Xna.Framework.Graphics.SamplerState;

namespace Reality
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //List<MovingSprite> sprites;
        MovingSprite sprite;
        Texture2D texture;
        List<Sprite> sprites;

        Player player;

        bool space_pressed = false;
        bool left_mouse_pressed = false;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            //texture = Content.Load<Texture2D>("batman");
            //sprite = new MovingSprite(texture, Vector2.Zero, 1f);

            //var texture = Content.Load<Texture2D>("batman");
            //sprites = new List<MovingSprite>(); 
            //for (int i = 0; i < 10; i++)
            //{
            //    sprites.Add(new MovingSprite(texture, new Vector2(0,10*i), i));
            //}

            var batman = Content.Load<Texture2D>("batman");
            var joker = Content.Load<Texture2D>("joker");
            var jokerSprite = new Sprite(joker, new Vector2(100, 100));
           
            sprites = new();
            sprites.Add(new Sprite(joker, new Vector2(100, 100)));
            sprites.Add(new Sprite(joker, new Vector2(400, 300)));
            sprites.Add(new Sprite(joker, new Vector2(500, 200)));
            player = new Player(batman, new Vector2(200, 200), sprites);

            sprites.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //if (!space_pressed && Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    space_pressed = true;
            //    Debug.WriteLine("Space key pressed!");
            //}

            //if (Keyboard.GetState().IsKeyUp(Keys.Space))
            //{
            //    space_pressed = false;
            //}


            //if (!left_mouse_pressed && Mouse.GetState().LeftButton == ButtonState.Pressed)
            //{
            //    left_mouse_pressed = true;
            //    Debug.WriteLine("Left pressed");
            //}
            //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            //{
            //    left_mouse_pressed = false;
            //}

            //var mouse = Mouse.GetState().Position;
            //Debug.WriteLine($"X:{mouse.X},Y:{mouse.Y}");
            //foreach (var sprite in sprites)
            //{
            //    sprite.Update();
            //}

            List<Sprite> killList = new();
            //foreach (var sprite in sprites)
            //{
            //    sprite.Update(gameTime);
            //    if (sprite != player && sprite.Rect.Intersects(player.Rect))
            //    {
            //        killList.Add(sprite);
            //    }
            //}
            //foreach (var sprite in killList)
            //{
            //    sprites.Remove(sprite);
            //}
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);
            }
            //player.Update(gameTime);
            base.Update(gameTime);
        }
      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //_spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            //_spriteBatch.Draw(texture, new Rectangle(0, 0, 200, 200), Color.White);
            //_spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //foreach (var sprite in sprites)
            //{ 
            //        _spriteBatch.Draw(sprite._texture, sprite.Rect, Color.White);
            //}
            //_spriteBatch.End();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }
            //player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
