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
    public class TestViewModel : Screen
    {
        //public List<ChangesModel> changes = new List<ChangesModel>();
        public BindableCollection<ChangesModel> Changes { get; set; }
        public string anlage = "OP30";

        public TestViewModel()
        {
            DataAccess db = new DataAccess();
            Changes = new BindableCollection<ChangesModel>(db.GetChanges(anlage));
        }
    }
}
