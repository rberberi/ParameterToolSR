using MahApps.Metro.Controls;
using PTSRDesktopUI.Models;
using System.Windows;

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
            SelectedController.controllerName = "OP70_21";
        }

        private void Btn_OP7013_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP70_31";
        }

        private void Btn_OP7014_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "OP70_41";
        }

        private void Btn_2WD_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "Audi_B9_2WD";
        }

        private void Btn_4WD_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "Audi_B9_4WD";
        }

        private void Btn_OP10_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "UKL_VAT_OP10";
        }

        private void Btn_OP40_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "UKL_VAT_OP40";
        }

        private void Btn_QLLinks_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "40_11";
        }

        private void Btn_QLRechts_Click(object sender, RoutedEventArgs e)
        {
            SelectedController.controllerName = "40_12";
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

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Handle.IsChecked = true;
        }
    }
}
