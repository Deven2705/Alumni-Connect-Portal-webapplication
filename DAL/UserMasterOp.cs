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
    public class UserMasterOp
    {
        public static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["mySQLConnection"]); //DB connection details in web.onfig

        public static Tuple<DataTable, ErrorRes> UserMaster(UserMasterModel obj)
        {
            ErrorLogModel errlog = new ErrorLogModel(); //Error logging
            DataTable dt = new DataTable();
            ErrorRes res = new ErrorRes();
            try
            {
                errlog.dbActionMode = "INSERT";
                errlog.apiName = "USP_USER_MASTER - " + obj.dbAction;
                errlog.appName = "User Master";
                errlog.errorDesc = "Procedure Call";
                errlog.logType = "A";
                errlog.loginId = Convert.ToString(obj.emailID);

                using (MySqlConnection con = new MySqlConnection(connectionString)) // Establish connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_USER_MASTER", con)) // Set Command
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

                        MySqlParameter P_NAME = new MySqlParameter("@P_NAME", MySqlDbType.VarChar, 200);
                        P_NAME.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.name))
                            P_NAME.Value = obj.name;
                        else
                            P_NAME.Value = DBNull.Value;
                        cmd.Parameters.Add(P_NAME);

                        MySqlParameter P_NICK_NAME = new MySqlParameter("@P_NICK_NAME", MySqlDbType.VarChar, 50);
                        P_NICK_NAME.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.nickName))
                            P_NICK_NAME.Value = obj.nickName;
                        else
                            P_NICK_NAME.Value = DBNull.Value;
                        cmd.Parameters.Add(P_NICK_NAME);

                        MySqlParameter P_EMAIL = new MySqlParameter("@P_EMAIL", MySqlDbType.VarChar, 200);
                        P_EMAIL.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.emailID))
                            P_EMAIL.Value = obj.emailID;
                        else
                            P_EMAIL.Value = DBNull.Value;
                        cmd.Parameters.Add(P_EMAIL);

                        MySqlParameter P_MOBILE = new MySqlParameter("@P_MOBILE", MySqlDbType.VarChar, 20);
                        P_MOBILE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.mobileNo))
                            P_MOBILE.Value = obj.mobileNo;
                        else
                            P_MOBILE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_MOBILE);

                        MySqlParameter P_DOB = new MySqlParameter("@P_DOB", MySqlDbType.DateTime, 200);
                        P_DOB.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.dob))
                            P_DOB.Value = obj.dob;
                        else
                            P_DOB.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DOB);

                        MySqlParameter P_GENDER = new MySqlParameter("@P_GENDER", MySqlDbType.VarChar, 1);
                        P_GENDER.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.gender))
                            P_GENDER.Value = obj.gender;
                        else
                            P_GENDER.Value = DBNull.Value;
                        cmd.Parameters.Add(P_GENDER);

                        MySqlParameter P_BLOOD_GROUP = new MySqlParameter("@P_BLOOD_GROUP", MySqlDbType.VarChar, 10);
                        P_BLOOD_GROUP.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.bloodGroup))
                            P_BLOOD_GROUP.Value = obj.bloodGroup;
                        else
                            P_BLOOD_GROUP.Value = DBNull.Value;
                        cmd.Parameters.Add(P_BLOOD_GROUP);

                        MySqlParameter P_CITY = new MySqlParameter("@P_CITY", MySqlDbType.VarChar, 200);
                        P_CITY.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.city))
                            P_CITY.Value = obj.city;
                        else
                            P_CITY.Value = DBNull.Value;
                        cmd.Parameters.Add(P_CITY);

                        MySqlParameter P_NATIVE = new MySqlParameter("@P_NATIVE", MySqlDbType.VarChar, 200);
                        P_NATIVE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.nativePlace))
                            P_NATIVE.Value = obj.nativePlace;
                        else
                            P_NATIVE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_NATIVE);

                        MySqlParameter P_STATE = new MySqlParameter("@P_STATE", MySqlDbType.VarChar, 200);
                        P_STATE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.state))
                            P_STATE.Value = obj.state;
                        else
                            P_STATE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_STATE);

                        MySqlParameter P_COUNTRY = new MySqlParameter("@P_COUNTRY", MySqlDbType.VarChar, 200);
                        P_COUNTRY.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.country))
                            P_COUNTRY.Value = obj.country;
                        else
                            P_COUNTRY.Value = DBNull.Value;
                        cmd.Parameters.Add(P_COUNTRY);

                        MySqlParameter P_BRANCH = new MySqlParameter("@P_BRANCH", MySqlDbType.VarChar, 200);
                        P_BRANCH.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.branch))
                            P_BRANCH.Value = obj.branch;
                        else
                            P_BRANCH.Value = DBNull.Value;
                        cmd.Parameters.Add(P_BRANCH);

                        MySqlParameter P_ADDMISSION_YEAR = new MySqlParameter("@P_ADDMISSION_YEAR", MySqlDbType.VarChar, 4);
                        P_ADDMISSION_YEAR.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.admissionYear))
                            P_ADDMISSION_YEAR.Value = obj.admissionYear;
                        else
                            P_ADDMISSION_YEAR.Value = DBNull.Value;
                        cmd.Parameters.Add(P_ADDMISSION_YEAR);

                        MySqlParameter P_PASSOUT_YEAR = new MySqlParameter("@P_PASSOUT_YEAR", MySqlDbType.VarChar, 4);
                        P_PASSOUT_YEAR.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.passoutYear))
                            P_PASSOUT_YEAR.Value = obj.passoutYear;
                        else
                            P_PASSOUT_YEAR.Value = DBNull.Value;
                        cmd.Parameters.Add(P_PASSOUT_YEAR);

                        MySqlParameter P_HOBBIES = new MySqlParameter("@P_HOBBIES", MySqlDbType.VarChar, 500);
                        P_HOBBIES.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.hobbies))
                            P_HOBBIES.Value = obj.hobbies;
                        else
                            P_HOBBIES.Value = DBNull.Value;
                        cmd.Parameters.Add(P_HOBBIES);

                        MySqlParameter P_COMPANYNAME = new MySqlParameter("@P_COMPANYNAME", MySqlDbType.VarChar, 500);
                        P_COMPANYNAME.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.companyName))
                            P_COMPANYNAME.Value = obj.companyName;
                        else
                            P_COMPANYNAME.Value = DBNull.Value;
                        cmd.Parameters.Add(P_COMPANYNAME);

                        MySqlParameter P_DESIGNATION = new MySqlParameter("@P_DESIGNATION", MySqlDbType.VarChar, 500);
                        P_DESIGNATION.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.designation))
                            P_DESIGNATION.Value = obj.designation;
                        else
                            P_DESIGNATION.Value = DBNull.Value;
                        cmd.Parameters.Add(P_DESIGNATION);

                        MySqlParameter P_HIGHER_EDUCATION = new MySqlParameter("@P_HIGHER_EDUCATION", MySqlDbType.VarChar, 500);
                        P_HIGHER_EDUCATION.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.higherEducation))
                            P_HIGHER_EDUCATION.Value = obj.higherEducation;
                        else
                            P_HIGHER_EDUCATION.Value = DBNull.Value;
                        cmd.Parameters.Add(P_HIGHER_EDUCATION);

                        MySqlParameter P_BACHELOR_DEGREE = new MySqlParameter("@P_BACHELOR_DEGREE", MySqlDbType.VarChar, 500);
                        P_BACHELOR_DEGREE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.bachelorDegree))
                            P_BACHELOR_DEGREE.Value = obj.bachelorDegree;
                        else
                            P_BACHELOR_DEGREE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_BACHELOR_DEGREE);

                        MySqlParameter P_SPECIALIZATION = new MySqlParameter("@P_SPECIALIZATION", MySqlDbType.VarChar, 500);
                        P_SPECIALIZATION.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.specialization))
                            P_SPECIALIZATION.Value = obj.specialization;
                        else
                            P_SPECIALIZATION.Value = DBNull.Value;
                        cmd.Parameters.Add(P_SPECIALIZATION);

                        MySqlParameter P_IMG_URL = new MySqlParameter("@P_IMG_URL", MySqlDbType.VarChar, 1000);
                        P_IMG_URL.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.imgUrl))
                            P_IMG_URL.Value = obj.imgUrl;
                        else
                            P_IMG_URL.Value = DBNull.Value;
                        cmd.Parameters.Add(P_IMG_URL);

                        MySqlParameter P_EXPERIENCE = new MySqlParameter("@P_EXPERIENCE", MySqlDbType.VarChar, 3000);
                        P_EXPERIENCE.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.experience))
                            P_EXPERIENCE.Value = obj.experience;
                        else
                            P_EXPERIENCE.Value = DBNull.Value;
                        cmd.Parameters.Add(P_EXPERIENCE);

                        MySqlParameter P_ABOUT = new MySqlParameter("@P_ABOUT", MySqlDbType.VarChar, 3000);
                        P_ABOUT.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.about))
                            P_ABOUT.Value = obj.about;
                        else
                            P_ABOUT.Value = DBNull.Value;
                        cmd.Parameters.Add(P_ABOUT);

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

                        MySqlParameter P_LINKED_IN = new MySqlParameter("@P_LINKED_IN", MySqlDbType.VarChar, 200);
                        P_LINKED_IN.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.linkedIn))
                            P_LINKED_IN.Value = obj.linkedIn;
                        else
                            P_LINKED_IN.Value = DBNull.Value;
                        cmd.Parameters.Add(P_LINKED_IN);

                        MySqlParameter P_PASSWORD = new MySqlParameter("@P_PASSWORD", MySqlDbType.VarChar, 100);
                        P_PASSWORD.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.password))
                            P_PASSWORD.Value = obj.password;
                        else
                            P_PASSWORD.Value = DBNull.Value;
                        cmd.Parameters.Add(P_PASSWORD);


                        MySqlParameter P_BDAY_FLAG = new MySqlParameter("@P_BDAY_FLAG", MySqlDbType.VarChar, 1);
                        P_BDAY_FLAG.Direction = ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(obj.bdayFlag))
                            P_BDAY_FLAG.Value = obj.bdayFlag;
                        else
                            P_BDAY_FLAG.Value = DBNull.Value;
                        cmd.Parameters.Add(P_BDAY_FLAG);

                        MySqlParameter P_ERRORCODE = new MySqlParameter("@P_ERRORCODE", MySqlDbType.VarChar, 3000);
                        P_ERRORCODE.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(P_ERRORCODE);

                        MySqlParameter P_ERRORFLAG = new MySqlParameter("@P_ERRORFLAG", MySqlDbType.VarChar, 3000);
                        P_ERRORFLAG.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(P_ERRORFLAG);

                        MySqlParameter P_ERRORDESC = new MySqlParameter("@P_ERRORDESC", MySqlDbType.VarChar, 3000);
                        P_ERRORDESC.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(P_ERRORDESC);

                        //errlog.request = Logs.LogMySqlProc(cmd);

                        con.Open(); //Connection Open

                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd)) // Run query
                        {
                            sda.Fill(dt); // Data table value
                        }

                        //errlog.response = Logs.LogMySqlProc(cmd);

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

            //ErrorLog.LogToDB(errlog);

            res.recordId = obj.recordId;
            res.errorCode = obj.errorCode;
            res.errorFlag = obj.errorFlag;
            res.errorMsg = obj.errorMsg;

            return new Tuple<DataTable, ErrorRes>(dt, res);
        }
    }
}