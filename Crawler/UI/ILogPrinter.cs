﻿namespace Crawler.UI
{
    public interface ILogPrinter
    {
        void AddLine(string text);

        void AddLine(string text, params object[] values);
    }
}