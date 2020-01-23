using Dapper;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSRDesktopUI.Helpers
{
    class DataAccess
    {

        public string getUser(string userName, string password)
        {
            string value = "";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var userData = connection.Query("dbo.getUser @Username, @Password", new { Password = password, Username = userName });
                foreach (IDictionary<string, object> row in userData)
                {
                    foreach (var pair in row)
                    {
                        value = Convert.ToString(pair.Value);
                    }
                }
                return value;
            }
        }

        public string getUsername(string userName)
        {
            string value = "";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var username = connection.Query("dbo.getUsername @Username", new { Username = userName });
                foreach (IDictionary<string, object> row in username)
                {
                    foreach (var pair in row)
                    {
                        value = Convert.ToString(pair.Value);
                    }
                }
                return value;
            }
        }

        public List<ChangesModel> GetChanges(string controller)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("routineChangesDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChanges @controller", new { controller = controller }).ToList();
                return output;
            }
        }

    }
}
