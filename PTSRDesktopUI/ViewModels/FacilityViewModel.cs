using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.ViewModels
{
    class FacilityViewModel : Screen
    {

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> ChangesFacility { get; set; }

        public FacilityViewModel()
        {
            //Create connection to dataAccess class
            DataAccess db = new DataAccess();

            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            //Use the global variable facilityName to call data from database
            ChangesFacility = new BindableCollection<ChangesModel>(db.GetChangesFacility(SelectedFacility.facilityName));

            //Notify ChangesController for changes
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for ComboBox item to display validated changes
        public void ValidatedChanges()
        {
            DataAccess db = new DataAccess();

            ChangesFacility = new BindableCollection<ChangesModel>(db.GetValidatedChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for ComboBox item to display not validated changes
        public void NotValidatedChanges()
        {
            DataAccess db = new DataAccess();

            ChangesFacility = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

        //Function for ComboBox item to display all changes
        public void AllChanges()
        {
            DataAccess db = new DataAccess();

            ChangesFacility = new BindableCollection<ChangesModel>(db.GetChangesFacility(SelectedFacility.facilityName));
            NotifyOfPropertyChange(() => ChangesFacility);
        }

    }
}
