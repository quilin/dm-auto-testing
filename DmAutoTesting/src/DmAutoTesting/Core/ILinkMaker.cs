namespace DmAutoTesting.Core
{
    public interface ILinkMaker
    {
        string ScreenshotsDirectory { get; }
        string FilesDirectory { get; }
        string BrowserLogsDirectory { get; }

        string MakeScreenshotLink(string fileName);
        string MakeScreenshotPath(string fileName);
        string MakeFileLink(string fileName);
        string MakeFilePath(string fileName);
        string MakeBrowserLogLink(string fileName);
        string MakeBrowserLogPath(string fileName);
    }
}