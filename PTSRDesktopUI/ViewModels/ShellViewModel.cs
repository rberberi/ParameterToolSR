using Caliburn.Micro;
using PTSRDesktopUI.EventModels;
using PTSRDesktopUI.Helpers;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.ViewModels
{
    public class ShellViewModel:Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private TestViewModel _testVM;
        private SimpleContainer _container;
        public int showMenu = 0; //1-Show Menu, 0-HideMenu

        public ShellViewModel(IEventAggregator events, TestViewModel testVM,
            SimpleContainer container, LoginViewModel loginVM)
        {
            _events = events;
            _testVM = testVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());

        }

        //IsErrorVisible Property
        public bool IsMenuVisible
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

        public void Handle(LogOnEvent message)
        {
            showMenu = 1;
            NotifyOfPropertyChange(() => IsMenuVisible);
            ActivateItem(_testVM);

        }

        public void LogOut()
        {
            _events.PublishOnUIThread(new LogOnEvent());
            ActivateItem(_container.GetInstance<LoginViewModel>());
            showMenu = 0;
            NotifyOfPropertyChange(() => IsMenuVisible);
        }
    }
}
