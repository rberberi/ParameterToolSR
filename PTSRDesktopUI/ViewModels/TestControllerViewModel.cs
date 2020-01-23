using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using PTSRDesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.ViewModels
{
    public class TestControllerViewModel
    {
        //public List<ChangesModel> changes = new List<ChangesModel>();
        public BindableCollection<ChangesModel> ChangesController { get; set; }
        public string controller = "R40_A";
        public TestControllerViewModel()
        {
            DataAccess db = new DataAccess();
            ChangesController = new BindableCollection<ChangesModel>(db.GetChangesController(controller));
        }
    }
}
