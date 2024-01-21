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
    public class Events
    {
        public static EventListRes GetEvents()
        {
            EventModelReq req = new EventModelReq();
            EventListRes res = new EventListRes();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "SELECT";
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = EventsOp.EventExec(req);

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
                                List<EventModel> lst = new List<EventModel>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    EventModel em = new EventModel();

                                    em.imgUrl = Convert.ToString(dt.Rows[i]["ImgUrl"]);
                                    em.description = Convert.ToString(dt.Rows[i]["EventDetail"]);
                                    em.title = Convert.ToString(dt.Rows[i]["Title"]);

                                    lst.Add(em);
                                }

                                res.lstEvents = lst;
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

        public static ErrorRes AddEvent(EventModelReq req)
        {
            ErrorRes res = new ErrorRes();

            Tuple<DataTable, ErrorRes> tuple;
            string base64Img = req.imgUrl;
            string ext = "";

            try { ext = (base64Img.Split(';')[0]).Split('/')[1]; }
            catch { }
            //(model.imgUrl.Split(';')[0]).Split('/')[1]

            req.imgUrl = ext;

            req.dbAction = "INSERT";
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = EventsOp.EventExec(req);

            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    res = tuple.Item2;

                    if (res == null)
                    {
                        res.errorCode = "RES001";
                        res.errorFlag = "Y";
                        res.errorMsg = "Something wen wrong. Please try again.";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(base64Img))
                        {
                            SaveEventImage(base64Img, res.recordId, ext);
                        }
                    }
                }
            }

            return res;
        }

        public static bool SaveEventImage(string ImgStr, string ImgName, string ext)
        {
            ErrorLogModel errlog = new ErrorLogModel();

            try
            {
                errlog.dbActionMode = "INSERT";
                errlog.apiName = "SaveEventImage";
                errlog.appName = "SaveEventImage";
                errlog.errorDesc = "Image Upload";
                errlog.logType = "A";
                errlog.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
                errlog.request = ImgStr;

                string path = Convert.ToString(ConfigurationManager.AppSettings["fileUploadPath"]);//HttpContext.Current.Server.MapPath("~/assets/images/event/"); //Path

                path = path +  "\\content\\images\\event\\";//HttpContext.Current.Server.MapPath("~/assets/images/event/");//

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                string imageName = "Event"  + ImgName +  "." +  ext;

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

                errlog.response = Convert.ToString("Success");

                ErrorLog.LogToDB(errlog);

                return true;
            }
            catch (Exception ex)
            {
                errlog.logType = "E";
                errlog.response = Convert.ToString(ex.Message);

                ErrorLog.LogToDB(errlog);

                return false;
            }
        }
    }
}