using PTSRDesktopUI.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PTSRDesktopUI.Views
{
    /// <summary>
    /// Interaktionslogik für OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        public OverviewView()
        {
            InitializeComponent();           
            //Sets the login user text block to the global variable for logged in user
            loggedUser_textblock.Text = LoggedUser.loggedUser;    
        }

        //Open Popup when clicking info button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = true;
        }

        //Close Popup when clicking x button
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;
            
        }       
    }
}
