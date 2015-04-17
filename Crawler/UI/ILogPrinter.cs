namespace Crawler.UI
{
    public interface ILogPrinter
    {
        void WriteLine(string text);

        void WriteLine(string text, params object[] values);
    }
}