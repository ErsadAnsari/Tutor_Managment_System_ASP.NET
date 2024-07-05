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
    public partial class Student_Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StudentLoginButton_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(cs);
            string sp = "sp_Student_Login";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UsernameText.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = passwordText.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows==true)
            {
                Session["student_username"] = UsernameText.Text;
                Response.Redirect("student/Student_Index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Opps!','You have entred wrong credentials.','error')", true);
            }
            con.Close();

        }
    }
}