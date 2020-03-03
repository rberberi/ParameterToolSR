using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Windows;

namespace PTSRDesktopUI.ViewModels
{
    public class ControllerViewModel : Screen
    {
        private readonly IWindowManager manager = new WindowManager();
        private string _path;
        private int _id;

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> ChangesController { get; set; }

        //Create connection to dataAccess class
        DataAccess db = new DataAccess();

        public ControllerViewModel()
        {
            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            //Use the global variable controllerName to call data from database
            //ChangesController = new BindableCollection<ChangesModel>(db.GetChangesController(SelectedController.controllerName));
            ChangesController = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesController(SelectedController.controllerName));

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
            if (MessageBox.Show("Möchten Sie wirklich validieren?", "Validieren", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                model.Validiert = true;
                model.Validierungsdatum = DateTime.Now;
                model.ValidiertVon = LoggedUser.loggedUser;
                db.CheckValidate(model);
                MessageBox.Show("Validierung gespeichert.", "Erfolg!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                return;
            }
        }

        //Unalidate_Btn click event
        public void Unvalidate(ChangesModel model)
        {
            if (MessageBox.Show("Möchten Sie wirklich die Validierung rückgängig machen?", "Validierung rückgängig machen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                model.Validiert = false;
                model.Validierungsdatum = null;
                model.ValidiertVon = null;
                db.UnCheckValidate(model);
                MessageBox.Show("Validierung rückgänging gemacht.", "Erfolg!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                return;
            }
        }

        //Show parameter path
        public void ShowPath(ChangesModel model)
        {
            _path = model.ParameterPfad;
            _id = model.ID;
            NotifyOfPropertyChange(() => Path);
            NotifyOfPropertyChange(() => ID);
        }

        //Property for change ID
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => ID);
            }
        }

        //Property for parameter path
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                NotifyOfPropertyChange(() => Path);
            }
        }
    }
}
