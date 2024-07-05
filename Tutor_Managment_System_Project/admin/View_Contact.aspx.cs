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
    public partial class View_Contact : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string sp = "sp_View_Contact";
            SqlDataAdapter sda = new SqlDataAdapter(sp, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ContactGridView.DataSource = dt;
            ContactGridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_username"] == null)
            {
                Response.Redirect("Admin_Login.aspx");
            }
            if (!IsPostBack)
            {
                BindGridView();
            }

        }

        protected void ContactGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = ContactGridView.Rows[e.RowIndex];
            Label ItemId = (Label)row.FindControl("LabelID");
            string id = ItemId.Text;
            SqlConnection con = new SqlConnection(cs);
            string sp = "sp_Contact_Delete";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Record has been deleted.','success')", true);
                BindGridView();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Opps!','Technical Error','error')", true);
            }

        }
    }
}