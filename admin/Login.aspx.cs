using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication1.librarian
{
    public partial class login : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int i=0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string pw = password.Text;
            byte[] pass = Encoding.ASCII.GetBytes(pw);
            byte[] presult;
            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            presult = sha.ComputeHash(pass);
            string hpw = Encoding.ASCII.GetString(presult);
            cmd.Parameters.AddWithValue("@hpw", hpw);
            cmd.CommandText = "select * from librarian_registration where username='"+ username.Text +"' and password='"+ hpw +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if(i>0)
            {
                Session["admin"] = username.Text;
                Response.Redirect("GjitheLibrat.aspx");
            }
            else
            {
                error.Style.Add("display","block");
            }



        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../perdorues/Login.aspx");
        }
    }
}