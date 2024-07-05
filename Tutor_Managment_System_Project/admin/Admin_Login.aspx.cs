using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tutor_Managment_System_Project.admin
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void AdminLoginResetForm()
        {
            UsernameText.Text = "";
            passwordText.Text = "";
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from admin_login where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", UsernameText.Text);
            cmd.Parameters.AddWithValue("@password", passwordText.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.HasRows==true)
            {
                Response.Write("<script>alert('success')</script>");
                Session["admin_username"] = UsernameText.Text;
                Response.Redirect("Admin_Index.aspx");
            }
            else
            {
                //Response.Write("<script>alert('fail')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Opps!','You have entred wrong credentials.','error')", true);
                AdminLoginResetForm();
            }
            con.Close();

        }
    }
}