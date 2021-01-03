using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class student_student : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
    //int count = 0;

   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();

        if (notification1.Text.Equals("")) {
            notification1.Text = "0";
        }

        String username = Session["perdorues"].ToString();

        SqlCommand shoppingCartCmd = con.CreateCommand();
        shoppingCartCmd.CommandType = CommandType.Text;
        shoppingCartCmd.CommandText = "select * from issue_books where student_username='" + username + "'";
        shoppingCartCmd.ExecuteNonQuery();
        DataTable dataTable = new DataTable();
        SqlDataAdapter ddataAdapter = new SqlDataAdapter(shoppingCartCmd);
        ddataAdapter.Fill(dataTable);
        ShoppingCartNumber = dataTable.Rows.Count.ToString();

    }

    public void redirectCheckout(object sender, EventArgs e){
        Response.Redirect("Checkout.aspx");

    }

    /*public string gettwentycharacters(object myvalues)
    {

        string a;
        a = Convert.ToString(myvalues.ToString());
        string b = "";

        if (a.Length >= 15)
        {
            b = a.Substring(0, 15);
            return b.ToString() + "..";
        }
        else
        {
            b = a.ToString();
            return b.ToString();

        }


    }*/

    public string ShoppingCartNumber {
        get {
            return notification1.Text;
        }
        set {
            notification1.Text = value;
        }
    }


}
