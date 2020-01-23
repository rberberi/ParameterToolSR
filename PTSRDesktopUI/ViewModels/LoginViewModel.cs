using Caliburn.Micro;
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
        private string _userName;
        private string _password;
        private IEventAggregator _events;

        public LoginViewModel(IEventAggregator events)
        {
            _events = events;
        }

        //Username Getter-Setter
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

        //Password Getter-Setter
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

                DataAccess db = new DataAccess();

                string value = db.getUser(UserName, Password);
                int test = Convert.ToInt16(value); 
                if (test == 1)
                {            
                    _events.PublishOnUIThread(new LogOnEvent());
                }
                else 
                {
                    MessageBox.Show("Anmeldedaten sind falsch oder Benutzer existiert nicht!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
