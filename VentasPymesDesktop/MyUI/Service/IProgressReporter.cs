using System;

namespace MyUI.Service
{
    public interface IProgressReporter
    {
        event EventHandler<string> ProgressChanged;
        void ReportProgress(string message);
    }
}
