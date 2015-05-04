using System.Collections.Generic;

namespace Crawler.Engine
{
    using System;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.GameObjects.Living;
    using Crawler.Helpers;
    using Crawler.Input;
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

        private KeyBoardInputHandler keyBoardInputHandler;

        private Map map;

        private LivingBeing beingToPlay;
        private Dongeon donjon;

        private ActionsPool poolOfAction;

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
            this.poolOfAction = new ActionsPool();
            BlackBoard.Pool = this.poolOfAction;
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
            BlackBoard.LogPrinter = new BasicLogPrinter(this);
            BlackBoard.CurrentCamera = new Camera(new Vector2(15, 11), new Vector2(0, 50));
            BlackBoard.Scheduler = new Scheduler();
            BlackBoard.LogPrinter.PositionPixel = new Vector2(517, 420);
            this.Components.Add(BlackBoard.LogPrinter);
            this.donjon = new Dongeon(this);
            this.map = this.donjon.CurrentMap;

            MapFiller.InitializePlayer(this.map);
            MapFiller.InitializeItems(this.map);
            MapFiller.InitializeEnnemis(this.map);
            base.Initialize();
            this.keyBoardInputHandler = new KeyBoardInputHandler();
            BlackBoard.InputHandler = this.keyBoardInputHandler;
            this.map.SetAsActive(true);
            BlackBoard.CurrentMap = this.map;
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
                this.beingToPlay = BlackBoard.Scheduler.CurrentPlaying();

                if (!this.beingToPlay.IsUserControlled)
                {
                    this.beingToPlay.AutoPlay();
                    BlackBoard.Scheduler.Played();
                    this.beingToPlay = null;
                }
            }

            this.map.HandleVisibility(this.beingToPlay);
            this.keyBoardInputHandler.HandleInput(this.beingToPlay, this.poolOfAction);

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
            Cell cellTarget = this.map.fullBoard.Where<Cell>(x => x.positionCell == targetPosition).First();
            Cell cellGoingout = this.map.fullBoard.Where<Cell>(x => x.positionCell == p.positionCell).First();
            cellGoingout.OnExit(p);
            p.positionCell = targetPosition;
            cellTarget.OnEnter(p);

            // we have played, so we remove it
            BlackBoard.Scheduler.Played();
            this.beingToPlay = null;
        }

        public void ChangeMap(LivingBeing lb, bool goingDown)
        {
            var nextLVL = this.donjon.CurrentLevel + (goingDown ? 1 : -1);
            this.map.RemoveLivingBeing(lb);
            if (!lb.IsUserControlled)
                throw new Exception("Error");
            this.map.SetAsActive(false);
            this.donjon.CurrentLevel = nextLVL;
            this.map = this.donjon.CurrentMap;
            var targetpos = this.map.fullBoard.Where(x => x is Cell).First(x => ((Cell)x).IsWalkable(lb)).positionCell;
            this.map.AddLivingBeing(lb, targetpos);
            this.map.SetAsActive(true);
            BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell);
            BlackBoard.CurrentMap = this.map;
        }
    }
}
