using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orbit;
using System;

public class Button
{
    private Texture2D _texture;
    private Rectangle _rectangle;
    private Color _color;
    private bool _isClicked;

    public Button(Texture2D texture, Rectangle rectangle)
    {
        _texture = texture;
        _rectangle = rectangle;
        _color = Color.White;
        _isClicked = false;
    }


    public Rectangle Bounds { get { return _rectangle; } }

    public bool IsClicked(MouseState mouseState, MouseState prevMouseState)
    {
        return _rectangle.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released;
    }

    public void Update(MouseState mouseState, MouseState prevMouseState)
    {
        if (_rectangle.Contains(mouseState.Position))
        {
            _color = Color.Red;  
        }
        else
            _color = Color. White;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _rectangle, _color);
    }

   
}

