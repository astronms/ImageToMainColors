using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImageToMainColors.ViewModels
{
    public interface IFileDialog
    {
        string FilePath { get; }
        bool? ShowDialog();
    }
}
