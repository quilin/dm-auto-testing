using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using log4net;

namespace DmAutoTesting.Core
{
    public class TestResultsStorage : ITestResultsStorage
    {
        private static int screenshotNumber;
        private static readonly ImageFormat ImageFormat = ImageFormat.Gif;
        private readonly ILinkMaker linkMaker;
        private readonly ILog log = LogManager.GetLogger(typeof(TestResultsStorage));

        public TestResultsStorage(
            ILinkMaker linkMaker
            )
        {
            this.linkMaker = linkMaker;
        }

        public void SaveScreenshot(Image image)
        {
            var number = Interlocked.Increment(ref screenshotNumber);
            var screenshotName = $"{number}.{ImageFormat}";
            var screenshotPath = linkMaker.MakeScreenshotPath(screenshotName);
            image.Save(screenshotPath, ImageFormat);

            var screenshotLink = linkMaker.MakeScreenshotLink(screenshotName);
            log.InfoFormat("Screenshot saved to {0}", screenshotLink);
        }

        public void SaveFile(string fileName, byte[] bytes)
        {
            throw new System.NotImplementedException();
        }

        public byte[] ReadFile(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}