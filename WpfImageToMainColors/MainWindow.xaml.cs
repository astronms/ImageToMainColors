using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfImageToMainColors
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FilePath { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButtonClicked_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg,*.png,*bmp)|*.jpg;*.png;*.bmp";
            bool? dialogOK = fileDialog.ShowDialog();
            if (dialogOK == true)
            {
                FilePath = fileDialog.FileName;
            }
        }
    }
}
