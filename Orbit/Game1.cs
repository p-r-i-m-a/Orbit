using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Orbit.Content;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Orbit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MouseState mouseState, prevMouseState;
        Song music;
        SpriteFont fontText;
        Texture2D starB, starY, starR, blackHole, bckgrnd, button;
        Rectangle window;

        star star1, star2, star3, star4;
        Button button1;

        


        enum Screen
        {
            intro,
            ingame
        }

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Random generator = new Random();

            screen = Screen.intro;

            bckgrnd = Content.Load<Texture2D>("background");

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();



            base.Initialize();


            button1 = new Button(button, new Rectangle(1, 1, 100, 50)) ;

            star1 = new star(starB, new Rectangle(0, 0, 29, 29), 80, -0.3f, new Vector2(371, 221));
            star2 = new star(starR, new Rectangle(0, 0, 29, 29), 80, 0.3f, new Vector2(371, 221));

            star3 = new star(starY, new Rectangle(0, 0, 29, 29), 120, -0.2f, new Vector2(400, 250));
            star4 = new star(blackHole, new Rectangle(0, 0, 28, 21), 120, 0.1f, new Vector2(400, 250));



            



        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fontText = Content.Load<SpriteFont>("font");
            button = Content.Load<Texture2D>("button");
            starB = Content.Load<Texture2D>("starB");
            starY = Content.Load<Texture2D>("starY");
            starR = Content.Load<Texture2D>("starR");
            blackHole = Content.Load<Texture2D>("blackHole");


            music = Content.Load<Song>("ascent");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (button1.IsClicked(mouseState, prevMouseState))
            {
                Exit();
            }

            button1.Update(mouseState, prevMouseState);







            









            if (screen == Screen.intro)
            {
                //star1.SetCenterPosition(new Vector2(star2.Bounds.X, star2.Bounds.Y));
                star2.SetCenterPosition(new Vector2(star1.Bounds.X, star1.Bounds.Y));
                star3.SetCenterPosition(new Vector2(star2.Bounds.X, star1.Bounds.Y));
                star4.SetCenterPosition(new Vector2(star3.Bounds.X, star3.Bounds.Y));
;
                star1.Update(gameTime);

                star2.Update(gameTime);
                
                star3.Update(gameTime);
                star4.Update(gameTime);

            }


            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {

            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(bckgrnd, new Rectangle(0, 0, 800, 500), Color.White);

            if(screen == Screen.intro)
            {
                star1.Draw(_spriteBatch);
                star2.Draw(_spriteBatch);
                star3.Draw(_spriteBatch);
                star4.Draw(_spriteBatch);
                button1.Draw(_spriteBatch);
            }
            


            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}