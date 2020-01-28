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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTSRDesktopUI.Views
{
    /// <summary>
    /// Interaktionslogik für FacilityView.xaml
    /// </summary>
    public partial class FacilityView : UserControl
    {
        public FacilityView()
        {
            InitializeComponent();

            //Set the title lable to the selected facility name
            ViewTitle_Lbl.Content = SelectedFacility.facilityName;
        }
    }
}
