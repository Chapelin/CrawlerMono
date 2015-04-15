#region Using Statements



#endregion

namespace Crawler.Engine
{
    using System;
    using System.Linq;

    using Crawler.Helpers;
    using Crawler.Living;
    using Crawler.MapGenerator;
    using Crawler.Scheduling;
    using Crawler.UI;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

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

            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.graphics.PreferredBackBufferHeight = 15 * SpriteSize;
            this.graphics.PreferredBackBufferWidth = 25 * SpriteSize;

            this.beingToPlay = null;
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
            this.blp = new BasicLogPrinter(this, this.sb);
            this.c = new Camera(new Vector2(15, 13), new Vector2(0, 50), this.blp);
            this.scheduler = new Scheduler();
            this.blp.PositionPixel = new Vector2(517, 420);
            this.Components.Add(this.blp);
            this.donjon = new Dongeon(this, this.c, this.sb, this.blp);
            this.m = this.donjon.CurrentMap;

            this.scheduler.AddABeing(MapFiller.InitializePlayer(this.c, this.m, this.sb));
            MapFiller.InitializeItems(this.c, this.m, this.sb);
            this.scheduler.AddABeing(MapFiller.InitializeEnnemis(this.c, this.m, this.sb, this.blp));
            base.Initialize();
            this.hd = new KeyBoardInputHandler(this.c, this.m);
            this.m.SetAsActive(true);
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
                this.Exit();

            // if list empty
            while (this.beingToPlay == null)
            {
                this.beingToPlay = this.scheduler.CurrentPlaying();
                if (!this.beingToPlay.IsUserControlled)
                {
                    this.beingToPlay.AutoPlay();
                    this.scheduler.Played();
                    this.beingToPlay = null;
                }
            }

            this.m.HandleVisibility(this.beingToPlay);
            this.hd.HandleInput(this.beingToPlay);

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);
            this.sb.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            base.Draw(gameTime);
            this.sb.End();
        }

        public void MoveBeing(LivingBeing p, Vector2 targetPosition)
        {
            this.c.Move(targetPosition - p.positionCell);
            p.positionCell = targetPosition;
            // we have played, so we remove it
            this.scheduler.Played();
            this.beingToPlay = null;
        }

        public void ChangeMap(LivingBeing lb, bool goingDown)
        {
            var nextLVL = this.donjon.CurrentLevel + (goingDown ? 1 : -1);
            this.m.RemoveLivingBeing(lb);
            if (!lb.IsUserControlled)
                throw new Exception("Error");
            this.m.SetAsActive(false);
            this.donjon.CurrentLevel = nextLVL;
            this.m = this.donjon.CurrentMap;
            var targetpos = this.m.board.First(x => x.IsWalkable(lb)).positionCell;
            this.m.AddLivingBeing(lb, targetpos);
            this.m.SetAsActive(true);
            this.hd = new KeyBoardInputHandler(this.c, this.m);
        }
    }
}
