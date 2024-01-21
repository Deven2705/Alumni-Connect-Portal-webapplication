using AlumniConnect.DAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static AlumniConnect.Model.OpeningModel;

namespace AlumniConnect.BAL
{
    public class Openings
    {
        #region Openings
        public static OpeningListRes GetOpeningList(OpeningModelReq req)
        {
            //OpeningModelReq req = new OpeningModelReq();
            OpeningListRes res = new OpeningListRes();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "SELECT";
            //req.type = "O";
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            
            tuple = OpeningOp.Opening(req);

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
                                List<OpeningModelRes> lst = new List<OpeningModelRes>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    OpeningModelRes om = new OpeningModelRes();

                                    om.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                    om.mobile = Convert.ToString(dt.Rows[i]["Mobile"]);
                                    om.email = Convert.ToString(dt.Rows[i]["Email"]);

                                    if (Convert.ToString(dt.Rows[i]["ResumeLink"]) != "")
                                    {
                                        om.email = Convert.ToString(dt.Rows[i]["ResumeLink"]);
                                    }

                                    om.imgUrl = Convert.ToString(dt.Rows[i]["ImgUrl"]);
                                    om.title = Convert.ToString(dt.Rows[i]["Title"]);
                                    om.description = Convert.ToString(dt.Rows[i]["Description"]);
                                    om.companyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                                    om.createdBy = Convert.ToString(dt.Rows[i]["Name"]);
                                    om.createdOn = Convert.ToString(dt.Rows[i]["CreatedDate"]);

                                    if (om.imgUrl == "")
                                    {
                                        if (Convert.ToString(dt.Rows[i]["Gender"]).ToUpper() == "F")
                                        {
                                            om.imgUrl = "female.png";
                                        }
                                        else
                                        {
                                            om.imgUrl = "male.png";
                                        }
                                    }

                                    lst.Add(om);
                                }

                                res.lstOpenings = lst;
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

        public static ErrorRes AddOpening(OpeningModelReq req)
        {
            ErrorRes res = new ErrorRes();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "INSERT";
            //req.type = "O";
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);//Convert.ToString(HttpContext.Current.Session["EMAIL"]);
            req.recordId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            

            tuple = OpeningOp.Opening(req);

            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    res = tuple.Item2;
                }
                else
                {
                    res.errorCode = "RES001";
                    res.errorFlag = "Y";
                    res.errorMsg = "Something wen wrong. Please try again.";
                }
            }
            else
            {
                res.errorCode = "RES001";
                res.errorFlag = "Y";
                res.errorMsg = "Something wen wrong. Please try again.";
            }

            return res;
        }
        #endregion

        #region Intern Operations
        public static OpeningListRes GetInternList()
        {
            OpeningModelReq req = new OpeningModelReq();
            OpeningListRes res = new OpeningListRes();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "SELECT";
            req.type = "I";
            req.loginId = Convert.ToString(HttpContext.Current.Session["MOBILE"]);

            tuple = OpeningOp.Opening(req);

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
                                List<OpeningModelRes> lst = new List<OpeningModelRes>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    OpeningModelRes om = new OpeningModelRes();

                                    om.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                    om.mobile = Convert.ToString(dt.Rows[i]["Mobile"]);
                                    om.email = Convert.ToString(dt.Rows[i]["Email"]);
                                    om.imgUrl = Convert.ToString(dt.Rows[i]["ImgUrl"]);
                                    om.title = Convert.ToString(dt.Rows[i]["Title"]);
                                    om.description = Convert.ToString(dt.Rows[i]["Description"]);
                                    om.companyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                                    om.createdBy = Convert.ToString(dt.Rows[i]["Name"]);
                                    om.createdOn = Convert.ToString(dt.Rows[i]["CreatedDate"]);

                                    if (om.imgUrl == "")
                                    {
                                        if (Convert.ToString(dt.Rows[i]["Gender"]).ToUpper() == "FEMALE")
                                        {
                                            om.imgUrl = "female.png";
                                        }
                                        else
                                        {
                                            om.imgUrl = "male.png";
                                        }
                                    }

                                    lst.Add(om);
                                }

                                res.lstOpenings = lst;
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

        public static ErrorRes AddIntern()
        {
            OpeningModelReq req = new OpeningModelReq();
            ErrorRes res = new ErrorRes();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "INSERT";
            req.type = "I";
            req.loginId = Convert.ToString(HttpContext.Current.Session["MOBILE"]);

            tuple = OpeningOp.Opening(req);

            if (tuple != null)
            {
                if (tuple.Item2 != null)
                {
                    res = tuple.Item2;
                }
                else
                {
                    res.errorCode = "RES001";
                    res.errorFlag = "Y";
                    res.errorMsg = "Something wen wrong. Please try again.";
                }
            }
            else
            {
                res.errorCode = "RES001";
                res.errorFlag = "Y";
                res.errorMsg = "Something wen wrong. Please try again.";
            }

            return res;
        }
        #endregion
    }
}