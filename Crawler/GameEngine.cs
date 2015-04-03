#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Crawler.Cells;
using Crawler.Living;
using Crawler.Scheduling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Crawler
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        public const int SpriteSize = 32;

        public GraphicsDeviceManager graphics;

        private SpriteBatch sb;
        private KeyBoardInputHandler hd;

        private Map m;
        private Camera c;
        private Scheduler scheduler;
        private LivingBeing beingToPlay;


        public GameEngine()
            : base()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.graphics.PreferredBackBufferHeight = 15 * SpriteSize;
            this.graphics.PreferredBackBufferWidth = 25 * SpriteSize;
            this.c = new Camera(new Vector2(18, 13), new Vector2(0, 50));
            this.beingToPlay = null;
            this.scheduler = new Scheduler();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.sb = new SpriteBatch(this.GraphicsDevice);
            this.m = new Map(this, sb);
            this.Components.Add(m);
            m.InitializeBoard(c);
            this.scheduler.AddABeing(m.InitializePlayer(this.c));
            m.InitializeItems(this.c);
            this.scheduler.AddABeing(m.InitializeEnnemis(this.c));
            base.Initialize();
            this.hd = new KeyBoardInputHandler(this.c, this.m);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // if list empty
            while (beingToPlay == null)
            {
                beingToPlay = this.scheduler.CurrentPlaying();
                if (!beingToPlay.IsUserControlled)
                {
                    beingToPlay.AutoPlay();
                    this.scheduler.Played();
                    beingToPlay = null;
                }
            }





            this.m.HandleVisibility(beingToPlay);
            this.hd.HandleInput(beingToPlay);

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            this.sb.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            base.Draw(gameTime);
            this.sb.End();
        }

        public void MoveBeing(LivingBeing p, Vector2 targetPosition)
        {

            var currentCell = this.m.board.First(x => x.positionCell == p.positionCell);
            currentCell.OnExit(p);
            this.c.Move(targetPosition - p.positionCell);
            p.positionCell = targetPosition;
            var targetCell = this.m.board.First(x => x.positionCell == targetPosition);
            targetCell.OnEnter(p);
            // we have played, so we remove it
            this.scheduler.Played();
            this.beingToPlay = null;

        }
    }
}
