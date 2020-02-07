using Caliburn.Micro;
using MahApps.Metro.Controls;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.ViewModels
{
    public class PopupWindowViewModel : Screen
    {
        private string _path;

        public PopupWindowViewModel(ChangesModel model)
        {
            _path = model.ParameterPfad;
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                NotifyOfPropertyChange(() => Path);
            }
        }


    }
}
