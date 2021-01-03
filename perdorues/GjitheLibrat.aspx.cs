using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class student_student_display_all_books : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();

        if (Session["perdorues"] == null)
        {
            Response.Redirect("Login.aspx");
        }


        if (!Page.IsPostBack) {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();

            String username = Session["perdorues"].ToString();

            SqlCommand shoppingCartCmd = con.CreateCommand();
            shoppingCartCmd.CommandType = CommandType.Text;
            shoppingCartCmd.CommandText = "select * from issue_books where student_username='" + username + "'";
            shoppingCartCmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter ddataAdapter = new SqlDataAdapter(shoppingCartCmd);
            ddataAdapter.Fill(dataTable);
            this.Master.ShoppingCartNumber = dataTable.Rows.Count.ToString();
        }
    }

    protected void shtoShporteBtn_Click(object sender, EventArgs e) {

        String logedInUsername = Session["perdorues"].ToString();

        Button btn = (Button)sender;
        String[] commandArguments = btn.CommandArgument.ToString().Split(new char[] { ',' });
        String isbn = commandArguments[0];
        Int32 sasia = Int32.Parse(commandArguments[1]);

        /*if (isbn == "Select") {
            Response.Write("<script>alert('plese select books'); window.location.href=window.location.href</script>");
        }
        else {*/
        // this is for checking student have this books or not
        int found = 0;
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from issue_books where student_username='" + logedInUsername + "' and books_isbn='" + isbn+ "' and is_books_return='no'";
            cmd0.ExecuteNonQuery();
            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);
            found = Convert.ToInt32(dt0.Rows.Count.ToString());

            if (found > 0) {
                Response.Write("<script>alert('this book is already available with this student'); </script>");
            }
            else {


                //this is for books available in stocks or not
                if (sasia == 0) {
                    Response.Write("<script>alert('this book is not available in stock');</script>");
                }
                else {
                    //this is for insert
                    string books_isseue_date = DateTime.Now.ToString("yyyy/MM/dd");
                    string approx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                    string username = "";
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from student_registration where username='" + logedInUsername + "'";
                    cmd2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);
                    foreach (DataRow dr2 in dt2.Rows) {
                        username = dr2["username"].ToString();
                    }

                    SqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into issue_books values('" + isbn+ "','" + books_isseue_date.ToString() + "','" + approx_return_date.ToString() + "','" + username.ToString() + "','no','no')";
                    cmd3.ExecuteNonQuery();


                    SqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandType = CommandType.Text;
                    cmd4.CommandText = "update books set available_qty=available_qty-1 where books_isbn='" + isbn + "'";
                    cmd4.ExecuteNonQuery();

                Label shoppingCartNumber = (Label)Master.FindControl("notification1");
                if (shoppingCartNumber.Text.Equals("")) {
                    shoppingCartNumber.Text = "0";
                }
                Int32 shoppingCartNr = Int32.Parse(shoppingCartNumber.Text) + 1;

                this.Master.ShoppingCartNumber = shoppingCartNr.ToString();

                    Response.Write("<script>alert('books issues successfully'); window.location.href=window.location.href;</script>");
                }
            }
        }
    }
