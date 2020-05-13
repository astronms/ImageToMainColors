using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppImageToMainColors.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _filePath;
        private bool _isSaveButtonEnable = false;
        private bool _isImageExist = false;
        private BitmapSource _originalImage;
        private string _convertTime;
        private BitmapSource _convertedImage;

        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                NotifyOfPropertyChange(() => FilePath);
            }
        }

        public bool IsImageExist
        {
            get {
                return _isImageExist;
            }
            private set 
            {
                _isImageExist = value;
                NotifyOfPropertyChange(() => IsImageExist);
            }
        }
        public bool IsSaveButtonEnable
        {
            get
            {
                return _isSaveButtonEnable;
            }
            private set
            {
                _isSaveButtonEnable = value;
                NotifyOfPropertyChange(() => IsSaveButtonEnable);
            }
        }

        public BitmapSource OriginalImage
        {
            get
            {
                return _originalImage;
            }
            private set
            {
                _originalImage = value;
                IsImageExist = true;
                NotifyOfPropertyChange(() => OriginalImage);
            }
        }

        public string ConvertTime
        {
            get => _convertTime;
            private set
            {
                _convertTime = value;
                NotifyOfPropertyChange(() => ConvertTime);
            }
        }
        public BitmapSource ConvertedImage
        {
            get
            {
                return _convertedImage;
            }
            private set
            {
                _convertedImage = value;
                IsSaveButtonEnable = true;
                NotifyOfPropertyChange(() => ConvertedImage);
            }
        }
        

        public void OpenFileButtonClicked()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg,*.png,*bmp)|*.jpg;*.png;*.bmp";
            bool? dialogOK = openFileDialog.ShowDialog();
            if (dialogOK == true)
            {
                FilePath = openFileDialog.FileName;
                OriginalImage = new BitmapImage(new Uri(FilePath));
            }
            
        }

        public async Task ConvertSyncButtonClickedAsync()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();
            var output = await processingHandler.ConvertImage(FilePath, false);
            ConvertedImage = output;
            stopWatch.Stop();
            ConvertTime = stopWatch.ElapsedMilliseconds.ToString()+" ms";
        }
        public async Task ConvertAsyncButtonClickedAsync()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ImageProcessingHandler processingHandler = new ImageProcessingHandler();
            var output = await processingHandler.ConvertImage(FilePath, true);
            ConvertedImage = output;
            stopWatch.Stop();
            ConvertTime = stopWatch.ElapsedMilliseconds.ToString()+" ms";
        }

        public void SaveFileButtonClicked()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "Jpg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            
            if (saveFileDialog.ShowDialog() == true)
            {
                ImageFileExportingHandler fileExportinHandler = new ImageFileExportingHandler();
                fileExportinHandler.ExportImageAsFile(ConvertedImage, saveFileDialog.FileName);
            }
        }
    }
}