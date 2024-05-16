using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;

namespace Orbit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MouseState mouseState, prevMouseState;
        Song music;
        SpriteFont menuFont, returnFont, exitFont, modFont;
        Texture2D starB, starY, starR, blackHole, bckgrnd, button;
        Rectangle window;

        star star1, star2, star3, star4;
        Button buttonMenu, buttonExit, buttonStarMod, buttonReturn, star1SpeedUp, star1SpeedDown, star1DistanceUp, star1DistanceDown, star2SpeedUp, star2SpeedDown, star2DistanceUp, star2DistanceDown, star3SpeedUp, star3SpeedDown, star3DistanceUp, star3DistanceDown, star4SpeedUp, star4SpeedDown, star4DistanceUp, star4DistanceDown;

        


        enum Screen
        {
            intro,
            menu,
            modify
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

            star1SpeedUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star1SpeedDown = new Button(button, new Rectangle(1, 1, 50, 25));
            star1DistanceUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star1DistanceDown = new Button(button, new Rectangle(1, 1, 50, 25));

            star2SpeedUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star2SpeedDown = new Button(button, new Rectangle(1, 1, 50, 25));
            star2DistanceUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star2DistanceDown = new Button(button, new Rectangle(1, 1, 50, 25));

            star3SpeedUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star3SpeedDown = new Button(button, new Rectangle(1, 1, 50, 25));
            star3DistanceUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star3DistanceDown = new Button(button, new Rectangle(1, 1, 50, 25));

            star4SpeedUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star4SpeedDown = new Button(button, new Rectangle(1, 1, 50, 25));
            star4DistanceUp = new Button(button, new Rectangle(1, 1, 50, 25));
            star4DistanceDown = new Button(button, new Rectangle(1, 1, 50, 25));

            buttonMenu = new Button(button, new Rectangle(1, 1, 50, 25));

            buttonExit = new Button(button, new Rectangle(350, 300, 50, 25));

            buttonStarMod = new Button(button, new Rectangle(350, 200, 50, 25));

            buttonReturn = new Button(button, new Rectangle(350, 100, 50, 25));

            star1 = new star(starB, new Rectangle(0, 0, 29, 29), 40, 0.4f, new Vector2(371, 221));
            star2 = new star(starR, new Rectangle(0, 0, 29, 29), 80, 0.3f, new Vector2(371, 221));

            star3 = new star(starY, new Rectangle(0, 0, 29, 29), 120, 0.2f, new Vector2(371, 221));
            star4 = new star(blackHole, new Rectangle(0, 0, 28, 21), 160, 0.1f, new Vector2(371, 221));



            



        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            menuFont = Content.Load<SpriteFont>("font");
            exitFont = Content.Load<SpriteFont>("font");
            modFont = Content.Load<SpriteFont>("font");
            returnFont = Content.Load<SpriteFont>("font");




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

            if (buttonMenu.IsClicked(mouseState, prevMouseState))
            {
                screen = Screen.menu; 
            }

            buttonMenu.Update(mouseState, prevMouseState);
            buttonExit.Update(mouseState, prevMouseState);
            buttonStarMod.Update(mouseState, prevMouseState);
            buttonReturn.Update(mouseState, prevMouseState);




















            if (screen == Screen.intro)
            {
                //star1.SetCenterPosition(new Vector2(star2.Bounds.X, star2.Bounds.Y));
;
                star1.Update(gameTime);

                star2.Update(gameTime);
                
                star3.Update(gameTime);

                star4.Update(gameTime);

            }
            else if (screen == Screen.menu)
            {
                if (buttonExit.IsClicked(mouseState, prevMouseState))
                {
                    Exit();
                }
                else if (buttonReturn.IsClicked(mouseState, prevMouseState))
                {
                    screen = Screen.intro;
                }
                else if (buttonStarMod.IsClicked(mouseState, prevMouseState))
                {
                    screen = Screen.modify;
                }
            }
            else if (screen == Screen.modify)
            {

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
                buttonMenu.Draw(_spriteBatch);
                _spriteBatch.DrawString(menuFont, "Menu", new Vector2(buttonMenu.Bounds.X, buttonMenu.Bounds.Y), Color.Black);
            }
            else if (screen == Screen.menu)
            {
                _spriteBatch.Draw(bckgrnd, new Rectangle(0, 0, 800, 500), Color.White);
                buttonStarMod.Draw(_spriteBatch);
                buttonReturn.Draw(_spriteBatch);
                buttonExit.Draw(_spriteBatch);
                _spriteBatch.DrawString(returnFont, "Return", new Vector2(buttonReturn.Bounds.X, buttonReturn.Bounds.Y), Color.Black);
                _spriteBatch.DrawString(exitFont, "Exit", new Vector2(buttonExit.Bounds.X, buttonExit.Bounds.Y), Color.Black);
                _spriteBatch.DrawString(modFont, "Modify", new Vector2(buttonStarMod.Bounds.X, buttonStarMod.Bounds.Y), Color.Black);

            }
            else if (screen == Screen.modify)
            {
                _spriteBatch.Draw(bckgrnd, new Rectangle(0, 0, 800, 500), Color.White);

            }





            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}