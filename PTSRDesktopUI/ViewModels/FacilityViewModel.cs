using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PTSRDesktopUI.ViewModels
{
    class FacilityViewModel : Screen
    {
        private readonly IWindowManager manager = new WindowManager();
        private string _path;
        private int _id;

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> ChangesFacility { get; set; }

        //Create connection to dataAccess class
        DataAccess db = new DataAccess();

        //Constructor
        public FacilityViewModel()
        {
            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            //Use the global variable facilityName to call data from database
            //not validated changes are displayed first
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesFacility(SelectedFacility.facilityName));

            //Notify ChangesController for changes
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for refresh button to reload all changes
        public void ReloadAll()
        {
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for refresh button to reload validated changes
        public void ReloadVal()
        {
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetValidatedChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for refresh button to reload not validated changes
        public void ReloadNotVal()
        {
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for ComboBox item to display validated changes
        public void ValidatedChanges()
        {
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetValidatedChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for ComboBox item to display not validated changes
        public void NotValidatedChanges()
        {
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for ComboBox item to display all changes
        public void AllChanges()
        {
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
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
            }
            else
            {
                return;
            }
        }

        //Unvalidate_Btn click event
        public void Unvalidate(ChangesModel model)
        {
            if (MessageBox.Show("Möchten Sie wirklich die Validierung rückgängig machen?", "Validierung rückgängig machen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                model.Validiert = false;
                model.Validierungsdatum = null;
                model.ValidiertVon = null;
                db.UnCheckValidate(model);
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
