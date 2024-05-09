using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbit.Content
{
    internal class star
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;

        public star (Texture2D texture, Rectangle rect, Vector2 speed, Rectangle window) 
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public int Right
        {
            get { return _rectangle.Right; }
        }

        public bool Intersects(Rectangle rect)
        {
            return _rectangle.Intersects(rect);
        }

        public void Move()
        {
            _rectangle.Offset(_speed);
 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);


        }
    }
}
