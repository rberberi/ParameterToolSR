using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Windows;

namespace PTSRDesktopUI.ViewModels
{
    public class ControllerViewModel : Screen
    {

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> ChangesController { get; set; }

        //Create connection to dataAccess class
        DataAccess db = new DataAccess();

        public ControllerViewModel()
        {
            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            //Use the global variable controllerName to call data from database
            ChangesController = new BindableCollection<ChangesModel>(db.GetChangesController(SelectedController.controllerName));

            //Notify ChangesController for changes
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Function for ComboBox item to display validated changes
        public void ValidatedChanges()
        {
            ChangesController = new BindableCollection<ChangesModel>(db.GetValidatedChangesController(SelectedController.controllerName));
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Function for ComboBox item to display not validated changes
        public void NotValidatedChanges()
        {
            ChangesController = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesController(SelectedController.controllerName));
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Function for ComboBox item to display all changes
        public void AllChanges()
        {
            ChangesController = new BindableCollection<ChangesModel>(db.GetChangesController(SelectedController.controllerName));
            NotifyOfPropertyChange(() => ChangesController);
        }

        //Validate_Btn click event
        public void Validate(ChangesModel model)
        {
            model.Validiert = true;
            model.Validierungsdatum = DateTime.Now;
            model.ValidiertVon = LoggedUser.loggedUser;
            db.CheckValidate(model);
            MessageBox.Show("Validierung gespeichert.", "Erfolg!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
