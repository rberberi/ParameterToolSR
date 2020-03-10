using Dapper;
using PTSRDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PTSRDesktopUI.Helpers
{
    class DataAccess
    {

        #region Get User
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
        #endregion

        #region Overview Changes
        //Function to get all changes from database using stored procedures
        public List<ChangesModel> GetChangesOverview()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChangesOverview").ToList();
                return output;
            }
        }

        //Function to get validated changes from database using stored procedures
        public List<ChangesModel> GetValidatedChangesOverview()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getValidatedChangesOverview").ToList();
                return output;
            }
        }

        //Function to get not validated changes from database using stored procedures
        public List<ChangesModel> GetNotValidatedChangesOverview()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getNotValidatedChangesOverview").ToList();
                return output;
            }
        }
        #endregion

        #region Facility Changes
        //Function to get all changes based on facility from database using stored procedures
        public List<ChangesModel> GetChangesFacility(string facility)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChangesFacility @Anlage", new { Anlage = facility }).ToList();
                return output;
            }
        }

        //Function to get validated changes based on facility from database using stored procedures
        public List<ChangesModel> GetValidatedChangesFacility(string facility)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getValidatedChangesFacility @Anlage", new { Anlage = facility }).ToList();
                return output;
            }
        }

        //Function to get not validated changes based on facility from database using stored procedures
        public List<ChangesModel> GetNotValidatedChangesFacility(string facility)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getNotValidatedChangesFacility @Anlage", new { Anlage = facility }).ToList();
                return output;
            }
        }
        #endregion

        #region Controller Changes
        //Function to get all changes based on controller from database using stored procedures
        public List<ChangesModel> GetChangesController(string controller)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getChangesController @Controller", new { Controller = controller }).ToList();
                return output;
            }
        }

        //Function to get validated changes based on controller from database using stored procedures
        public List<ChangesModel> GetValidatedChangesController(string controller)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getValidatedChangesController @Controller", new { Controller = controller }).ToList();
                return output;
            }
        }

        //Function to get not validated changes based on controller from database using stored procedures
        public List<ChangesModel> GetNotValidatedChangesController(string controller)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var output = connection.Query<ChangesModel>("dbo.getNotValidatedChangesController @Controller", new { Controller = controller }).ToList();
                return output;
            }
        }
        #endregion

        #region Validierung

        //Function to validate changes
        public void CheckValidate(ChangesModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var parameters = new { validiert = model.Validiert, validierungsdatum = model.Validierungsdatum, validiertvon=model.ValidiertVon, id = model.ID };
                var sql = "UPDATE ChangesNeu SET Validiert=@validiert, Validierungsdatum = @validierungsdatum, ValidiertVon=@validiertvon FROM ChangesNeu WHERE ID = @id";
                connection.Execute(sql, parameters);
            }
        }

        //Function to undo the validation
        public void UnCheckValidate(ChangesModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.CnnVal("ptsrDB")))
            {
                var parameters = new { validiert = model.Validiert, validierungsdatum = model.Validierungsdatum, validiertvon = model.ValidiertVon, id = model.ID };
                var sql = "UPDATE ChangesNeu SET Validiert=@validiert, Validierungsdatum = @validierungsdatum, ValidiertVon=@validiertvon FROM ChangesNeu WHERE ID = @id";
                connection.Execute(sql, parameters);
            }
        }
        #endregion

    }
}
