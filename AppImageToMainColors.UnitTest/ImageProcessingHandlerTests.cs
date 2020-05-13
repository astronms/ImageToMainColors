using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using AppImageToMainColors.ViewModels;
using ImageProcessingLib;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AppImageToMainColors.UnitTest
{
    [TestFixture]
    public class ImageProcessingHandlerTests
    {
        private string _testFileRed =TestContext.CurrentContext.TestDirectory + @"\\TestFiles\blueImage.jpg";
        private string _testFileBlue = TestContext.CurrentContext.TestDirectory + @"\\TestFiles\\blueImage.jpg";
        private string _testFileGreen = TestContext.CurrentContext.TestDirectory + @"\\TestFiles\\greenImage.jpg";

        [Test]
        public async Task ConvertRedImage_ConvertSuccesAsync()
        {
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();
            
            var actual = await processingHandler.ConvertImage(_testFileRed, true);
            
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public async Task ConvertBlueImage_ConvertSuccesAsync()
        {
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();
            
            var actual = await processingHandler.ConvertImage(_testFileBlue, true);
            Assert.That(actual, Is.Not.Null);
        }
        [Test]
        public async Task ConvertGreenImage_ConvertSuccesAsync()
        {
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();

            var actual = await processingHandler.ConvertImage(_testFileGreen, true);
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public async Task ConvertRedImage_ConvertSuccesSync()
        {
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();

            var actual = await processingHandler.ConvertImage(_testFileRed, false);

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public async Task ConvertBlueImage_ConvertSuccesSync()
        {
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();

            var actual = await processingHandler.ConvertImage(_testFileBlue, false);
            Assert.That(actual, Is.Not.Null);
        }
        [Test]
        public async Task ConvertGreenImage_ConvertSuccesSync()
        {
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();

            var actual = await processingHandler.ConvertImage(_testFileGreen, false);
            Assert.That(actual, Is.Not.Null);
        }
    }
}
