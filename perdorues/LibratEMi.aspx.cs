using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class student_my_issued_books : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");

    string penalty = "0";
    double noofdays = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if(con.State==ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
       
        if (Session["perdorues"]==null)
        {
            Response.Redirect("Login.aspx");
        }


        if (!Page.IsPostBack) {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();


        }





        /* SqlCommand cmd1 = con.CreateCommand();
         cmd1.CommandType = CommandType.Text;
         cmd1.CommandText = "select * from issue_books where student_username='"+ Session["perdorues"].ToString() +"'";
         cmd1.ExecuteNonQuery();
         DataTable dt1 = new DataTable();
         SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
         da1.Fill(dt1);
         foreach(DataRow dr1 in dt1.Rows)
         {

             DataRow dr = dt.NewRow();
             //dr["student_enrollment_no"] = dr1["student_enrollment_no"].ToString();
             dr["books_isbn"] = dr1["books_isbn"].ToString();
             dr["books_issue_date"] = dr1["books_issue_date"].ToString();
             dr["books_approx_return_date"] = dr1["books_approx_return_date"].ToString();
             dr["student_username"] = dr1["student_username"].ToString();
             dr["is_books_return"] = dr1["is_books_return"].ToString();
             dr["books_returned_date"] = dr1["books_returned_date"].ToString();

             //calculate late days

             DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
             DateTime d2 = Convert.ToDateTime(dr1["books_approx_return_date"].ToString());

             if(d1>d2)
             {
                 TimeSpan t = d1 - d2;
                 noofdays = t.TotalDays;
                 dr["latedays"] = noofdays.ToString();
             }
             else
             {
                 dr["latedays"] = "0";
             }

             dr["penalty"] = Convert.ToString(Convert.ToDouble(noofdays) * Convert.ToDouble(penalty));

             dt.Rows.Add(dr);

         }


         d1.DataSource = dt;
         d1.DataBind();
 */


    }

    protected void hiqShportaBtn_Click(object sender, EventArgs e) {
        String logedInUsername = Session["perdorues"].ToString();

        Button btn = (Button)sender;
        String[] commandArguments = btn.CommandArgument.ToString().Split(new char[] { ',' });
        String isbn = commandArguments[0];
        Int32 sasia = Int32.Parse(commandArguments[1]);


                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "delete from issue_books where student_username='" + logedInUsername + "' and books_isbn='" + isbn + "'";
                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update books set available_qty=available_qty+1 where books_isbn='" + isbn + "'";
                cmd4.ExecuteNonQuery();

                Label shoppingCartNumber = (Label)Master.FindControl("notification1");
                if (shoppingCartNumber.Text.Equals("")) {
                    shoppingCartNumber.Text = "0";
                }
                Int32 shoppingCartNr = Int32.Parse(shoppingCartNumber.Text) - 1;

                this.Master.ShoppingCartNumber = shoppingCartNr.ToString();

            }
        
    

}