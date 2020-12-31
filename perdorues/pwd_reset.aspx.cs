using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

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

        if (Session["student"] == null)
        {
            Response.Redirect("login.aspx");
        }


        if (IsPostBack) return;


        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string pw = new_password.Text;
        byte[] pass = Encoding.ASCII.GetBytes(pw);
        byte[] presult;

        SHA1 sha = new SHA1CryptoServiceProvider();
        // This is one implementation of the abstract class SHA1.
        presult = sha.ComputeHash(pass);
        string hpw = Encoding.ASCII.GetString(presult);

        //SqlCommand cmd = con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        string usrname = Session["student"].ToString();
        string qstring = "update Student_registration set password=@new_password where username =@username";
        SqlCommand cmd = new SqlCommand(qstring, con);
        cmd.Parameters.AddWithValue("@username", usrname);
        cmd.Parameters.AddWithValue("@new_password", hpw);
        cmd.ExecuteNonQuery();
        Session.Clear();
        Response.Redirect("student_login.aspx");
    }

    protected void student_username_TextChanged(object sender, EventArgs e)
    {

    }
}