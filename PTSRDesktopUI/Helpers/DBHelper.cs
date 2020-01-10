using System.Configuration;

namespace PTSRDesktopUI.Helpers
{
    public static class DBHelper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
