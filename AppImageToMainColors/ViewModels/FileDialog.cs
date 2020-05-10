using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImageToMainColors.ViewModels
{
	internal class FileDialog : IFileDialog
	{
		private readonly Microsoft.Win32.FileDialog _fileDialog;

		public FileDialog(Microsoft.Win32.FileDialog fileDialog)
		{
			_fileDialog = fileDialog;
		}

		public string FilePath { get; private set; }

		public bool? ShowDialog()
		{
			_fileDialog.Filter =
				"Image File (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
			_fileDialog.Title = "Please select an image file to convert.";
			_fileDialog.RestoreDirectory = true;

			var FileDialogOpen = _fileDialog.ShowDialog();
			FilePath = FileDialogOpen == true ? _fileDialog.FileName : "";

			return FileDialogOpen;
		}
	}
}
}
