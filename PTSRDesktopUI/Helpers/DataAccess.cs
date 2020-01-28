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

        //Function to get the login data from database using stored procedures
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

        //Function to get all changes from database using stored procedures
        public List<ChangesModel> GetChanges()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChanges").ToList();
                return output;
            }
        }

        //Function to get changes based on controller from database using stored procedures
        public List<ChangesModel> GetChangesController(string controller)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChangesController @Controller", new { Controller = controller }).ToList();
                return output;
            }
        }

        //Function to get changes based on facility from database using stored procedures
        public List<ChangesModel> GetChangesFacility(string facility)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChangesFacility @Anlage", new { Anlage = facility }).ToList();
                return output;
            }
        }

    }
}
