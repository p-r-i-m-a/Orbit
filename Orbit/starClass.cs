using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbit
{
    internal class star
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        public float _orbitRadius;
        public float _orbitSpeed;
        private float _angle;
        private Vector2 _centerPosition;


        public star(Texture2D texture, Rectangle rect, float orbitRadius, float orbitSpeed, Vector2 centerPosition)
        {
            _texture = texture;
            _rectangle = rect;
            _orbitRadius = orbitRadius;
            _orbitSpeed = orbitSpeed;
            _centerPosition = centerPosition;
            _angle = 0;
        }

        public void SetCenterPosition(Vector2 newCenterPosition)
        {
            _centerPosition = newCenterPosition;
        }

        public void SetOrbitSpeed(float newOrbitSpeed)
        {
            _orbitSpeed = newOrbitSpeed;
        }

        public Texture2D Texture => _texture;

        public Rectangle Bounds
        {
            get => _rectangle;
            set => _rectangle = value;
        }

        public int Right => _rectangle.Right;

        public bool Intersects(Rectangle rect) => _rectangle.Intersects(rect);

        public void Update(GameTime gameTime)
        {
            _angle += _orbitSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update position based on orbiting motion
            _rectangle.X = (int)(_centerPosition.X + Math.Cos(_angle) * _orbitRadius);
            _rectangle.Y = (int)(_centerPosition.Y + Math.Sin(_angle) * _orbitRadius);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
