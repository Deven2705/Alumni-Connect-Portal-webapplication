using AlumniConnect.BAL;
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
    public class LoginAudit
    {
        public static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["mySQLConnection"]);
        public static void LogToDB(LoginAuditModel obj)
        {
            ErrorLogModel errlog = new ErrorLogModel();
            try
            {
                errlog.dbActionMode = "INSERT";
                errlog.apiName = "USP_AUDIT_LOG";
                errlog.appName = "LoginAudit";
                errlog.errorDesc = "Procedure Call";
                errlog.logType = "A";
                errlog.loginId = Convert.ToString(HttpContext.Current.Session["EMAIL"]);

                DataTable dt = new DataTable();
                //Common common = new Common();
                //string SQLConnString = string.Format("Server=103.129.99.48;port=3306; database=atyourey_svdm; UID=atyou_svdm; password=svdmDB@2020;");//ConfigurationManager.AppSettings["Mysql"];
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_AUDIT_LOG", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter P_DBMODE = new MySqlParameter("@P_DBACTION", MySqlDbType.VarChar, 50);
                        P_DBMODE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.dbAction))
                            P_DBMODE.Value = obj.dbAction;
                        else
                            P_DBMODE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DBMODE);

                        MySqlParameter P_RECORD_ID = new MySqlParameter("@P_RECORD_ID", MySqlDbType.Int64, 50);
                        P_RECORD_ID.Direction = ParameterDirection.InputOutput;
                        if (obj.recordId != null)
                            P_RECORD_ID.Value = obj.recordId;
                        else
                            P_RECORD_ID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_RECORD_ID);

                        MySqlParameter P_LOGIN_ID = new MySqlParameter("@P_LOGIN_ID", MySqlDbType.VarChar, 50);
                        P_LOGIN_ID.Direction = ParameterDirection.Input;
                        if (obj.recordId != null)
                            P_LOGIN_ID.Value = obj.recordId;
                        else
                            P_LOGIN_ID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_LOGIN_ID);

                        MySqlParameter P_MOBILE = new MySqlParameter("@P_MOBILE", MySqlDbType.VarChar, 50);
                        P_MOBILE.Direction = ParameterDirection.Input;
                        if (obj.mobile != null)
                            P_MOBILE.Value = obj.mobile;
                        else
                            P_MOBILE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_MOBILE);

                        MySqlParameter P_EMAIL = new MySqlParameter("@P_EMAIL", MySqlDbType.VarChar, 50);
                        P_EMAIL.Direction = ParameterDirection.Input;
                        if (obj.email != null)
                            P_EMAIL.Value = obj.email;
                        else
                            P_EMAIL.Value = DBNull.Value;
                        cmd.Parameters.Add(P_EMAIL);

                        MySqlParameter P_IP = new MySqlParameter("@P_IP", MySqlDbType.VarChar, 20);
                        P_IP.Direction = ParameterDirection.Input;
                        if (obj.ip != null)
                            P_IP.Value = obj.ip;
                        else
                            P_IP.Value = DBNull.Value;
                        cmd.Parameters.Add(P_IP);

                        MySqlParameter P_USERAGENT = new MySqlParameter("@P_USERAGENT", MySqlDbType.VarChar, 500);
                        P_USERAGENT.Direction = ParameterDirection.Input;
                        if (obj.userAgent != null)
                            P_USERAGENT.Value = obj.userAgent;
                        else
                            P_USERAGENT.Value = DBNull.Value;
                        cmd.Parameters.Add(P_USERAGENT);

                        MySqlParameter P_ROLE = new MySqlParameter("@P_ROLE", MySqlDbType.VarChar, 500);
                        P_ROLE.Direction = ParameterDirection.Input;
                        if (obj.role != null)
                            P_ROLE.Value = obj.role;
                        else
                            P_ROLE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_ROLE);

                        con.Open();

                        errlog.request = Logs.LogMySqlProc(cmd);
                        //cmd.ExecuteReader();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }

                        errlog.response = Logs.LogMySqlProc(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                errlog.errorDesc = Convert.ToString(ex.Message);
                errlog.logType = "E";
            }

            ErrorLog.LogToDB(errlog);
        }
    }
}