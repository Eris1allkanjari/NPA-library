using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class librarian_add_books : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();


        if(Session["librarian"]==null)
        {
            Response.Redirect("login.aspx");
        }

    }

    protected void b1_Click(object sender, EventArgs e)
    {


        string books_image_name = Class1.GetRandomPassword(10) + ".jpg";


        string path = "";

        f1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + books_image_name.ToString());
        path = "books_images/" + books_image_name.ToString();


        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into books values('"+ bookstitle.Text +"','"+ path.ToString() +"','"+ authorname.Text +"','"+ isbn.Text+"','"+ qty.Text +"')";
        cmd.ExecuteNonQuery();

        msg.Style.Add("display", "block");
    }
}