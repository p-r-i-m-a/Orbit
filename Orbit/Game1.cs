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
        Texture2D starB, starY, starR, blackHole, bckgrnd;
        Rectangle window;

        star star1, star2, star3, star4;


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
            screen = Screen.intro;

            bckgrnd = Content.Load<Texture2D>("background");

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();



            base.Initialize();


            star1 = new star(starB, new Rectangle(0, 0, 29, 29), 80, -4, new Vector2(371, 221));
            star2 = new star(starR, new Rectangle(0, 0, 29, 29), 80, 3, new Vector2(371, 221));

            star3 = new star(starY, new Rectangle(0, 0, 29, 29), 120, 2, new Vector2(400, 250));
            star4 = new star(blackHole, new Rectangle(0, 0, 28, 21), 160, 1, new Vector2(400, 250));



            



        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fontText = Content.Load<SpriteFont>("font");

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



            Random generator = new Random();






            









            if (screen == Screen.intro)
            {
                //star1.SetCenterPosition(new Vector2(mouseState.X, mouseState.Y));
                star2.SetCenterPosition(new Vector2(star1.Bounds.X, star1.Bounds.Y));
;
                star1.Update(gameTime);

                star2.Update(gameTime);


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

            }
            


            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}