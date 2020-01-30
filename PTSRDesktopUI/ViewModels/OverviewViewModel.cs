﻿using Caliburn.Micro;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.ViewModels
{
    public class OverviewViewModel : Screen
    {

        //Create new Bindable Collection variable of type ChangesModel
        public BindableCollection<ChangesModel> Changes { get; set; }

        public OverviewViewModel()
        {
            //NotifyOfPropertyChange(() => IsValidateButtonVisible);

            //Create connection to dataAccess class
            DataAccess db = new DataAccess();

            //get the changes from dataAccess function and store them as a bindabla collection in Changes
            Changes = new BindableCollection<ChangesModel>(db.GetChanges());      
        }

        //Is Validate Button Visible Property
        //public bool IsValidateButtonVisible
        //{
        //    get
        //    {
        //        bool output = false;

        //        if (LoggedUser.loggedUser == "admin")
        //        {
        //            output = true;
        //        }
        //        return output;
        //    }
        //}

    }
}
