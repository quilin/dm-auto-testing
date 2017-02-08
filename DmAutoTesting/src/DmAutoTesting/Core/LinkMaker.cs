using System.IO;

namespace DmAutoTesting.Core
{
    public class LinkMaker : ILinkMaker
    {
        private readonly string outputDirectory;
        private readonly string linkPrefix;

        public LinkMaker()
        {
            const string outputDirectoryPath = "f:/work/"; // todo: put it in configuration
            outputDirectory = Path.GetFullPath(outputDirectoryPath);

            linkPrefix = "http://localhost:9000"; // todo: put it in configuration
            if (string.IsNullOrWhiteSpace(linkPrefix))
            {
                var linkPath = outputDirectory.Replace(Path.DirectorySeparatorChar, '/');
                linkPrefix = $"file:///{linkPath}";
            }
        }
        public string ScreenshotsDirectory => Path.Combine(outputDirectory, "Screenshots");

        public string FilesDirectory => Path.Combine(outputDirectory, "Files");

        public string BrowserLogsDirectory => Path.Combine(outputDirectory, "BrowserLogs");

        public string MakeScreenshotLink(string fileName)
        {
            return $"{linkPrefix}/Screenshots/{fileName}";
        }

        public string MakeScreenshotPath(string fileName)
        {
            return Path.Combine(ScreenshotsDirectory, fileName);
        }

        public string MakeFileLink(string fileName)
        {
            return $"{linkPrefix}/Files/{fileName}";
        }

        public string MakeFilePath(string fileName)
        {
            return Path.Combine(FilesDirectory, fileName);
        }

        public string MakeBrowserLogLink(string fileName)
        {
            return $"{linkPrefix}/BrowserLogs/{fileName}";
        }

        public string MakeBrowserLogPath(string fileName)
        {
            return Path.Combine(BrowserLogsDirectory, fileName);
        }
    }
}