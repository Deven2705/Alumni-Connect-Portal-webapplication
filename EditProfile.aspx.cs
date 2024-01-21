using AlumniConnect.BAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ErrorRes res = new ErrorRes();

            string Name = txtName.Text;
            string DOB = txtDOB.Text;
            string Gender = rblGender.SelectedValue;
            string NickName = txtNickName.Text;
            string BloodGroup = ddlBloodGroup.SelectedValue;
            string City = txtCity.Text;
            string NativePlace = txtNativePlace.Text;
            string State = txtState.Text;
            string Country = txtCountry.Text;
            string Branch = ddlBranch.SelectedValue;
            string AdmissionYear = ddlAdmissionYear.SelectedValue;
            string PassoutYear = ddlPassoutYear.SelectedValue;
            string Hobbies = txtHobbies.Text;
            string CompanyName = txtCompanyName.Text;
            string Designation = txtDesignation.Text;
            string HigherEducation = txtHigherEducation.Text;
            //string Bachelordegree = ddlBachelordegree.SelectedValue;
            string Specialization = txtSpecialization.Text;
            string MobileNo = txtMobileNo.Text;
            string Experiance = txtExperiance.Text;
            string About = txtAbout.Text;
            string LinkedIn = txtLinkedIn.Text;
            string BDayFlag = ddlBDayFlag.SelectedValue;


            UserMasterModel umm = new UserMasterModel();

            umm.about = About;
            umm.admissionYear = AdmissionYear;
            umm.bachelorDegree = Branch;
            umm.bdayFlag = BDayFlag;
            umm.bloodGroup = BloodGroup;
            umm.branch = Branch;
            umm.city = City;
            umm.companyName = CompanyName;
            umm.country = Country;
            umm.mobileNo = MobileNo;
            umm.designation = Designation;
            umm.dob = null;//DOB;
            umm.experience = Experiance;
            umm.gender = Gender;
            umm.higherEducation = HigherEducation;
            umm.hobbies = Hobbies;
            umm.linkedIn = LinkedIn;
            umm.name = Name;
            umm.nativePlace = NativePlace;
            umm.nickName = NickName;
            umm.passoutYear = PassoutYear;
            umm.specialization = Specialization;
            umm.state = State;

            res = UserDetails.UpdateProfile(umm);

            //if (Name == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}

            //else if (DOB == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Gender == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (NickName == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (BloodGroup == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (City == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (NativePlace == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (State == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Country == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Branch == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (AdmissionYear == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (PassoutYear == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Hobbies == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (CompanyName == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Designation == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (HigherEducation == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Specialization == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (Experiance == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (About == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (LinkedIn == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else if (BDayFlag == "")
            //{
            //    lblMsg.Text = "Invalid Register Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
            //else
            //{
            //    //lblMsg.Text = res.errorMsg;
            //    lblMsg.Text = "Succesfully Resister";
            //    lblMsg.ForeColor = Color.Green;
            //}

            if (res.errorFlag == "N")
            {
                lblMsg.Text = "Profile updated successfully";
                lblMsg.ForeColor = Color.Green;
            }
            else
            {
                lblMsg.Text = res.errorCode + " : " + res.errorMsg;
                lblMsg.ForeColor = Color.Red;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuUserPhoto.HasFile)
            {
                System.IO.Stream fs = fuUserPhoto.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                string fileName = fuUserPhoto.FileName;

                var sFileName = fileName.Split('.');

                string base64String = "";

                if (sFileName[1] == "jpg" || sFileName[1] == "jpeg")
                {
                    base64String = "data:image/jpeg;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
                }
                else if (sFileName[1] == "png")
                {
                    base64String = "data:image/png;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
                }
                //else if(sFileName[1]=="JPG")
                //{
                //    base64String = "data:image/jpg;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
                //}

                UserMasterModel umm = new UserMasterModel();
                umm.imgUrl = base64String;
                umm.recordId = Convert.ToString(Session["RECORD_ID"]);

                UserDetails.UploadProfilePhoto(umm);

                //UserDetails.SaveImage(base64String, Convert.ToString(Session["RECORD_ID"]), Convert.ToString(sFileName[1]));
                if (umm.errorFlag == "N")
                {
                    lblMsg.Text = "Profile photo uploaded successfully";
                    lblMsg.ForeColor = Color.Green;
                    imgProfilePhoto.Src = "../content/images/profile/" + umm.recordId + "." + Convert.ToString(sFileName[1]);
                }
                else
                {
                    lblMsg.Text = umm.errorMsg;
                    lblMsg.ForeColor = Color.Green;
                }
            }
            else
            {
                lblMsg.Text = "Please select photo to change profile";
                lblMsg.ForeColor = Color.Red;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RECORD_ID"] != null)
            {
                if (!IsPostBack)
                {
                    UserMasterModel umm = new UserMasterModel();

                    umm = UserDetails.GetUserDataByRecordId(umm);

                    if (umm.errorFlag == "N")
                    {
                        txtAbout.Text = umm.about;
                        ddlAdmissionYear.SelectedValue = umm.admissionYear;
                        ddlBranch.SelectedValue = umm.branch;
                        ddlBDayFlag.SelectedValue = umm.bdayFlag;
                        ddlBloodGroup.SelectedValue = umm.bloodGroup;
                        //ddlBranch.SelectedValue = umm.branch;
                        txtCity.Text = umm.city;
                        txtCompanyName.Text = umm.companyName;
                        txtCountry.Text = umm.country;
                        txtDesignation.Text = umm.designation;
                        txtDOB.Text = umm.dob;
                        txtExperiance.Text = umm.experience;
                        rblGender.SelectedValue = umm.gender;   //added
                        txtHigherEducation.Text = umm.higherEducation;
                        txtHobbies.Text = umm.hobbies;
                        txtLinkedIn.Text = umm.linkedIn;
                        txtMobileNo.Text = umm.mobileNo;
                        txtName.Text = umm.name;
                        txtNativePlace.Text = umm.nativePlace;
                        txtNickName.Text = umm.nickName;
                        ddlPassoutYear.SelectedValue = umm.passoutYear;
                        txtSpecialization.Text = umm.specialization;
                        txtState.Text = umm.state;
                        imgProfilePhoto.Src = "../content/images/profile/" + umm.imgUrl;

                    }
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}
