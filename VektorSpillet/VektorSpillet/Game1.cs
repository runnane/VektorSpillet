using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VektorSpillet
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private Texture2D _pixel;
        private SpriteFont _font;

        private const int Screenwidth = 1280;
        private const int Screenheight = 720;

        private PlayerObject _p1;
        private PlayerObject _p2;
        private bool btndwn = false;
        private bool btndwn2 = false;
        private int Turn = 1;

        private int won = 0;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = Screenwidth;
            _graphics.PreferredBackBufferHeight = Screenheight;
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _p1 = new PlayerObject(Content, Color.Red, new Vector2(30, 45));
            _p2 = new PlayerObject(Content, Color.Green, new Vector2(45, 45));

            _pixel = Content.Load<Texture2D>("pixel"); // change these names to the names of your images
            _font = Content.Load<SpriteFont>("StandardText"); // Use the name of your font here instead of 'Score'.
            LineBatch.Init(GraphicsDevice);
            Map.Init();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (won > 0)
                return;
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (!btndwn2)
                {
                    btndwn2 = true;
                    if (Turn == 1)
                    {
                        _p1.ChangeChooser(Keyboard.GetState().IsKeyDown(Keys.A));
                    }
                    if (Turn == 2)
                    {
                        _p2.ChangeChooser(Keyboard.GetState().IsKeyDown(Keys.A));
                    }
                }
            }
            else
            {
                btndwn2 = false;
            }



            if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (!btndwn)
                {
                    btndwn = true;
                    if (Turn == 1)
                    {
                        _p1.Choose();
                        Turn = 2;
                    }
                    else if (Turn == 2)
                    {
                        _p2.Choose();
                        Turn = 1;
                    }
                }
            }
            else
            {
                btndwn = false;
            }

            for (int i = 0; i < Map.vl.Count - 1; i++)
            {
                if (VectorHelper.Intersects(Map.vl[i], Map.vl[i + 1], _p1.location, _p1.Destination))
                    won = 2;
                else if (VectorHelper.Intersects(Map.vl[i], Map.vl[i + 1], _p2.location, _p2.Destination))
                    won = 1;
            }
            for (int i = 0; i < Map.vl2.Count - 1; i++)
            {
                if (VectorHelper.Intersects(Map.vl2[i], Map.vl2[i + 1], _p1.location, _p1.Destination))
                    won = 2;
                else if (VectorHelper.Intersects(Map.vl2[i], Map.vl2[i + 1], _p2.location, _p2.Destination))
                    won = 1;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            for (int x = 15; x < Screenwidth; x += 15)
                for (int y = 15; y < Screenheight; y += 15)
                    _spriteBatch.Draw(_pixel, new Vector2(x, y), Color.White);

            Map.DrawMap(_spriteBatch);


            _spriteBatch.DrawString(_font, "p1: " + _p1 + "| p2: " + _p1, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(_font, "Player: " + Turn, new Vector2(0, 700), Color.White);

            if(won > 0)
            {
                _spriteBatch.DrawString(_font, "Player " + won + " won", new Vector2(Screenwidth/2, Screenheight/2), Color.White);
            }
            _p1.Draw(_spriteBatch, Turn==1);
            _p2.Draw(_spriteBatch, Turn==2);
            _spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
