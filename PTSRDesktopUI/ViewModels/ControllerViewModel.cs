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
    public class ControllerViewModel
    {

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> ChangesController { get; set; }

        public ControllerViewModel()
        {
            //Create connection to dataAccess class
            DataAccess db = new DataAccess();

            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            //Use the global variable controllerName to call data from database
            ChangesController = new BindableCollection<ChangesModel>(db.GetChangesController(SelectedController.controllerName));
        }
    }
}
