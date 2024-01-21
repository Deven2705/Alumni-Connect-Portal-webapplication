using AlumniConnect.BAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserMasterModel umm = new UserMasterModel();

                if (Request.QueryString["RecordId"] != null)
                {

                    umm.recordId = Convert.ToString(Request.QueryString["RecordId"]);

                    umm = UserDetails.GetUserDataByRecordId(umm);
                }
                else
                {
                    umm.recordId = Convert.ToString(Session["RECORD_ID"]);

                    umm = UserDetails.GetUserDataByRecordId(umm);
                }

                if(umm != null)
                {
                    if(umm.errorFlag == "N")
                    {
                        imgProfile.Src = "../content/images/profile/" + umm.imgUrl;
                        lblName.Text = umm.name;
                        lblDesignation.Text = umm.designation;
                        lblCompany.Text = umm.companyName;
                        lbladmissionYear.Text = Convert.ToString(umm.admissionYear) + "-" +Convert.ToString(umm.passoutYear)  + ", " + Convert.ToString(umm.branch) ;
                        lblLocation.Text = umm.city;
                        lblMobileNo.Text = umm.mobileNo;
                        lblEmail.Text = umm.emailID;
                        lblBDay.Text = umm.dob;
                        lblHobbies.Text = umm.hobbies;
                        lblBranch.Text = umm.branch;
                        lblBloodGroup.Text = umm.bloodGroup;
                        lblExperience.Text = umm.experience;
                        lblEducation.Text = umm.higherEducation;
                        lblAbout.Text = umm.about;

                    }
                    else
                    {
                        Response.Redirect("Login.aspx?mode=sww");
                        lblMsg.Text = "Something went wrong";
                        lblMsg.ForeColor = Color.Red;
                    }
                }    
            }
        }
    }
}