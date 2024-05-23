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
        SpriteFont menuFont, returnFont, exitFont, modFont, distanceFont, speedFont, distanceFontd, speedFontd;
        Texture2D starB, starY, starR, blackHole, bckgrnd, button, menuStar1, menuStar2, menuStar3, menuStar4;
        Rectangle window;

        Rectangle blackHoleSource;
        int blackHoleFrame;
        float seconds;
        

        star star1, star2, star3, star4;
        Button buttonMenu, buttonExit, buttonStarMod, buttonReturn, star1SpeedUp, star1SpeedDown, star1DistanceUp, star1DistanceDown, star2SpeedUp, star2SpeedDown, star2DistanceUp, star2DistanceDown, star3SpeedUp, star3SpeedDown, star3DistanceUp, star3DistanceDown, star4SpeedUp, star4SpeedDown, star4DistanceUp, star4DistanceDown;

        Rectangle star1Tangle = new Rectangle(250, 79, 29, 29);
        Rectangle star2Tangle = new Rectangle(408, 79, 29, 29);
        Rectangle star3Tangle = new Rectangle(329, 79, 29, 29);
        Rectangle star4Tangle = new Rectangle(470, 58, 58, 58);


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

            blackHoleFrame = 0;
            seconds = 0;


            window = new Rectangle(0, 0, 1000, 700);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            blackHoleSource = new Rectangle(0, 0, 135, 120);



            base.Initialize();

            star1SpeedUp = new Button(button, new Rectangle(250, 125, 50, 25));
            star1SpeedDown = new Button(button, new Rectangle(250, 200, 50, 25));
            star1DistanceUp = new Button(button, new Rectangle(250, 275, 50, 25));
            star1DistanceDown = new Button(button, new Rectangle(250, 350, 50, 25));

            star2SpeedUp = new Button(button, new Rectangle(325, 125, 50, 25));
            star2SpeedDown = new Button(button, new Rectangle(325, 200, 50, 25));
            star2DistanceUp = new Button(button, new Rectangle(325, 275, 50, 25));
            star2DistanceDown = new Button(button, new Rectangle(325, 350, 50, 25));

            star3SpeedUp = new Button(button, new Rectangle(400, 125, 50, 25));
            star3SpeedDown = new Button(button, new Rectangle(400, 200, 50, 25));
            star3DistanceUp = new Button(button, new Rectangle(400, 275, 50, 25));
            star3DistanceDown = new Button(button, new Rectangle(400, 350, 50, 25));

            star4SpeedUp = new Button(button, new Rectangle(475, 125, 50, 25));
            star4SpeedDown = new Button(button, new Rectangle(475, 200, 50, 25));
            star4DistanceUp = new Button(button, new Rectangle(475, 275, 50, 25));
            star4DistanceDown = new Button(button, new Rectangle(475, 350, 50, 25));

            buttonMenu = new Button(button, new Rectangle(1, 1, 50, 25));

            buttonExit = new Button(button, new Rectangle(350, 300, 50, 25));

            buttonStarMod = new Button(button, new Rectangle(350, 200, 50, 25));

            buttonReturn = new Button(button, new Rectangle(350, 100, 50, 25));

            star1 = new star(starB, new Rectangle(0, 0, 29, 29), 40, 0.4f, new Vector2(371, 221));
            star2 = new star(starR, new Rectangle(0, 0, 29, 29), 80, 0.3f, new Vector2(371, 221));

            star3 = new star(starY, new Rectangle(0, 0, 29, 29), 120, 0.2f, new Vector2(371, 221));
            star4 = new star(blackHole, new Rectangle(0, 0, 120, 120), 160, 0.1f, new Vector2(371, 221));



            



        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            menuFont = Content.Load<SpriteFont>("font");
            exitFont = Content.Load<SpriteFont>("font");
            modFont = Content.Load<SpriteFont>("font");
            returnFont = Content.Load<SpriteFont>("font");
            distanceFont = Content.Load<SpriteFont>("font");
            distanceFontd = Content.Load<SpriteFont>("font");
            speedFont = Content.Load<SpriteFont>("font");
            speedFontd = Content.Load<SpriteFont>("font");


            menuStar1 = Content.Load<Texture2D>("starB");
            menuStar2 = Content.Load<Texture2D>("starY");
            menuStar3 = Content.Load<Texture2D>("starR");
            menuStar4 = Content.Load<Texture2D>("blackHole");



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



            buttonExit.Update(mouseState, prevMouseState);
            buttonStarMod.Update(mouseState, prevMouseState);
            buttonReturn.Update(mouseState, prevMouseState);















            if (screen == Screen.intro)
            {

                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (seconds > 0.1)
                {
                    seconds = 0;
                    blackHoleFrame += 1;
                    if(blackHoleFrame > 5)
                        blackHoleFrame = 0;
                    blackHoleSource.X = blackHoleFrame * 135;
                }

                //star1.SetCenterPosition(new Vector2(star2.Bounds.X, star2.Bounds.Y));

                buttonMenu.Update(mouseState, prevMouseState);

                if (buttonMenu.IsClicked(mouseState, prevMouseState))
                {
                    screen = Screen.menu;
                }

;
                star1.Update(gameTime);

                star2.Update(gameTime);
                
                star3.Update(gameTime);

                star4.Update(gameTime);

            }
            else if (screen == Screen.menu)
            {


                buttonReturn = new Button(button, new Rectangle(350, 100, 50, 25));


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
                if (seconds > 0.1)
                {
                    seconds = 0;
                    blackHoleFrame += 1;
                    if (blackHoleFrame > 5)
                        blackHoleFrame = 0;
                    blackHoleSource.X = blackHoleFrame * 135;
                }

                star1SpeedUp.Update(mouseState, prevMouseState);
                star1SpeedDown.Update(mouseState, prevMouseState);
                star1DistanceUp.Update(mouseState, prevMouseState);
                star1DistanceDown.Update(mouseState, prevMouseState);

                star2SpeedUp.Update(mouseState, prevMouseState);
                star2SpeedDown.Update(mouseState, prevMouseState);
                star2DistanceUp.Update(mouseState, prevMouseState);
                star2DistanceDown.Update(mouseState, prevMouseState);

                star3SpeedUp.Update(mouseState, prevMouseState);
                star3SpeedDown.Update(mouseState, prevMouseState);
                star3DistanceUp.Update(mouseState, prevMouseState);
                star3DistanceDown.Update(mouseState, prevMouseState);

                star4SpeedUp.Update(mouseState, prevMouseState);
                star4SpeedDown.Update(mouseState, prevMouseState);
                star4DistanceUp.Update(mouseState, prevMouseState);
                star4DistanceDown.Update(mouseState, prevMouseState);


                buttonReturn = new Button(button, new Rectangle(1, 1, 50, 25));

                if (buttonReturn.IsClicked(mouseState, prevMouseState))
                {
                    screen = Screen.intro;
                }

                //Speed:


                if (star1SpeedUp.IsClicked(mouseState, prevMouseState))
                {
                    star1._orbitSpeed = (star1._orbitSpeed + 0.1f);
                }
                else if (star1SpeedDown.IsClicked(mouseState, prevMouseState))
                {
                    star1._orbitSpeed = (star1._orbitSpeed - 0.1f);
                }

                if (star2SpeedUp.IsClicked(mouseState, prevMouseState))
                {
                    star2._orbitSpeed = (star2._orbitSpeed + 0.1f);
                }
                else if (star2SpeedDown.IsClicked(mouseState, prevMouseState))
                {
                    star2._orbitSpeed = (star2._orbitSpeed - 0.1f);
                }

                if (star3SpeedUp.IsClicked(mouseState, prevMouseState))
                {
                    star3._orbitSpeed = (star3._orbitSpeed + 0.1f);
                }
                else if (star3SpeedDown.IsClicked(mouseState, prevMouseState))
                {
                    star3._orbitSpeed = (star3._orbitSpeed - 0.1f);
                }

                if (star4SpeedUp.IsClicked(mouseState, prevMouseState))
                {
                    star4._orbitSpeed = (star4._orbitSpeed + 0.1f);
                }
                else if (star4SpeedDown.IsClicked(mouseState, prevMouseState))
                {
                    star4._orbitSpeed = (star4._orbitSpeed - 0.1f);
                }

                //Distance:


                if (star1DistanceUp.IsClicked(mouseState, prevMouseState))
                {
                    star1._orbitRadius = (star1._orbitRadius + 20);
                }
                else if (star1DistanceDown.IsClicked(mouseState, prevMouseState))
                {
                    star1._orbitRadius = (star1._orbitRadius - 20);
                }

                if (star2DistanceUp.IsClicked(mouseState, prevMouseState))
                {
                    star2._orbitRadius = (star2._orbitRadius + 20);
                }
                else if (star2DistanceDown.IsClicked(mouseState, prevMouseState))
                {
                    star2._orbitRadius = (star2._orbitRadius - 20);
                }

                if (star3DistanceUp.IsClicked(mouseState, prevMouseState))
                {
                    star3._orbitRadius = (star3._orbitRadius + 20);
                }
                else if (star3DistanceDown.IsClicked(mouseState, prevMouseState))
                {
                    star3._orbitRadius = (star3._orbitRadius - 20);
                }

                if (star4DistanceUp.IsClicked(mouseState, prevMouseState))
                {
                    star4._orbitRadius = (star4._orbitRadius + 20);
                }
                else if (star1DistanceDown.IsClicked(mouseState, prevMouseState))
                {
                    star4._orbitRadius = (star4._orbitRadius - 20);
                }


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

            _spriteBatch.Draw(bckgrnd, new Rectangle(0, 0, 1000, 700), Color.White);

            if(screen == Screen.intro)
            {
                star1.Draw(_spriteBatch);
                star2.Draw(_spriteBatch);
                star3.Draw(_spriteBatch);
                //star4.Draw(_spriteBatch);
                _spriteBatch.Draw(star4.Texture, star4.Bounds, blackHoleSource, Color.White);
                
                buttonMenu.Draw(_spriteBatch);
                _spriteBatch.DrawString(menuFont, "Menu", new Vector2(buttonMenu.Bounds.X, buttonMenu.Bounds.Y), Color.Black);
            }
            else if (screen == Screen.menu)
            {
                _spriteBatch.Draw(bckgrnd, new Rectangle(0, 0, 1000, 700), Color.White);
                buttonReturn.Draw(_spriteBatch);
                buttonStarMod.Draw(_spriteBatch);
                buttonReturn.Draw(_spriteBatch);
                buttonExit.Draw(_spriteBatch);
                _spriteBatch.DrawString(returnFont, "Return", new Vector2(buttonReturn.Bounds.X, buttonReturn.Bounds.Y), Color.Black);
                _spriteBatch.DrawString(exitFont, "Exit", new Vector2(buttonExit.Bounds.X, buttonExit.Bounds.Y), Color.Black);
                _spriteBatch.DrawString(modFont, "Modify", new Vector2(buttonStarMod.Bounds.X, buttonStarMod.Bounds.Y), Color.Black);

            }
            else if (screen == Screen.modify)
            {




                _spriteBatch.Draw(bckgrnd, new Rectangle(0, 0, 1000, 700), Color.White);

                buttonReturn.Draw(_spriteBatch);
                _spriteBatch.DrawString(returnFont, "Return", new Vector2(buttonReturn.Bounds.X, buttonReturn.Bounds.Y), Color.Black);


                star1DistanceUp.Draw(_spriteBatch);
                star1DistanceDown.Draw(_spriteBatch);
                star1SpeedUp.Draw(_spriteBatch);
                star1SpeedDown.Draw(_spriteBatch);

                star2DistanceUp.Draw(_spriteBatch);
                star2DistanceDown.Draw(_spriteBatch);
                star2SpeedUp.Draw(_spriteBatch);
                star2SpeedDown.Draw(_spriteBatch);

                star3DistanceUp.Draw(_spriteBatch);
                star3DistanceDown.Draw(_spriteBatch);
                star3SpeedUp.Draw(_spriteBatch);
                star3SpeedDown.Draw(_spriteBatch);

                

                star4DistanceUp.Draw(_spriteBatch);
                star4DistanceDown.Draw(_spriteBatch);
                star4SpeedUp.Draw(_spriteBatch);
                star4SpeedDown.Draw(_spriteBatch);

                _spriteBatch.DrawString(distanceFont, "Distance Up:", new Vector2(star1DistanceUp.Bounds.X - 150, star1DistanceUp.Bounds.Y), Color.White);
                _spriteBatch.DrawString(distanceFontd, "Distance Down:", new Vector2(star1DistanceDown.Bounds.X - 150, star1DistanceDown.Bounds.Y), Color.White);
                _spriteBatch.DrawString(speedFont, "Speed Up:", new Vector2(star1SpeedUp.Bounds.X - 150, star1SpeedUp.Bounds.Y), Color.White);
                _spriteBatch.DrawString(speedFontd, "Speed Down:", new Vector2(star1SpeedDown.Bounds.X - 150, star1SpeedDown.Bounds.Y), Color.White);

                _spriteBatch.Draw(menuStar1, star1Tangle, Color.White);
                _spriteBatch.Draw(menuStar2, star2Tangle, Color.White);
                _spriteBatch.Draw(menuStar3, star3Tangle, Color.White);
               // _spriteBatch.Draw(menuStar4, star4Tangle, Color.White);
                _spriteBatch.Draw(star4.Texture, star4Tangle, blackHoleSource, Color.White);

            }





            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}