using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppImageToMainColors.ViewModels
{
	public class ImageProcessingHandler 
	{
		public async Task<BitmapSource> ConvertImage(string path, bool doAsync)
		{
			if (doAsync == true)
			{
				var uri = new Uri(path);
				var originalImage = new BitmapImage(uri);
				originalImage.Freeze();
				return await Task.Run(() => ImageProcessingLib.ImageProcessing.ToMainColorsAsync(originalImage));

			}
			else
			{
				var uri = new Uri(path);
				var originalImage = new BitmapImage(uri);
				originalImage.Freeze();
				return await Task.Run(() => ImageProcessingLib.ImageProcessing.ToMainColorsSync(originalImage));
			}

		}
	}
}
