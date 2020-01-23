using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.Models
{
    public class ChangesModel
    {
        public long check_id { get; set; }
        public string controller { get; set; }
        public DateTime detected { get; set; }
        public DateTime updated { get; set; }
        public bool confirmed { get; set; }
        public string reference_value { get; set; }
        public string new_value { get; set; }
        public string node_path { get; set; }
        public string xml_path { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ controller } { detected } { updated }  { confirmed } { reference_value } { new_value } { node_path } { xml_path }";
            }
        }
    }
}
