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
    //Main Class which controls the application
    public class ShellViewModel:Conductor<object>, IHandle<LogOnEvent>
    {
        //Variables
        private IEventAggregator _events;
        private OverviewViewModel _testVM;
        private SimpleContainer _container;
        public int showMenu = 0; //1-Show Menu, 0-HideMenu

        //Constructor
        public ShellViewModel(IEventAggregator events, OverviewViewModel testVM,
            SimpleContainer container, LoginViewModel loginVM)
        {
            _events = events;
            _testVM = testVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());

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

        //LogIn function
        public void Handle(LogOnEvent message)
        {
            showMenu = 1;
            NotifyOfPropertyChange(() => IsSideMenuVisible);
            ActivateItem(_testVM);
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
