using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;

namespace PTSRDesktopUI.ViewModels
{
    public class ControllerViewModel : Screen
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

            //Notify ChangesController for changes
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Function for ComboBox item to display validated changes
        public void ValidatedChanges()
        {
            DataAccess db = new DataAccess();

            ChangesController = new BindableCollection<ChangesModel>(db.GetValidatedChangesController(SelectedController.controllerName));
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Function for ComboBox item to display not validated changes
        public void NotValidatedChanges()
        {
            DataAccess db = new DataAccess();

            ChangesController = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesController(SelectedController.controllerName));
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Function for ComboBox item to display all changes
        public void AllChanges()
        {
            DataAccess db = new DataAccess();

            ChangesController = new BindableCollection<ChangesModel>(db.GetChangesController(SelectedController.controllerName));
            NotifyOfPropertyChange(() => ChangesController);
        }
    }
}
