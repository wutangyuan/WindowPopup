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

namespace WpfTo3D
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfUPWindow WpfUPWindow = new WpfUPWindow();
        public MainWindow()
        {
            InitializeComponent();
            //WpfUPWindow.Topmost = true;
            //this.Topmost = true;
            WpfUPWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowMove = WpfUPWindow.ParentMoveAction;
            WpfUPWindow.Show();
        }

        private Action<double, double> WindowMove;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WpfUPWindow.Width = this.ActualWidth;
            WpfUPWindow.Height = this.ActualHeight;
            WpfUPWindow.Top = this.Top;
            WpfUPWindow.Left = this.Left;
            WpfUPWindow.Owner = this;   
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            WindowMove?.Invoke(this.Left, this.Top);
        }
    }
}
