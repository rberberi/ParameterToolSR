using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;

namespace PTSRDesktopUI.ViewModels
{
    public class OverviewViewModel : Screen
    {

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> Changes { get; set; }
        

        public OverviewViewModel()
        {
            //Create connection to dataAccess class
            DataAccess db = new DataAccess();

            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            Changes = new BindableCollection<ChangesModel>(db.GetChangesOverview());

            //Notify Changes for changes
            NotifyOfPropertyChange(() => Changes);

        }

        //Function for ComboBox item to display validated changes
        public void ValidatedChanges()
        {
            DataAccess db = new DataAccess();

            Changes = new BindableCollection<ChangesModel>(db.GetValidatedChangesOverview());
            NotifyOfPropertyChange(() => Changes);
        }

        //Function for ComboBox item to display not validated changes
        public void NotValidatedChanges()
        {
            DataAccess db = new DataAccess();

            Changes = new BindableCollection<ChangesModel>(db.GetNotValidatedChangesOverview());
            NotifyOfPropertyChange(() => Changes);
        }

        //Function for ComboBox item to display all changes
        public void AllChanges()
        {
            DataAccess db = new DataAccess();

            Changes = new BindableCollection<ChangesModel>(db.GetChangesOverview());
            NotifyOfPropertyChange(() => Changes);
        }

        //Validate_Btn click event
        public void Validate()
        {
           //Some Code        
        }

    }
}
