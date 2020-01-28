using MahApps.Metro;
using MahApps.Metro.Controls;
using PTSRDesktopUI.Models;
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

        #region Theme-Change toggle button on window bar

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

        #endregion

        #region Save controller name based on sub-menu controller button click

        private void Btn_R40A_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "R40_A";
        }

        private void Btn_R40B_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "R40_B";
        }

        private void Btn_R40C_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "R40_C";
        }

        private void Btn_R40D_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "R40_D";
        }

        private void Btn_UG10_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "UG10";
        }

        private void Btn_UG20_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "UG20";
        }

        private void Btn_OP30_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP30";
        }

        private void Btn_OP7011_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP70_11";
        }

        private void Btn_OP7012_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP70_12";
        }

        private void Btn_OP7013_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP70_13";
        }

        private void Btn_OP7014_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP70_14";
        }

        private void Btn_2WD_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "2WD";
        }

        private void Btn_4WD_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "4WD";
        }

        private void Btn_OP10_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP10";
        }

        private void Btn_OP40_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP40";
        }

        private void Btn_QLLinks_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "QL_Links";
        }

        private void Btn_QLRechts_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "QL_Rechts";
        }

        #endregion

        #region Save facility name based on menu facility button click

        private void MenuBtn_MFA2_Click(object sender, RoutedEventArgs e)
        {
            SelectedFacility.facilityName = "MFA2";
        }

        private void MenuBtn_B9_Click(object sender, RoutedEventArgs e)
        {
            SelectedFacility.facilityName = "AUDI_B9";
        }

        private void MenuBtn_VAT_Click(object sender, RoutedEventArgs e)
        {
            SelectedFacility.facilityName = "UKL_VAT";
        }

        private void MenuBtn_UKL1_Click(object sender, RoutedEventArgs e)
        {
            SelectedFacility.facilityName = "UKL1";
        }

        private void MenuBtn_UKL2_Click(object sender, RoutedEventArgs e)
        {
            SelectedFacility.facilityName = "UKL2";
        }

        #endregion
    }
}
