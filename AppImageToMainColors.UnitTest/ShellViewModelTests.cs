using System;
using System.Threading;
using System.Windows.Media.Imaging;
using AppImageToMainColors.ViewModels;
using Microsoft.Win32;
using NUnit.Framework;

namespace AppImageToMainColors.UnitTest
{
    [TestFixture]
    public class ShellViewModelTests
    {

        private readonly string _testFileRed = TestContext.CurrentContext.TestDirectory + @"\\TestFiles\\redImage.jpg";
        private readonly string _testFileBlue = TestContext.CurrentContext.TestDirectory + @"\\TestFiles\\blueImage.jpg";
        private readonly string _testFileGreen = TestContext.CurrentContext.TestDirectory + @"\\TestFiles\\greenImage.jpg";



        [Test]
        public void NewFileLocation_NewImageLoadedCorrectly()
        {
            ShellViewModel shellViewModel = new ShellViewModel();
            shellViewModel.FilePath = _testFileRed;
            shellViewModel.OpenFileButtonClicked();
            var actual = shellViewModel.OriginalImage;
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void NewImageLoaded_IsConvertButtonsActive()
        {
            ShellViewModel shellViewModel = new ShellViewModel();
            shellViewModel.FilePath = _testFileRed;
            shellViewModel.OpenFileButtonClicked();
            var expected = true;
            var actual = shellViewModel.IsImageExist;
            Assert.That(actual, Is.EqualTo(expected));
        }

        public async System.Threading.Tasks.Task ConvertedImageExist_IsSavesActiveAsync()
        {
            ShellViewModel shellViewModel = new ShellViewModel();
            shellViewModel.FilePath = _testFileRed;
            shellViewModel.OpenFileButtonClicked();
            await shellViewModel.ConvertSyncButtonClickedAsync();
            
            var expected = true;
            var actual = shellViewModel.IsSaveButtonEnable;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
