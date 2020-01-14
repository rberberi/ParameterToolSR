using Caliburn.Micro;
using PTSRDesktopUI.EventModels;
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

        public ShellViewModel(IEventAggregator events, TestViewModel testVM,
            SimpleContainer container)
        {
            _events = events;
            _testVM = testVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_testVM);          
        }

        public void LogOut()
        {
            _events.PublishOnUIThread(new LogOnEvent());
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }
    }
}
