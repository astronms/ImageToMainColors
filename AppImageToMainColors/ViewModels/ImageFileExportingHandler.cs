using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace AppImageToMainColors.ViewModels
{
    public class ImageFileExportingHandler 
    {
		public void ExportImageAsFile(BitmapSource bitmapSource, string outputPath)
		{
			if (bitmapSource is null || outputPath is null)
			{
				throw new ArgumentNullException();
			}

			string imageFileFormat = ExtractExtensionFromPath(outputPath);

			var encoder = SelectBitmapEncoder(imageFileFormat);
			encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

			using (var fileStream = new FileStream(outputPath, FileMode.Create))
			{
				encoder.Save(fileStream);
			}
		}
		private string ExtractExtensionFromPath(string path)
		{
			var ext = Path.GetExtension(path);
			try
			{
				ext = ext.Substring(1);
			}
			catch (Exception)
			{
				throw new FileFormatException();
			}

			return ext;
		}
		private BitmapEncoder SelectBitmapEncoder(string imageFileFormat)
		{
			switch (imageFileFormat)
			{
				case "jpg":
					return new JpegBitmapEncoder();
				case "png":
					return new PngBitmapEncoder();
				case "bmp":
					return new BmpBitmapEncoder();
				default:
					return null;
			};
		}

	}
}

