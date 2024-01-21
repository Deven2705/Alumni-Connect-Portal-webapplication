using AlumniConnect.DAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace AlumniConnect.BAL
{
    public class UserDetails
    {
        public static ErrorRes GetRegister(UserMasterModel model)
        {
            ErrorRes res = new ErrorRes();
            Tuple<DataTable, ErrorRes> tuple;
            string base64Img = model.imgUrl;
            string ext = "";

            try { ext = (base64Img.Split(';')[0]).Split('/')[1]; }
            catch { }
            //(model.imgUrl.Split(';')[0]).Split('/')[1]

            model.imgUrl = ext;

            model.dbAction = "INSERT";

            tuple = UserMasterOp.UserMaster(model);

            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    ErrorRes eRes = new ErrorRes();
                    res = tuple.Item2;
                }
            }

            if (res == null)
            {
                res.errorCode = "RES001";
                res.errorFlag = "Y";
                res.errorMsg = "Something went wrong. Please try again";
            }
            else if (res.errorFlag == null)
            {
                res.errorCode = "RES001";
                res.errorFlag = "Y";
                res.errorMsg = "Something went wrong. Please try again";
            }
            else
            {
                //string path = HttpContext.Current.Server.MapPath("~/assets/images/profile/");

                SaveImage(base64Img, res.recordId, ext);
            }

            return res;
        }

        public static bool SaveImage(string ImgStr, string ImgName, string ext)
        {
            try
            {
                string path = Convert.ToString(ConfigurationManager.AppSettings["fileUploadPath"]);//HttpContext.Current.Server.MapPath("~/assets/images/event/"); //Path

                path = path + "/content/images/profile/";//HttpContext.Current.Server.MapPath("~/assets/images/profile/");//

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                string imageName = ImgName + "." + ext;

                if (File.Exists(@"" + imageName))
                {
                    File.Delete(@"" + imageName);
                }

                //set the image path
                string imgPath = Path.Combine(path, imageName);

                if (ext == "jpg" || ext == "jpeg")
                {
                    ImgStr = ImgStr.Replace("data:image/jpeg;base64,", "");
                }
                else if (ext == "png")
                {
                    ImgStr = ImgStr.Replace("data:image/png;base64,", "");
                }

                byte[] imageBytes = Convert.FromBase64String(ImgStr);

                File.WriteAllBytes(imgPath, imageBytes);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Get User List
        public static HeadListRes GetHeadList(FilterReq freq)
        {
            HeadListRes res = new HeadListRes();
            UserMasterModel req = new UserMasterModel();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = freq.dbAction;
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            req.name = freq.name;
            req.passoutYear = freq.batch;
            req.branch = freq.branch;
            req.city = freq.city;
            req.country = freq.country;
            req.bloodGroup = freq.bloodGroup;
            req.recordId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = DAL.UserMasterOp.UserMaster(req);

            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    ErrorRes eRes = new ErrorRes();
                    eRes = tuple.Item2;

                    if (eRes.errorFlag == "N")
                    {
                        if (tuple.Item1 != null)
                        {
                            DataTable dt = new DataTable();

                            dt = tuple.Item1;

                            if (dt.Rows.Count > 0)
                            {
                                List<HeadList> lst = new List<HeadList>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    HeadList hl = new HeadList();
                                    hl.email = Convert.ToString(dt.Rows[i]["Email"]);
                                    //hl.fb = Convert.ToString(dt.Rows[i]["FB"]);
                                    //hl.gmail = Convert.ToString(dt.Rows[i]["Gmail"]);
                                    hl.imgUrl = "../content/images/profile/" + Convert.ToString(dt.Rows[i]["ImgUrl"]);
                                    hl.gender = Convert.ToString(dt.Rows[i]["Gender"]);

                                    if (hl.imgUrl == "")
                                    {
                                        if (hl.gender.ToUpper() == "F")
                                        {
                                            hl.imgUrl = "female.png";
                                        }
                                        else
                                        {
                                            hl.imgUrl = "male.png";
                                        }
                                    }

                                    hl.linkedIn = Convert.ToString(dt.Rows[i]["LinkedIn"]);
                                    hl.location = Convert.ToString(dt.Rows[i]["City"]);
                                    hl.mobile = Convert.ToString(dt.Rows[i]["Mobile"]);
                                    hl.name = Convert.ToString(dt.Rows[i]["Name"]);
                                    hl.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                    hl.companyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                                    hl.admissionYear = Convert.ToString(dt.Rows[i]["AdmissionYear"]);
                                    hl.passoutYear = Convert.ToString(dt.Rows[i]["PassoutYear"]);
                                    hl.branch = Convert.ToString(dt.Rows[i]["Branch"]);
                                    hl.designation = Convert.ToString(dt.Rows[i]["Designation"]);

                                    lst.Add(hl);
                                }

                                res.lstUserList = lst;
                            }
                            else
                            {
                                eRes.errorMsg = "No data found !!!";
                            }
                        }
                        else
                        {
                            eRes.errorMsg = "No data found !!!";
                        }
                    }

                    res.recordId = eRes.recordId;
                    res.errorCode = eRes.errorCode;
                    res.errorFlag = eRes.errorFlag;
                    res.errorMsg = eRes.errorMsg;
                }
            }

            return res;
        }

        public static ErrorRes UpdateProfile(UserMasterModel model)
        {
            ErrorRes eRes = new ErrorRes();
            Tuple<DataTable, ErrorRes> tuple;

            model.dbAction = "UPDATE";
            model.recordId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            model.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = UserMasterOp.UserMaster(model);


            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    eRes = tuple.Item2;

                    if (eRes.errorFlag == "N")
                    {

                    }
                }
                else
                {
                    eRes.errorCode = "RES001";
                    eRes.errorFlag = "Y";
                    eRes.errorMsg = "Something went wrong";
                }
            }
            else
            {
                eRes.errorCode = "RES001";
                eRes.errorFlag = "Y";
                eRes.errorMsg = "Something went wrong";
            }

            return eRes;
        }
        //Get User Data By Record Id
        public static UserMasterModel GetUserDataByRecordId(UserMasterModel model)
        {
            model.dbAction = "GET_USER_BY_RECORD_ID";
            model.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            if (string.IsNullOrEmpty(model.recordId))
            {
                model.recordId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            }

            Tuple<DataTable, ErrorRes> tuple;
            ErrorRes eRes = new ErrorRes();

            tuple = UserMasterOp.UserMaster(model);

            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    eRes = tuple.Item2;

                    if (eRes.errorFlag == "N")
                    {
                        if (tuple.Item1 != null)
                        {
                            DataTable dt = new DataTable();

                            dt = tuple.Item1;

                            if (dt.Rows.Count > 0)
                            {

                                model.name = Convert.ToString(dt.Rows[0]["Name"]);
                                model.mobileNo = Convert.ToString(dt.Rows[0]["Mobile"]);
                                model.emailID = Convert.ToString(dt.Rows[0]["Email"]);
                                try
                                {
                                    model.dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("yyyy-MM-dd");
                                }
                                catch { }
                                model.bloodGroup = Convert.ToString(dt.Rows[0]["BloodGroup"]);
                                model.nickName = Convert.ToString(dt.Rows[0]["NickName"]);
                                model.gender = Convert.ToString(dt.Rows[0]["Gender"]);
                                model.city = Convert.ToString(dt.Rows[0]["City"]);
                                model.nativePlace = Convert.ToString(dt.Rows[0]["NativePlace"]);
                                model.state = Convert.ToString(dt.Rows[0]["State"]);
                                model.country = Convert.ToString(dt.Rows[0]["Country"]);
                                model.branch = Convert.ToString(dt.Rows[0]["Branch"]);
                                model.admissionYear = Convert.ToString(dt.Rows[0]["AdmissionYear"]);
                                model.passoutYear = Convert.ToString(dt.Rows[0]["PassoutYear"]);
                                model.hobbies = Convert.ToString(dt.Rows[0]["Hobbies"]);
                                model.companyName = Convert.ToString(dt.Rows[0]["CompanyName"]);
                                model.designation = Convert.ToString(dt.Rows[0]["Designation"]);
                                model.higherEducation = Convert.ToString(dt.Rows[0]["HigherEducation"]);
                                model.bachelorDegree = Convert.ToString(dt.Rows[0]["BachelorDegree"]);
                                model.specialization = Convert.ToString(dt.Rows[0]["Specialization"]);
                                model.bdayFlag = Convert.ToString(dt.Rows[0]["BdayFlag"]);

                                model.imgUrl = Convert.ToString(dt.Rows[0]["ImgUrl"]);

                                if (model.imgUrl == "")
                                {
                                    if (model.gender.ToUpper() == "M")
                                    {
                                        model.imgUrl = "male.png";
                                    }
                                    else
                                    {
                                        model.imgUrl = "female.png";
                                    }
                                }

                                model.experience = Convert.ToString(dt.Rows[0]["Experience"]);
                                model.about = Convert.ToString(dt.Rows[0]["About"]);

                                model.linkedIn = Convert.ToString(dt.Rows[0]["LinkedIn"]);
                                model.recordId = Convert.ToString(dt.Rows[0]["RecordId"]);

                            }
                        }
                        else
                        {
                            eRes.errorMsg = "No data found !!!";
                        }
                    }
                    else
                    {
                        eRes.errorMsg = "No data found !!!";
                    }
                }
                else
                {
                    eRes.errorCode = "RES001";
                    eRes.errorFlag = "Y";
                    eRes.errorMsg = "Something went wrong";
                }
            }
            else
            {
                eRes.errorCode = "RES001";
                eRes.errorFlag = "Y";
                eRes.errorMsg = "Something went wrong";
            }

            model.recordId = eRes.recordId;
            model.errorCode = eRes.errorCode;
            model.errorFlag = eRes.errorFlag;
            model.errorMsg = eRes.errorMsg;

            return model;
        }
        public static ErrorRes UploadProfilePhoto(UserMasterModel model)
        {
            ErrorRes eRes = new ErrorRes();
            Tuple<DataTable, ErrorRes> tuple;
            string base64Img = model.imgUrl;
            string ext = "";

            try { ext = (base64Img.Split(';')[0]).Split('/')[1]; }
            catch { }

            model.imgUrl = ext;
            model.recordId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            model.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            model.dbAction = "UPDATE_PROFILE_PHOTO";

            bool flag = SaveImage(base64Img, model.recordId, ext);

            if (flag)
            {
                tuple = UserMasterOp.UserMaster(model);


                if (tuple != null)
                {
                    if (tuple.Item2 != null)
                    {
                        eRes = tuple.Item2;

                        if (eRes.errorFlag == "N")
                        {

                        }
                    }
                    else
                    {
                        eRes.errorCode = "RES001";
                        eRes.errorFlag = "Y";
                        eRes.errorMsg = "Something went wrong";
                    }
                }
                else
                {
                    eRes.errorCode = "RES001";
                    eRes.errorFlag = "Y";
                    eRes.errorMsg = "Something went wrong, Please try again.";
                }
            }
            else
            {
                eRes.errorCode = "RES001";
                eRes.errorFlag = "Y";
                eRes.errorMsg = "Something went wrong, Please try again.";
            }
            return eRes;
        }

        public static ErrorRes AuthUnauthUser(UserMasterModel model)
        {
            ErrorRes res = new ErrorRes();
            Tuple<DataTable, ErrorRes> tuple;
            tuple = UserMasterOp.UserMaster(model);


            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    res = tuple.Item2;
                }
            }

            return res;
        }
        public static string GetYYYYMMDDFormat(string date)
        {
            string newDate = string.Empty;

            if (date.Contains("/"))
            {
                newDate = date;//.Substring(0, 10);

                var sDate = newDate.Split('/');

                if (sDate != null)
                {
                    if (sDate.Length > 1)
                    {
                        date = sDate[2] + "-" + sDate[0] + "-" + sDate[1];
                    }
                }
            }
            //else
            //{
            //    newDate = date.Substring(0, 10);

            //    var sDate = newDate.Split('-');

            //    if (sDate != null)
            //    {
            //        if (sDate.Length > 1)
            //        {
            //            date = sDate[2] + "-" + sDate[1] + "-" + sDate[0];
            //        }
            //    }
            //}

            return date;
        }

        //public static bool SaveImage(string ImgStr, string ImgName, string ext)
        //{
        //    try
        //    {
        //        string path = Convert.ToString(ConfigurationManager.AppSettings["fileUploadPath"]);//HttpContext.Current.Server.MapPath("~/assets/images/event/"); //Path

        //        path = path + "/assets/images/profile/";//HttpContext.Current.Server.MapPath("~/assets/images/profile/");//

        //        //Check if directory exist
        //        if (!System.IO.Directory.Exists(path))
        //        {
        //            System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
        //        }

        //        string imageName = ImgName + "." + ext;

        //        if (File.Exists(@"" + imageName))
        //        {
        //            File.Delete(@"" + imageName);
        //        }

        //        //set the image path
        //        string imgPath = Path.Combine(path, imageName);

        //        if (ext == "jpg" || ext == "jpeg")
        //        {
        //            ImgStr = ImgStr.Replace("data:image/jpeg;base64,", "");
        //        }
        //        else if (ext == "png")
        //        {
        //            ImgStr = ImgStr.Replace("data:image/png;base64,", "");
        //        }

        //        byte[] imageBytes = Convert.FromBase64String(ImgStr);

        //        File.WriteAllBytes(imgPath, imageBytes);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}