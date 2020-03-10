using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PTSRDesktopUI.Models
{
    //public class for all changes attributes
    public class ChangesModel : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Anlage { get; set; }
        public string Controller { get; set; }
        public string Job { get; set; }
        public string Naht { get; set; }
        public string Segment { get; set; }
        public string ParameterPfad { get; set; }
        public string ParameterName { get; set; }
        public string WertAlt { get; set; }
        public string WertNeu { get; set; }
        public DateTime Aenderungsdatum { get; set; }

        private bool _validiert;
        public bool Validiert
        {
            get { return _validiert; }
            set { _validiert = value; NotifyPropertyChanged(); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; NotifyPropertyChanged(); }
        }

        private DateTime? _validierungsdatum;
        public DateTime? Validierungsdatum
        {
            get { return _validierungsdatum; }
            set { _validierungsdatum = value; NotifyPropertyChanged(); }
        }

        private string _validiertVon;
        public string ValidiertVon
        {
            get { return _validiertVon; }
            set { _validiertVon = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
