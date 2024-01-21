using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AlumniConnect.BAL
{
    public class Blogs
    {
        public static BlogList GetBlogList(BlogModel req)
        {
            BlogList res = new BlogList();

            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "SELECT";
            //req.loginId = Convert.ToString(HttpContext.Current.Session["MOBILE"]);
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
            req.recordId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = DAL.BlogsOp.Blogs(req);

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
                                List<BlogListModel> lst = new List<BlogListModel>();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    BlogListModel bm = new BlogListModel();
                                    bm.title = Convert.ToString(dt.Rows[i]["Title"]);
                                    bm.description = Convert.ToString(dt.Rows[i]["Description"]);
                                    bm.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                    bm.imgUrl = Convert.ToString(dt.Rows[i]["ImgUrl"]);
                                    bm.createdOn = Convert.ToString(dt.Rows[i]["CreatedDate"]);
                                    bm.createdBy = Convert.ToString(dt.Rows[i]["Name"]);
                                    bm.createdById = Convert.ToString(dt.Rows[i]["CreatedById"]);
                                    //bm.likeCount = Convert.ToString(dt.Rows[i]["LikeCount"]);
                                    //bm.commentCount = Convert.ToString(dt.Rows[i]["CommentCount"]);
                                    //bm.likeStatus = Convert.ToString(dt.Rows[i]["LikeStatus"]);

                                    if (bm.imgUrl == "")
                                    {
                                        if (Convert.ToString(dt.Rows[i]["Gender"]) == "F")
                                        {
                                            bm.imgUrl = "female.png";
                                        }
                                        else
                                        {
                                            bm.imgUrl = "male.png";
                                        }
                                    }

                                    #region List Liked User List
                                    //if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["LikeUserList"])))
                                    //{
                                    //    List<LikeUserList> lstLike = new List<LikeUserList>();

                                    //    var spltLikes = Convert.ToString(dt.Rows[i]["LikeUserList"]).Split(',');

                                    //    if (spltLikes.Length > 0)
                                    //    {
                                    //        for (int l = 0; l < spltLikes.Length; l)
                                    //        {
                                    //            LikeUserList like = new LikeUserList();

                                    //            var spltUser = Convert.ToString(spltLikes[l]).Split('~');
                                    //            like.recordId = spltUser[1].ToString();
                                    //            like.name = spltUser[0].ToString();

                                    //            lstLike.Add(like);
                                    //        }
                                    //    }

                                    //    bm.likeUserList = lstLike;
                                    //}
                                    #endregion List Liked User List


                                    lst.Add(bm);
                                }

                                res.lstBlogs = lst;
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

        public static ErrorRes AddBlog(BlogModel req)
        {
            ErrorRes res = new ErrorRes();

            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "INSERT";
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            tuple = DAL.BlogsOp.Blogs(req);

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
                    res.errorMsg = "Something went wrong. Please try again";
                }
            }
            else
            {
                res.errorCode = "RES001";
                res.errorFlag = "Y";
                res.errorMsg = "Something went wrong. Please try again";
            }

            return res;

        }

        public static BlogList GetBlogByRecordId(BlogModel req)
        {
            BlogList res = new BlogList();

            Tuple<DataTable, ErrorRes> tuple;

            req.dbAction = "GET_BLOG_BY_RECORD_ID";
            req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);

            try
            {

                tuple = DAL.BlogsOp.Blogs(req);

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
                                    List<BlogListModel> lst = new List<BlogListModel>();

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        BlogListModel bm = new BlogListModel();
                                        bm.title = Convert.ToString(dt.Rows[i]["Title"]);
                                        bm.description = Convert.ToString(dt.Rows[i]["Description"]);
                                        bm.recordId = Convert.ToString(dt.Rows[i]["RecordId"]);
                                        bm.imgUrl = Convert.ToString(dt.Rows[i]["ImgUrl"]);
                                        bm.createdOn = Convert.ToString(dt.Rows[i]["CreatedDate"]);
                                        bm.createdById = Convert.ToString(dt.Rows[i]["CreatedById"]);
                                        bm.createdBy = Convert.ToString(dt.Rows[i]["Name"]);
                                        //bm.likeCount = Convert.ToString(dt.Rows[i]["LikeCount"]);
                                        //bm.commentCount = Convert.ToString(dt.Rows[i]["CommentCount"]);
                                        //bm.likeStatus = Convert.ToString(dt.Rows[i]["LikeStatus"]);

                                        if (bm.imgUrl == "")
                                        {
                                            if (Convert.ToString(dt.Rows[i]["Gender"]) == "F")
                                            {
                                                bm.imgUrl = "female.png";
                                            }
                                            else
                                            {
                                                bm.imgUrl = "male.png";
                                            }
                                        }


                                        //try
                                        //{
                                        //    LikeCommentsModel lcm = new LikeCommentsModel();
                                        //    lcm.refRecordId = bm.recordId;
                                        //    lcm.type = "BLOG";


                                        //    bm.lstComments = LikeComments.GetCommentsByRecordId(lcm).lstComments;


                                        //}
                                        //catch (Exception ex)
                                        //{
                                        //    res.errorCode = "ERR001";
                                        //    res.errorFlag = "Y";
                                        //    res.errorMsg = ex.Message.ToString()   Convert.ToString(dt.Rows.Count);
                                        //    //return res;
                                        //}
                                        #region List Liked User List
                                        //if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["LikeUserList"])))
                                        //{
                                        //    List<LikeUserList> lstLike = new List<LikeUserList>();

                                        //    var spltLikes = Convert.ToString(dt.Rows[i]["LikeUserList"]).Split(',');

                                        //    if (spltLikes.Length > 0)
                                        //    {
                                        //        for (int l = 0; l < spltLikes.Length; l)
                                        //        {
                                        //            LikeUserList like = new LikeUserList();

                                        //            var spltUser = Convert.ToString(spltLikes[l]).Split('~');
                                        //            like.recordId = spltUser[1].ToString();
                                        //            like.name = spltUser[0].ToString();

                                        //            lstLike.Add(like);
                                        //        }
                                        //    }

                                        //    bm.likeUserList = lstLike;
                                        //}
                                        #endregion List Liked User List

                                        lst.Add(bm);
                                    }

                                    res.lstBlogs = lst;

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

            }
            catch (Exception ex)
            {
                res.errorCode = "ERR001";
                res.errorFlag = "Y";
                res.errorMsg = ex.Message.ToString();
            }

            return res;

        }
    }
}