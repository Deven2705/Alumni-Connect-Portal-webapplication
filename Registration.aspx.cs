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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        { 
            string Firstname = txtName.Text;
            //string Lastname = txtLastname.Text;
            string EMail = txtEmail.Text;
            string MobileNumber = txtMobNo.Text;
            string password = txtPassword.Text;
            string ConfoPassword = txtConfoPassword.Text;


            if (Firstname == "")
            {
                lblMsg.Text = "Invalid Register Credentials";
                lblMsg.ForeColor = Color.Red;
            }
            //else if(Lastname=="")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            else if (EMail == "")
            {
                lblMsg.Text = "Invalid Register Credentials";
                lblMsg.ForeColor = Color.Red;
            }
            else if (MobileNumber == "")
            {
                lblMsg.Text = "Invalid Register Credentials";
                lblMsg.ForeColor = Color.Red;
            }
            else if(!fuUserPhoto.HasFile)
            {
                lblMsg.Text = "Invalid Profile picture";
                lblMsg.ForeColor = Color.Red;
            }
            else if (password == "")
            {
                lblMsg.Text = "Invalid Register Credentials";
                lblMsg.ForeColor = Color.Red;
            }
            else if (ConfoPassword == "")
            {
                lblMsg.Text = "Invalid Register Credentials";
                lblMsg.ForeColor = Color.Red;
            }
            else if (password != ConfoPassword)
            {
                lblMsg.Text = " Incorrect Password!! Please make sure both password match";
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                UserMasterModel umm = new UserMasterModel();

                umm.admissionYear = ddlAdmissionYear.SelectedValue;                
                umm.bdayFlag = "N";
                umm.branch = ddlBranch.SelectedValue;
                umm.dob = txtDOB.Text;
                umm.emailID = txtEmail.Text;
                // code for image saveing
                System.IO.Stream fs = fuUserPhoto.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);

                umm.imgUrl = base64String;

                umm.gender = rblGender.SelectedValue;
                umm.loginId = txtEmail.Text;
                umm.mobileNo = txtMobNo.Text;
                umm.name = txtName.Text;
                umm.passoutYear = ddlPassoutYear.SelectedValue;
                umm.password = txtPassword.Text;
                umm.country = "India";
                umm.state = "Maharashtra";

                ErrorRes res = UserDetails.GetRegister(umm);

                if (res.errorFlag == "N")
                {

                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Green;

                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtMobNo.Text = "";
                    rblGender.SelectedValue = "";
                    ddlBranch.SelectedValue = "";
                    ddlAdmissionYear.SelectedValue = "";
                    ddlPassoutYear.SelectedValue = "";

                }
                else
                {
                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Red;
                }
            }



            //if (Firstname = "Deven" && Lastname == "khade" && EMail == "Devenrkhade@gmail.com" && MobileNumber == "7066897701" && password == "Deven@123")
            //{
            //    lblMsg.Text = "Succesfully Register";
            //    lblMsg.ForeColor = Color.Green;
            //}
            //else
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}

            //if(Page.IsValid)
            //{
            //    lblMsg.Text = "Data saved";
            //}
            //else
            //{
            //    lblMsg.Text = "Data not saved";
            //}

        }
    }
}