using Crawler.Scheduling;

namespace Crawler
{
    using Crawler.Engine;
    using Crawler.Input;

    using Microsoft.Xna.Framework.Graphics;

    public static class BlackBoard
    {
        public static Map CurrentMap;

        public static Camera CurrentCamera;

        public static SpriteBatch CurrentSpriteBatch;

        public static KeyBoardInputHandler InputHandler;

        public static ActionsPool Pool;

        public static Scheduler Scheduler;

    }
}
