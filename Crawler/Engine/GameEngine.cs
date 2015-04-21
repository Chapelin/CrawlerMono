#region Using Statements

using Crawler.Cells;

#endregion



namespace Crawler.Engine
{
    using System;
    using System.Linq;

    using Helpers;
    using Input;
    using Living;
    using MapGenerator;
    using Scheduling;
    using UI;

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
            BlackBoard.CurrentSpriteBatch = new SpriteBatch(GraphicsDevice);
            blp = new BasicLogPrinter(this);
            BlackBoard.CurrentCamera = new Camera(new Vector2(15, 11), new Vector2(0, 50), blp);
            scheduler = new Scheduler();
            blp.PositionPixel = new Vector2(517, 420);
            Components.Add(blp);
            donjon = new Dongeon(this, blp);
            m = donjon.CurrentMap;

            scheduler.AddABeing(MapFiller.InitializePlayer(m, this.blp));
            MapFiller.InitializeItems(m, this.blp);
            scheduler.AddABeing(MapFiller.InitializeEnnemis(m, blp));
            base.Initialize();
            hd = new KeyBoardInputHandler();
            m.SetAsActive(true);
            BlackBoard.CurrentMap = m;
            mt = new MouseTargeter(this);
            Components.Add(mt);
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
            BlackBoard.CurrentSpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            base.Draw(gameTime);
            BlackBoard.CurrentSpriteBatch.End();
        }

        public void MoveBeing(LivingBeing p, Vector2 targetPosition)
        {
            BlackBoard.CurrentCamera.Move(targetPosition - p.positionCell);
            Cell cellTarget = (Cell)m.fullBoard.Where(x => x.positionCell == targetPosition).First(x => x is Cell);
            Cell cellGoingout = (Cell)m.fullBoard.Where(x => x.positionCell == p.positionCell).First(x => x is Cell);
            cellGoingout.OnExit(p);
            p.positionCell = targetPosition;
            cellTarget.OnEnter(p);

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
            var targetpos = m.fullBoard.Where(x => x is Cell).First(x => ((Cell)x).IsWalkable(lb)).positionCell;
            m.AddLivingBeing(lb, targetpos);
            m.SetAsActive(true);
            BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell);
            BlackBoard.CurrentMap = m;
        }
    }
}
