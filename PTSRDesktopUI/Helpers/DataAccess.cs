using Dapper;
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

    }
}
