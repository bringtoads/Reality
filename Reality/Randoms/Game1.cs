using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        Texture2D[] smallMario;
        Texture2D[] bigMario;
        Texture2D spriteSheeet;
        Texture2D playerTexture;
        Vector2 ballPosition;
        float ballSpeed;
        Player player;

        //int counter;
        //int activeFrame;
        //int numFrames;

        AnimationManager animationManager;

        bool space_pressed = false;
        bool left_mouse_pressed = false;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            //smallMario = new Texture2D[2];
            //for (int i = 0; i < 2; i++)
            //{
            //    smallMario[i] = Content.Load<Texture2D>($"frame_{i+1}");
            //}

            //var playerTexture = Content.Load<Texture2D>("test");
            //var batman = Content.Load<Texture2D>("batman");
            //sprites = new();
            //sprites.Add(new Sprite(batman, new Vector2(100, 100)));
            //sprites.Add(new Sprite(batman, new Vector2(400, 300)));
            //sprites.Add(new Sprite(batman, new Vector2(500, 200)));
            //player = new Player(playerTexture, new Vector2(200, 200), sprites);


            //activeFrame = 0;
            //numFrames = 2;
            //counter = 0;

            //spriteSheeet = Content.Load<Texture2D>("swalking");
            //animationManager = new(4,2,new Vector2(79,80)); 

            //            playerTexture = Content.Load<Texture2D>("test");
            //            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            //_graphics.PreferredBackBufferHeight / 2);
            //            ballSpeed = 100f;

            //var batman = Content.Load<Texture2D>("batman");
            //player = new Player(batman, new Vector2(200, 200), null);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update(gameTime);
            base.Update(gameTime);
        }
      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //_spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            //_spriteBatch.Draw(texture, new Rectangle(0, 0, 200, 200), Color.White);
            //_spriteBatch.End();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var sprite in sprites)
            {
                _spriteBatch.Draw(sprite._texture, sprite.Rect, Color.White);
            }
            _spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //foreach (var sprite in sprites)
            //{
            //    sprite.Draw(_spriteBatch);
            //}
            ////player.Draw(_spriteBatch);
            //_spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //_spriteBatch.Draw(smallMario[activeFrame], new Rectangle(100, 100, 100, 200), Color.White);
            //_spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //player.Draw(_spriteBatch);
            //_spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            //_spriteBatch.Draw(
            //    spriteSheeet,
            //    new Rectangle(100,100,100,200),
            //    new Rectangle(activeFrame * 8,0,32,16),
            //    Color.White);
            //_spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            //_spriteBatch.Draw(
            //    spriteSheeet,
            //    new Rectangle(100, 100, 100, 200),
            //    animationManager.GetFrame(),
            //    Color.White);
            //_spriteBatch.End();

            //_spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            //player.Draw(_spriteBatch);
            //_spriteBatch.Draw(playerTexture, ballPosition, Color.White);
            //_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
