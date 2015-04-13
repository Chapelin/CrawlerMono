#region Using Statements
using System;
using System.Linq;
using Crawler.Living;
using Crawler.MapGenerator;
using Crawler.Scheduling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        private BasicLogPrinter blp;
        private Dongeon donjon;

        public GameEngine()
            : base()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 15 * SpriteSize;
            graphics.PreferredBackBufferWidth = 25 * SpriteSize;

            beingToPlay = null;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            sb = new SpriteBatch(GraphicsDevice);
            blp = new BasicLogPrinter(this, sb);
            c = new Camera(new Vector2(15, 13), new Vector2(0, 50), blp);
            scheduler = new Scheduler();
            blp.PositionPixel = new Vector2(517, 420);
            Components.Add(blp);
            donjon = new Dongeon(this, c, sb, blp);
            m = donjon.CurrentMap;
            scheduler.AddABeing(m.InitializePlayer(c));
            m.InitializeItems(c);
            scheduler.AddABeing(m.InitializeEnnemis(c));
            base.Initialize();
            hd = new KeyBoardInputHandler(c, m);
            m.SetAsActive(true);
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
                beingToPlay = scheduler.CurrentPlaying();
                if (!beingToPlay.IsUserControlled)
                {
                    beingToPlay.AutoPlay();
                    scheduler.Played();
                    beingToPlay = null;
                }
            }

            m.HandleVisibility(beingToPlay);
            hd.HandleInput(beingToPlay);

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            sb.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            base.Draw(gameTime);
            sb.End();
        }

        public void MoveBeing(LivingBeing p, Vector2 targetPosition)
        {
            c.Move(targetPosition - p.positionCell);
            p.positionCell = targetPosition;
            // we have played, so we remove it
            scheduler.Played();
            beingToPlay = null;
        }

        public void ChangeMap(LivingBeing lb, bool goingDown)
        {
            var nextLVL = donjon.CurrentLevel + (goingDown ? 1 : -1);
            m.RemoveLivingBeing(lb);
            if (!lb.IsUserControlled)
                throw new Exception("Error");
            m.SetAsActive(false);
            donjon.CurrentLevel = nextLVL;
            m = donjon.CurrentMap;
            var targetpos = m.board.GetElementWhere(x => x.IsWalkable(lb)).First().positionCell;
            m.AddLivingBeing(lb, targetpos);
            m.SetAsActive(true);
            this.hd = new KeyBoardInputHandler(this.c, m);
        }
    }
}
