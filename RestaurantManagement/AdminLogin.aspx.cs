using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantManagement
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //GridView1.DataSource = reader;
            //GridView1.DataBind();
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlDataAdapter sa = new SqlDataAdapter();

            string sql = "SELECT * FROM Employees where EmployeeId='" + userid.Text + "' and password='" + password.Text + "'";
            //string sql = "INSERT INTO Employees VALUES (99, 'Test', 'test@aiub.edu')";

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Response.Redirect("~/OrderWindow.aspx");
            }
            else
            {
                Label2.Text = "UserId / Password is not correct Try again..!!";

            }
            con.Close();


        }
    }
}