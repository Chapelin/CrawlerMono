namespace Crawler.Engine
{
    using System;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.Helpers;
    using Crawler.Input;
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

        private KeyBoardInputHandler hd;

        private Map m;
        private Scheduler scheduler;
        private LivingBeing beingToPlay;
        private BasicLogPrinter blp;
        private Dongeon donjon;

        private MouseTargeter mt;

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
            BlackBoard.CurrentSpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.blp = new BasicLogPrinter(this);
            BlackBoard.CurrentCamera = new Camera(new Vector2(15, 11), new Vector2(0, 50));
            this.scheduler = new Scheduler();
            this.blp.PositionPixel = new Vector2(517, 420);
            this.Components.Add(this.blp);
            this.donjon = new Dongeon(this, this.blp);
            this.m = this.donjon.CurrentMap;

            this.scheduler.AddABeing(MapFiller.InitializePlayer(this.m, this.blp));
            MapFiller.InitializeItems(this.m, this.blp);
            this.scheduler.AddABeing(MapFiller.InitializeEnnemis(this.m, this.blp));
            base.Initialize();
            this.hd = new KeyBoardInputHandler();
            this.m.SetAsActive(true);
            BlackBoard.CurrentMap = this.m;
            this.mt = new MouseTargeter(this);
            this.Components.Add(this.mt);
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
            BlackBoard.CurrentSpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            base.Draw(gameTime);
            BlackBoard.CurrentSpriteBatch.End();
        }

        public void MoveBeing(LivingBeing p, Vector2 targetPosition)
        {
            BlackBoard.CurrentCamera.Move(targetPosition - p.positionCell);
            Cell cellTarget = this.m.fullBoard.Where<Cell>(x => x.positionCell == targetPosition).First();
            Cell cellGoingout = this.m.fullBoard.Where<Cell>(x => x.positionCell == p.positionCell).First();
            cellGoingout.OnExit(p);
            p.positionCell = targetPosition;
            cellTarget.OnEnter(p);

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
            var targetpos = this.m.fullBoard.Where(x => x is Cell).First(x => ((Cell)x).IsWalkable(lb)).positionCell;
            this.m.AddLivingBeing(lb, targetpos);
            this.m.SetAsActive(true);
            BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell);
            BlackBoard.CurrentMap = this.m;
        }
    }
}
