using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class librarian_pwd_reset : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();

        if (Session["librarian"] == null)
        {
            Response.Redirect("login.aspx");
        }


        if (IsPostBack) return;


        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string qstring = "update Student_registration set password='Student123' where username =@username and firstname=@student_name";
        SqlCommand cmd = new SqlCommand(qstring, con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@username", student_username.Text);
        cmd.Parameters.AddWithValue("@student_name", student_name.Text);
        cmd.ExecuteNonQuery();
    }

    protected void student_username_TextChanged(object sender, EventArgs e)
    {

    }
}