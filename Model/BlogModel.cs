using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class BlogModel : ErrorRes
    {
        public string dbAction { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string active { get; set; }
        public string loginId { get; set; }
        public string authzList { get; set; }
    }

    public class BlogListModel
    {
        public string recordId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imgUrl { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string createdById { get; set; }
        public string likeCount { get; set; }
        public string commentCount { get; set; }
        public string likeStatus { get; set; }
        //public List<LikeUserList> likeUserList { get; set; }
        //public List<CommentsModel> lstComments { get; set; }
    }

    public class BlogList : ErrorRes
    {
        public List<BlogListModel> lstBlogs { get; set; }

    }
}