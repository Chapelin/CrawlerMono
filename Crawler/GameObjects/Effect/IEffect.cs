namespace Crawler.GameObjects.Effect
{
    public interface IEffect<T>
    {
        int TurnToEnd { get; set; }



        bool CanApply(T lb);
        void Apply(T lb);

        void UnApply(T lb);
    }
}
