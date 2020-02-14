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

        DataAccess db = new DataAccess();

        public FacilityViewModel()
        {
            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            //Use the global variable facilityName to call data from database
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetChangesFacility(SelectedFacility.facilityName));

            //Notify ChangesController for changes
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
            model.Validiert = true;
            model.Validierungsdatum = DateTime.Now;
            model.ValidiertVon = LoggedUser.loggedUser;
            db.CheckValidate(model);
            MessageBox.Show("Validierung gespeichert.", "Erfolg!", MessageBoxButton.OK, MessageBoxImage.Information);
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
