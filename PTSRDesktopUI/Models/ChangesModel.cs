using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.Models
{
    //public class for all changes attributes
    public class ChangesModel
    {
        public int ID { get; set; }
        public string Anlage { get; set; }
        public string Controller { get; set; }
        public string ParameterName { get; set; }
        public string WertAlt { get; set; }
        public string WertNeu { get; set; }
        public DateTime Aenderungsdatum { get; set; }
        public bool Validiert { get; set; }
        public DateTime? Validierungsdatum { get; set; }
    }
}
