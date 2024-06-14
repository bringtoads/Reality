using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Reality
{
    internal class Player : Sprite
    {
        List<Sprite> _collisionGroup; 
        public Player(Texture2D texture, Vector2 position,List<Sprite> collisionGroup) : base(texture, position)
        {
            _collisionGroup = collisionGroup;
        }
        public override void Update(GameTime gameTime )
        {
            base.Update(gameTime);
            //float changeX = 0;
            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    changeX += 5;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    changeX -= 5;
            //}
            //_position.X += changeX;

            //float changeY = 0;
            ////changeY += 5;
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    changeY -= 5;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    changeY += 5;
            //}
            //_position.Y += changeY;
            //if (_collisionGroup != null)
            //{
            //    foreach (var sprite in _collisionGroup)
            //    {
            //        if (sprite != this && sprite.Rect.Intersects(Rect))
            //        {
            //            _position.X -= changeX;
            //        }
            //    }


            //    foreach (var sprite in _collisionGroup)
            //    {
            //        if (sprite != this && sprite.Rect.Intersects(Rect))
            //        {
            //            _position.Y -= changeY;
            //        }
            //    }
            //}
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Debug.WriteLine("Right");
                _position.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Debug.WriteLine("Left");
                _position.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Debug.WriteLine("Up");
                _position.Y -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Debug.WriteLine("Down");
                _position.Y += 5;
            }
            Debug.WriteLine($"x:{this._position.X}, y:{this._position.Y}");
        }
    }
}
