using Caliburn.Micro;
using PTSRDesktopUI.ViewModels;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using PTSRDesktopUI.Helpers;

namespace PTSRDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            try
            {
                Initialize();

                ConventionManager.AddElementConvention<PasswordBox>(
                    PasswordBoxHelper.BoundPasswordProperty,
                    "Password",
                    "PasswordChanged");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

        }

        protected override void Configure()
        {
            try
            {
                _container.Instance(_container);

                _container
                    .Singleton<IWindowManager, WindowManager>()
                    .Singleton<IEventAggregator, EventAggregator>();

                GetType().Assembly.GetTypes()
                    .Where(type => type.IsClass)
                    .Where(type => type.Name.EndsWith("ViewModel"))
                    .ToList()
                    .ForEach(viewModelType => _container.RegisterPerRequest(
                        viewModelType, viewModelType.ToString(), viewModelType));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                DisplayRootViewFor<ShellViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            try
            {
                 _container.BuildUp(instance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }          
        }
    }
}