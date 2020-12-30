using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class student_student_registration : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();

    }

    protected void b1_Click(object sender, EventArgs e)
    {

        int count = 0;
        int count2 = 0;


        SqlCommand cmd1 = con.CreateCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "select * from student_registration where enrollment_no='" + enrollmentno.Text + "'";
        cmd1.ExecuteNonQuery();
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        da1.Fill(dt1);
        count = Convert.ToInt32(dt1.Rows.Count.ToString());

        if (count > 0)
        {
            Response.Write("<script>alert('this enrollment no already registered');</script>");
        }
        else
        {

            //this is for checking username unique

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from student_registration where username='" + username.Text + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            count2 = Convert.ToInt32(dt2.Rows.Count.ToString());
            // end here for checking username unique
            if (count2 > 0)
            {
                Response.Write("<script>alert('this username already available please choose another');</script>");
            }
            else
            {
                string pw = password.Text;
                byte[] pass = Encoding.ASCII.GetBytes(pw);
                byte[] presult;

                SHA1 sha = new SHA1CryptoServiceProvider();
                // This is one implementation of the abstract class SHA1.
                presult = sha.ComputeHash(pass);
                string hpw = Encoding.ASCII.GetString(presult);

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@hpw", hpw);
                cmd.CommandText = "insert into student_registration values('" + firstname.Text + "','" + lastname.Text + "','" + enrollmentno.Text + "','" + username.Text + "','" + @hpw + "','" + email.Text + "','" + contact.Text + "','no')";
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('record inserted successfully'); window.location='student_login.aspx';</script>");
            }
        }

    }
}