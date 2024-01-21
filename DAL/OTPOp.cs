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
    public class OTPOp
    {
        public static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["mySQLConnection"]); //DB connection details in web.onfig
        public static LoginModel ValidateLogin(LoginModel login)
        {
            ErrorLogModel errlog = new ErrorLogModel();

            try
            {
                errlog.dbActionMode = login.dbAction;
                errlog.apiName = "USP_USER_LOGIN-" + login.dbAction;
                errlog.errorDesc = "Procedure Call";
                errlog.logType = "A";
                errlog.loginId = Convert.ToString(login.mobile);

                DataTable dt = new DataTable();
                //Common common = new Common();
                //string SQLConnString = string.Format("Server=103.129.99.48; database=atyourey_svdm; UID=atyou_svdm; password=svdmDB@2020;");//ConfigurationManager.AppSettings["Mysql"];
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_USER_LOGIN", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        MySqlParameter P_DBMODE = new MySqlParameter("@P_TYPE", MySqlDbType.VarChar, 50);
                        P_DBMODE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.dbAction))
                            P_DBMODE.Value = login.dbAction;
                        else
                            P_DBMODE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DBMODE);

                        MySqlParameter P_RECORD_ID = new MySqlParameter("@P_RECORD_ID", MySqlDbType.Int64);
                        P_RECORD_ID.Direction = ParameterDirection.InputOutput;
                        if (!string.IsNullOrEmpty(login.recordId))
                            P_RECORD_ID.Value = login.recordId;
                        else
                            P_RECORD_ID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_RECORD_ID);

                        MySqlParameter P_LOGIN_ID = new MySqlParameter("@P_LOGIN_ID", MySqlDbType.VarChar, 20);
                        P_LOGIN_ID.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.loginId))
                            P_LOGIN_ID.Value = login.loginId;
                        else
                            P_LOGIN_ID.Value = DBNull.Value;
                        cmd.Parameters.Add(P_LOGIN_ID);

                        MySqlParameter P_MOBILE = new MySqlParameter("@P_MOBILE", MySqlDbType.VarChar, 20);
                        P_MOBILE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.mobile))
                            P_MOBILE.Value = login.mobile;
                        else
                            P_MOBILE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_MOBILE);

                        MySqlParameter P_EMAIL = new MySqlParameter("@P_EMAIL", MySqlDbType.VarChar, 50);
                        P_EMAIL.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.email))
                            P_EMAIL.Value = login.email;
                        else
                            P_EMAIL.Value = DBNull.Value;
                        cmd.Parameters.Add(P_EMAIL);

                        MySqlParameter P_PASSWORD = new MySqlParameter("@P_PASSWORD", MySqlDbType.VarChar, 100);
                        P_PASSWORD.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.password))
                            P_PASSWORD.Value = login.password;
                        else
                            P_PASSWORD.Value = DBNull.Value;
                        cmd.Parameters.Add(P_PASSWORD);

                        MySqlParameter P_STATUS = new MySqlParameter("@P_STATUS", MySqlDbType.VarChar, 1);
                        P_STATUS.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.status))
                            P_STATUS.Value = login.status;
                        else
                            P_STATUS.Value = DBNull.Value;
                        cmd.Parameters.Add(P_STATUS);

                        MySqlParameter P_OTP = new MySqlParameter("@P_OTP", MySqlDbType.VarChar, 10);
                        P_OTP.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.otp))
                            P_OTP.Value = login.otp;
                        else
                            P_OTP.Value = DBNull.Value;
                        cmd.Parameters.Add(P_OTP);

                        MySqlParameter P_AUTHORIZED_BY = new MySqlParameter("@P_AUTHORIZED_BY", MySqlDbType.VarChar, 45);
                        P_AUTHORIZED_BY.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(login.authorizedBy))
                            P_AUTHORIZED_BY.Value = login.authorizedBy;
                        else
                            P_AUTHORIZED_BY.Value = DBNull.Value;
                        cmd.Parameters.Add(P_AUTHORIZED_BY);

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

                        con.Open();

                        //cmd.ExecuteReader();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }

                        errlog.response = Logs.LogMySqlProc(cmd);

                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_RECORD_ID"].Value)))
                        {
                            login.recordId = Convert.ToString(cmd.Parameters["@P_RECORD_ID"].Value);
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_ERRORCODE"].Value)))
                        {
                            login.errorCode = Convert.ToString(cmd.Parameters["@P_ERRORCODE"].Value);
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_ERRORFLAG"].Value)))
                        {
                            login.errorFlag = Convert.ToString(cmd.Parameters["@P_ERRORFLAG"].Value);
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@P_ERRORDESC"].Value)))
                        {
                            login.errorMsg = Convert.ToString(cmd.Parameters["@P_ERRORDESC"].Value);
                        }

                        if(dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                login.role = Convert.ToString(dt.Rows[0]["Role"]);
                            }
                        }

                        try
                        {
                            LoginAuditModel la = new LoginAuditModel();
                            la.dbAction = "INSERT";
                            //la.ip = LoginOp.GetIPAddress();
                            la.mobile = login.mobile;//Convert.ToString(HttpContext.Current.Session["MOBILE"]);
                            la.recordId = Convert.ToString(login.recordId);// Convert.ToString(HttpContext.Current.Session["RECORDID"]);
                            la.role = Convert.ToString(HttpContext.Current.Session["ROLE"]);
                            la.userAgent = Convert.ToString(HttpContext.Current.Request.Headers["User-Agent"]);

                            LoginAudit.LogToDB(la);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            catch (Exception ex)
            {
                login.errorFlag = "Y";
                login.errorMsg = Convert.ToString(ex.Message);
                login.errorCode = "EXC001";

                errlog.errorDesc = Convert.ToString(ex.Message);
                errlog.logType = "E";
            }

            ErrorLog.LogToDB(errlog);

            return login;
        }
    }
}