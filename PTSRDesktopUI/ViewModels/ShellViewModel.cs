using Caliburn.Micro;
using PTSRDesktopUI.EventModels;
using System;
using System.Windows;

namespace PTSRDesktopUI.ViewModels
{
    //Main Class which controls the application
    public class ShellViewModel:Conductor<object>, IHandle<LogOnEvent>
    {
        //Variables
        private IEventAggregator _events;
        private SimpleContainer _container;
        public int showMenu = 0; //1-Show Menu, 0-HideMenu

        //Constructor
        public ShellViewModel(IEventAggregator events,
            SimpleContainer container, LoginViewModel loginVM)
        {
            try
            {
                _events = events;
                _container = container;

                _events.Subscribe(this);

                ActivateItem(_container.GetInstance<LoginViewModel>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        //Is Side Menu Visible Property
        public bool IsSideMenuVisible
        {
            get
            {
                bool output = false;

                if (showMenu == 1)
                {
                    output = true;
                }
                return output;
            }
        }

        //Controller Submenu Select Function
        public void ControllerSubmenuSelect()
        {
            ControllerViewModel controllerVM = new ControllerViewModel() ;
            ActivateItem(controllerVM);
        }

        //Facility Submenu Select Function
        public void FacilityMenuSelect()
        {
            FacilityViewModel facilityVM = new FacilityViewModel();
            ActivateItem(facilityVM);
        }

        //Hide the submenu function
        public void HideMenu()
        {
            showMenu = 0;
            NotifyOfPropertyChange(() => IsSideMenuVisible);
        }

        //Show the submenu funtion
        public void ShowMenu()
        {
            showMenu = 1;
            NotifyOfPropertyChange(() => IsSideMenuVisible);
        }

        //LogIn and Overview function
        public void Handle(LogOnEvent message)
        {
            showMenu = 1;
            NotifyOfPropertyChange(() => IsSideMenuVisible);
            OverviewViewModel overviewVM = new OverviewViewModel();
            ActivateItem(overviewVM);
        }

        //LogOut function
        public void LogOut()
        {
            _events.PublishOnUIThread(new LogOnEvent());
            ActivateItem(_container.GetInstance<LoginViewModel>());
            showMenu = 0;
            NotifyOfPropertyChange(() => IsSideMenuVisible);
        }
    }
}
