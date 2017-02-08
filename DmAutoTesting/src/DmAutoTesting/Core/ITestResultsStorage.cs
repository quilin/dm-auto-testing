using System.Drawing;

namespace DmAutoTesting.Core
{
    public interface ITestResultsStorage
    {
        void SaveScreenshot(Image image);
        void SaveFile(string fileName, byte[] bytes);
        byte[] ReadFile(string fileName);
    }
}