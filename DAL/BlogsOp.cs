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
    public class BlogsOp
    {
        public static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["mySQLConnection"]);
        public static Tuple<DataTable, ErrorRes> Blogs(BlogModel obj)
        {
            ErrorLogModel errlog = new ErrorLogModel();
            DataTable dt = new DataTable();
            ErrorRes res = new ErrorRes();
            try
            {
                errlog.dbActionMode = "INSERT";
                errlog.apiName = "USP_BLOGS - " + obj.dbAction;
                errlog.appName = "Blogs";
                errlog.errorDesc = "Procedure Call";
                errlog.logType = "A";
                errlog.loginId = Convert.ToString(HttpContext.Current.Session["EMAIL"]);

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_BLOGS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter P_DBMODE = new MySqlParameter("@P_DBMODE", MySqlDbType.VarChar, 200);
                        P_DBMODE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.dbAction))
                            P_DBMODE.Value = obj.dbAction;
                        else
                            P_DBMODE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DBMODE);

                        MySqlParameter P_RECORD_ID = new MySqlParameter("@P_RECORD_ID", MySqlDbType.Int64, 200);
                        P_RECORD_ID.Direction = ParameterDirection.InputOutput;
                        if (!string.IsNullOrEmpty(obj.recordId))
                            P_RECORD_ID.Value = obj.recordId;
                        else
                            P_RECORD_ID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_RECORD_ID);

                        MySqlParameter P_TITLE = new MySqlParameter("@P_TITLE", MySqlDbType.VarChar, 500);
                        P_TITLE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.title))
                            P_TITLE.Value = obj.title;
                        else
                            P_TITLE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_TITLE);

                        MySqlParameter P_DESCRIPTION = new MySqlParameter("@P_DESCRIPTION", MySqlDbType.VarChar, 3000);
                        P_DESCRIPTION.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.description))
                            P_DESCRIPTION.Value = obj.description;
                        else
                            P_DESCRIPTION.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DESCRIPTION);

                        MySqlParameter P_ACTIVE = new MySqlParameter("@P_ACTIVE", MySqlDbType.VarChar, 1);
                        P_ACTIVE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.active))
                            P_ACTIVE.Value = obj.active;
                        else
                            P_ACTIVE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_ACTIVE);

                        MySqlParameter P_LOGINID = new MySqlParameter("@P_LOGINID", MySqlDbType.VarChar, 200);
                        P_LOGINID.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.loginId))
                            P_LOGINID.Value = obj.loginId;
                        else
                            P_LOGINID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_LOGINID);

                        MySqlParameter P_AUTHZ_LIST = new MySqlParameter("@P_AUTHZ_LIST", MySqlDbType.VarChar, 3000);
                        P_AUTHZ_LIST.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.authzList))
                            P_AUTHZ_LIST.Value = obj.authzList;
                        else
                            P_AUTHZ_LIST.Value = DBNull.Value;
                        cmd.Parameters.Add(P_AUTHZ_LIST);

                        MySqlParameter P_ERRORCODE = new MySqlParameter("@P_ERRORCODE", MySqlDbType.VarChar, 3000);
                        P_ERRORCODE.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(P_ERRORCODE);

                        MySqlParameter P_ERRORFLAG = new MySqlParameter("@P_ERRORFLAG", MySqlDbType.VarChar, 3000);
                        P_ERRORFLAG.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(P_ERRORFLAG);

                        MySqlParameter P_ERRORDESC = new MySqlParameter("@P_ERRORDESC", MySqlDbType.VarChar, 3000);
                        P_ERRORDESC.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(P_ERRORDESC);

                        errlog.request = Logs.LogMySqlProc(cmd);

                        con.Open(); //Open SQL Connetion
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt); //Execute SQL command
                        }

                        errlog.response = Logs.LogMySqlProc(cmd);

                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_RECORD_ID"].Value)))
                        {
                            obj.recordId = Convert.ToString(cmd.Parameters["@P_RECORD_ID"].Value);
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_ERRORCODE"].Value)))
                        {
                            obj.errorCode = Convert.ToString(cmd.Parameters["@P_ERRORCODE"].Value);
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_ERRORFLAG"].Value)))
                        {
                            obj.errorFlag = Convert.ToString(cmd.Parameters["@P_ERRORFLAG"].Value);
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_ERRORDESC"].Value)))
                        {
                            obj.errorMsg = Convert.ToString(cmd.Parameters["@P_ERRORDESC"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj.errorMsg = Convert.ToString(ex.Message);
                obj.errorCode = "ERR001";
                obj.errorFlag = "N";
                errlog.errorDesc = Convert.ToString(ex.Message);
                errlog.logType = "E";
            }

            res.errorCode = obj.errorCode;
            res.errorFlag = obj.errorFlag;
            res.errorMsg = obj.errorMsg;

            ErrorLog.LogToDB(errlog);

            return new Tuple<DataTable, ErrorRes>(dt, res);
        }
    }
}