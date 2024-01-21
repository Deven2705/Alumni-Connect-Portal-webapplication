using AlumniConnect.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AlumniConnect.DAL
{
    public class ErrorLog
    {
        public static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["mySQLConnection"]);
        public static void LogToDB(ErrorLogModel err)
        {
            try
            {
                DataTable dt = new DataTable();

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_ERROR_LOG", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter P_DBACTION = new MySqlParameter("@P_DBACTION", MySqlDbType.VarChar, 200);
                        P_DBACTION.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.dbActionMode))
                            P_DBACTION.Value = err.dbActionMode;
                        else
                            P_DBACTION.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DBACTION);

                        MySqlParameter P_LOG_TYPE = new MySqlParameter("@P_LOG_TYPE", MySqlDbType.VarChar, 200);
                        P_LOG_TYPE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.logType))
                            P_LOG_TYPE.Value = err.logType;
                        else
                            P_LOG_TYPE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_LOG_TYPE);

                        MySqlParameter P_LOGIN_ID = new MySqlParameter("@P_LOGIN_ID", MySqlDbType.VarChar, 200);
                        P_LOGIN_ID.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.loginId))
                            P_LOGIN_ID.Value = err.loginId;
                        else
                            P_LOGIN_ID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_LOGIN_ID);

                        MySqlParameter P_APPLICATION_NAME = new MySqlParameter("@P_APPLICATION_NAME", MySqlDbType.VarChar, 200);
                        P_APPLICATION_NAME.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.appName))
                            P_APPLICATION_NAME.Value = err.appName;
                        else
                            P_APPLICATION_NAME.Value = DBNull.Value;
                        cmd.Parameters.Add(P_APPLICATION_NAME);

                        MySqlParameter P_PAGE_API_NAME = new MySqlParameter("@P_PAGE_API_NAME", MySqlDbType.VarChar, 200);
                        P_PAGE_API_NAME.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.apiName))
                            P_PAGE_API_NAME.Value = err.apiName;
                        else
                            P_PAGE_API_NAME.Value = DBNull.Value;
                        cmd.Parameters.Add(P_PAGE_API_NAME);

                        MySqlParameter P_BROWSER = new MySqlParameter("@P_BROWSER", MySqlDbType.VarChar, 200);
                        P_BROWSER.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.browser))
                            P_BROWSER.Value = err.browser;
                        else
                            P_BROWSER.Value = DBNull.Value;
                        cmd.Parameters.Add(P_BROWSER);

                        MySqlParameter P_REQUEST = new MySqlParameter("@P_REQUEST", MySqlDbType.Blob);
                        P_REQUEST.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.request))
                            P_REQUEST.Value = err.request;
                        else
                            P_REQUEST.Value = DBNull.Value;
                        cmd.Parameters.Add(P_REQUEST);

                        MySqlParameter P_RESPONSE = new MySqlParameter("@P_RESPONSE", MySqlDbType.Blob);
                        P_RESPONSE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.response))
                            P_RESPONSE.Value = err.response;
                        else
                            P_RESPONSE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_RESPONSE);

                        MySqlParameter P_ERROR_DESCRIPTION = new MySqlParameter("@P_ERROR_DESCRIPTION", MySqlDbType.VarChar, 200);
                        P_ERROR_DESCRIPTION.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(err.errorDesc))
                            P_ERROR_DESCRIPTION.Value = err.errorDesc;
                        else
                            P_ERROR_DESCRIPTION.Value = DBNull.Value;
                        cmd.Parameters.Add(P_ERROR_DESCRIPTION);

                        con.Open();

                        //Logs.LogMySqlProc(cmd);
                        //cmd.ExecuteReader();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}