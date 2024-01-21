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
    public class BroadcastOp
    {
        public static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["mySQLConnection"]);

        public static Tuple<DataTable, ErrorRes> BroadcastExec(BroadcastModel obj)
        {
            ErrorLogModel errlog = new ErrorLogModel();
            DataTable dt = new DataTable();
            ErrorRes res = new ErrorRes();
            try
            {
                errlog.dbActionMode = obj.dbAction;
                errlog.apiName = "USP_BROADCAST - " + obj.dbAction;
                errlog.appName = "BROADCAST";
                errlog.errorDesc = "Procedure Call";
                errlog.logType = "A";
                errlog.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_BROADCAST", con))
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

                        MySqlParameter P_BROADCASTMSG = new MySqlParameter("@P_BROADCASTMSG", MySqlDbType.VarChar, 1000);
                        P_BROADCASTMSG.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.broadcastMsg))
                            P_BROADCASTMSG.Value = obj.broadcastMsg;
                        else
                            P_BROADCASTMSG.Value = DBNull.Value;
                        cmd.Parameters.Add(P_BROADCASTMSG);

                        MySqlParameter P_STATUS = new MySqlParameter("@P_STATUS", MySqlDbType.VarChar, 1);
                        P_STATUS.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.status))
                            P_STATUS.Value = obj.status;
                        else
                            P_STATUS.Value = DBNull.Value;
                        cmd.Parameters.Add(P_STATUS);

                        MySqlParameter P_EXPIRYDATE = new MySqlParameter("@P_EXPIRYDATE", MySqlDbType.Date);
                        P_EXPIRYDATE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.expiryDate))
                            P_EXPIRYDATE.Value = obj.expiryDate;
                        else
                            P_EXPIRYDATE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_EXPIRYDATE);

                        MySqlParameter P_CREATEDBY = new MySqlParameter("@P_CREATEDBY", MySqlDbType.VarChar, 45);
                        P_CREATEDBY.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.createdBy))
                            P_CREATEDBY.Value = obj.createdBy;
                        else
                            P_CREATEDBY.Value = DBNull.Value;
                        cmd.Parameters.Add(P_CREATEDBY);


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
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
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
                obj.errorFlag = "Y";
                errlog.errorDesc = Convert.ToString(ex.Message);
                errlog.logType = "E";
            }

            ErrorLog.LogToDB(errlog);

            res.recordId = obj.recordId;
            res.errorCode = obj.errorCode;
            res.errorFlag = obj.errorFlag;
            res.errorMsg = obj.errorMsg;

            return new Tuple<DataTable, ErrorRes>(dt, res);
        }
    }
}