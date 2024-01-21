using AlumniConnect.DAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AlumniConnect.BAL
{
    public class Broadcast
    {
        public static BroadcastResList GetBroadCasts()
        {
            BroadcastModel req = new BroadcastModel();
            BroadcastResList res = new BroadcastResList();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "SELECT";
            //req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = BroadcastOp.BroadcastExec(req);

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
                                List<BroadcastModel> lst = new List<BroadcastModel>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    BroadcastModel em = new BroadcastModel();

                                    em.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                    em.broadcastMsg = Convert.ToString(dt.Rows[i]["BroadcastMsg"]);
                                    //em. = Convert.ToString(dt.Rows[i]["Title"]);

                                    lst.Add(em);
                                }

                                res.lst = lst;
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
        public static BroadcastResList GetAllBroadCasts()
        {
            BroadcastModel req = new BroadcastModel();
            BroadcastResList res = new BroadcastResList();
            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "SELECT_ALL";
            //req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = BroadcastOp.BroadcastExec(req);

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
                                List<BroadcastModel> lst = new List<BroadcastModel>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    BroadcastModel em = new BroadcastModel();

                                    em.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                    em.broadcastMsg = Convert.ToString(dt.Rows[i]["BroadcastMsg"]);
                                    em.status = Convert.ToString(dt.Rows[i]["Status"]);
                                    em.expiryDate = Convert.ToString(dt.Rows[i]["ExpiryDate"]);
                                    em.createdBy = Convert.ToString(dt.Rows[i]["Name"]);

                                    lst.Add(em);
                                }

                                res.lst = lst;
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
        public static ErrorRes AddBroadcast(BroadcastModel req)
        {
            ErrorRes res = new ErrorRes();

            Tuple<DataTable, ErrorRes> tuple;
            
            req.dbAction = "INSERT";
            req.status = "Y";
            req.createdBy = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = BroadcastOp.BroadcastExec(req);

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
                        
                    }
                }
            }

            return res;
        }

        public static ErrorRes UpdateBroadcast(BroadcastModel req)
        {
            ErrorRes res = new ErrorRes();

            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "UPDATE";
            //req.status = "Y";
            req.createdBy = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = BroadcastOp.BroadcastExec(req);

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

                    }
                }
            }

            return res;
        }
    }
}