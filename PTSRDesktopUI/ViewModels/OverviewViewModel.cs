using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using PTSRDesktopUI.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace PTSRDesktopUI.ViewModels
{
    public class OverviewViewModel : Conductor<object>
    {
        private readonly IWindowManager manager = new WindowManager();

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

        public void ShowPath(ChangesModel model)
        {
            //PopupWindowViewModel popup = new PopupWindowViewModel(model);
            //var popup = new PopupWindowViewModel(model);
            //ActivateItem(popup);
            //window.ShowDialog(popup);
            ////or
            ////window.ShowWindow(model); //For non-modal
            //bool CloseItemAfterDeactivating = true;
            //DeactivateItem(popup, CloseItemAfterDeactivating);
            manager.ShowWindow(new PopupWindowViewModel(model), null, null);
            
        }

        //Validate_Btn click event
        public void Validate(ChangesModel model)
        {
            model.Validiert = true;
            model.Validierungsdatum = DateTime.Now;
            model.ValidiertVon = LoggedUser.loggedUser;
            db.CheckValidate(model);
            MessageBox.Show("Validierung gespeichert.","Erfolg!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
