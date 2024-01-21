using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AlumniConnect.Model.OpeningModel;

namespace AlumniConnect
{
    public partial class Event : System.Web.UI.Page
    {

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EventModelReq req = new EventModelReq();
            ErrorRes res = new ErrorRes();

            req.title = txtTitle.Text;
            req.description = txtDescription.Text;
            


            // code for image saveing
            System.IO.Stream fs = fuEventBanner.PostedFile.InputStream;//EventPhoto.PostedFile.InputStream;

            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);

            req.imgUrl = base64String;// *************************************************************************************************** imgurl not in opening model

            //    res = BAL.Openings.AddOpening(req);

            if (string.IsNullOrEmpty(Convert.ToString(req.description).Trim()))
            {
                lblMsg.Text = "Invalid description";
                lblMsg.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(Convert.ToString(req.title).Trim()))
            {
                lblMsg.Text = "Invalid Title";
                lblMsg.ForeColor = Color.Red;
            }

            else
            {

                res = BAL.Events.AddEvent(req);
                if (res.errorFlag == "N")
                {

                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Green;
                    //after sending values ,page should be reset
                    txtTitle.Text = "";
                    txtDescription.Text = "";

                }
                else
                {
                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Red;
                }
            }


        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
