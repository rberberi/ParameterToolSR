using Caliburn.Micro;
using MahApps.Metro.Controls;
using PTSRDesktopUI.EventModels;
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
    public class LoginViewModel : Screen
    {
        //Variables
        private string _userName;
        private string _password;
        private IEventAggregator _events;

        //Constructor
        public LoginViewModel(IEventAggregator events)
        {
            _events = events;
        }

        //Username Property
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        //Password Property
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        //CanLogIn function
        public bool CanLogIn
        {
            get
            {
                bool output = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        //LogIn function
        public void LogIn()
        {
            try
            {
                //Create connection to dataAccess class
                DataAccess db = new DataAccess();

                //Save recieved value from dataccess function in temp value
                //Value is either 1 or 0 in string from
                string tempValue = db.getUser(UserName, Password);
                //Convert the temp value to integer and save it in result variable
                int result = Convert.ToInt16(tempValue); 
                //If result is 1 then login, else give login error message
                if (result == 1)
                {
                    LoggedUser.loggedUser = UserName;
                    _events.PublishOnUIThread(new LogOnEvent());
                }
                else 
                {
                    MessageBox.Show("Anmeldedaten sind falsch oder Benutzer existiert nicht!","Fehler");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
