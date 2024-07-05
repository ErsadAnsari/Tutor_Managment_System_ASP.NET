using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tutor_Managment_System_Project
{
    public partial class Student_Signup : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                BindStateDDL();
            }


        }
        void BindStateDDL()
        {
            SqlConnection con = new SqlConnection(cs);
            string sp = "sp_Student_Reg_State_All";
            SqlDataAdapter da = new SqlDataAdapter(sp, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            StateDropDownList.DataSource = dt;
            //StateDropDownList.DataBind();
            StateDropDownList.DataTextField = "state";
            StateDropDownList.DataValueField = "state_id";
            StateDropDownList.DataBind();
            //StateDropDownList.Items.Insert(0, "Select State");
            ListItem selectedstate = new ListItem("Select State", "Select State");
            selectedstate.Selected = true;
            StateDropDownList.Items.Insert(0, selectedstate);
        }
        void BindDistrictDDL(int state_id)
        {
            SqlConnection con = new SqlConnection(cs);
            string sp = "sp_Student_Districts_All";
            SqlDataAdapter sda = new SqlDataAdapter(sp, con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@state_id", SqlDbType.Int).Value = state_id;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CityDropDownList.DataSource = dt;
            CityDropDownList.DataTextField = "city";
            CityDropDownList.DataValueField = "city_id";
            CityDropDownList.DataBind();
            ListItem selecteditem = new ListItem("Select District", "Select District");
            selecteditem.Selected = true;
            CityDropDownList.Items.Insert(0, selecteditem);
        }
        void StudentFormReset()
        {
            NameTextBox.Text = "";
            FatherNameTextBox.Text = "";
            SurnameTextBox.Text = "";
            GenderDropDownList.SelectedValue = null;
            AgeTextBox.Text = "";
            StateDropDownList.SelectedValue = null;
            CityDropDownList.SelectedValue = null;
            AddressTextBox.Text = "";
            ClassTextBox.Text = "";
            GoingToDropDownList.SelectedValue = null;
            SubjectTextBox.Text = "";
            ContactTextBox.Text = "";
            TuitionTypeDropDownList.SelectedValue = null;
            TutorPreferDropDownList.SelectedValue = null;
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        protected void StudentSignUpButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            try
            {
                string sp = "sp_Student_Signup_Insert";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = NameTextBox.Text;
                cmd.Parameters.Add("@father_name", SqlDbType.VarChar).Value = FatherNameTextBox.Text;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = SurnameTextBox.Text;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = GenderDropDownList.SelectedValue.ToString();
                cmd.Parameters.Add("age", SqlDbType.Int).Value = AgeTextBox.Text;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = StateDropDownList.SelectedItem.ToString();
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = CityDropDownList.SelectedItem.ToString();
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = AddressTextBox.Text;
                cmd.Parameters.Add("@standard", SqlDbType.VarChar).Value = ClassTextBox.Text;
                cmd.Parameters.Add("goingto", SqlDbType.VarChar).Value = GoingToDropDownList.SelectedValue.ToString();
                cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = SubjectTextBox.Text;
                cmd.Parameters.Add("@contactno", SqlDbType.VarChar).Value = ContactTextBox.Text;
                cmd.Parameters.Add("@tutiontype", SqlDbType.VarChar).Value = TuitionTypeDropDownList.SelectedValue.ToString();
                cmd.Parameters.Add("@tutorprefer", SqlDbType.VarChar).Value = TutorPreferDropDownList.SelectedValue.ToString();
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UsernameTextBox.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = PasswordTextBox.Text;
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success!','Registration Successful','success')", true);
                    StudentFormReset();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Opps!','Registration Unsuccessful','error')", true);
                }
            }
            catch(SqlException ex)
            {
                if(ex.Message.Contains("UNIQUE KEY constraint"))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failed!','Registration Failed "+ UsernameTextBox.Text+" is already taken.','error')", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failed!','Registration Unsuccessful','error')", true);
                }
            }
            finally
            {
                con.Close();
            }
           

        }


        protected void StateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
            {
                int state_id = Convert.ToInt32(StateDropDownList.SelectedValue);
                BindDistrictDDL(state_id);

            }
            catch( Exception ex)
            {
                //Response.Write("<script>alert('Select state')</script>");
            }
            //con.Open();

            //SqlDataReader dr = cmd.ExecuteReader();
            //CityDropDownList.DataSource = dr;
            //CityDropDownList.Items.Clear();
            //CityDropDownList.Items.Insert(0, "Select City");
            //CityDropDownList.DataValueField ="city";
            //CityDropDownList.DataBind();
            //con.Close();
        }

        protected void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_Username_Check", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UsernameTextBox.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(dt);
            if(dt.Rows.Count>0)
            {
                lblusernameError.Text = "Username is already exist!";
            }
            else
            {
                lblusernameError.Text = "";
            }
            
        }
    }
}