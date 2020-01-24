using MahApps.Metro;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace PTSRDesktopUI.Views
{
    /// <summary>
    /// Interaktionslogik für ShellView.xaml
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void ThemeToggleBtn_Checked_1(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppTheme(Application.Current, "BaseDark");
            TextTheme.Text = "Hell";           
            var bc = new BrushConverter();
            TopMenu.Background = (Brush)bc.ConvertFrom("#FF2F2F2F");
            TopMenuItem1.Background = (Brush)bc.ConvertFrom("#FF2F2F2F");
            LogOut.Background = (Brush)bc.ConvertFrom("#FF2F2F2F");

        }

        private void ThemeToggleBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppTheme(Application.Current, "BaseLight");
            TextTheme.Text = "Dunkel";
            var bc = new BrushConverter();
            TopMenu.Background = (Brush)bc.ConvertFrom("#FFF7F7F7");
            TopMenuItem1.Background = (Brush)bc.ConvertFrom("#FFF7F7F7");
            LogOut.Background = (Brush)bc.ConvertFrom("#FFF7F7F7");
        }
    }
}
