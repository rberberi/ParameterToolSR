using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Windows;

namespace PTSRDesktopUI.ViewModels
{
    public class OverviewViewModel : Screen
    {

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> Changes { get; set; }

        //Create connection to dataAccess class
        DataAccess db = new DataAccess();


        public OverviewViewModel()
        {
            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            Changes = new BindableCollection<ChangesModel>(db.GetChangesOverview());
            
            //Notify for changes
            NotifyOfPropertyChange(() => Changes);

        }

        //Function for ComboBox item to display validated changes
        public void ValidatedChanges()
        {
            Changes = new BindableCollection<ChangesModel>(db.GetValidatedChangesOverview());
            NotifyOfPropertyChange(() => Changes);
        }

        //Function for ComboBox item to display not validated changes
        public void NotValidatedChanges()
        {
            Changes = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesOverview());
            NotifyOfPropertyChange(() => Changes);
        }

        //Function for ComboBox item to display all changes
        public void AllChanges()
        {
            Changes = new BindableCollection<ChangesModel>(db.GetChangesOverview());
            NotifyOfPropertyChange(() => Changes);
        }

        //Validate_Btn click event
        public void Validate(ChangesModel model)
        {
            model.Validiert = true;
            model.Validierungsdatum = DateTime.Now;
            model.ValidiertVon = LoggedUser.loggedUser;
            db.CheckValidate(model);
            MessageBox.Show("Validierung gespeichert.","Erfolg!");
        }

    }
}
