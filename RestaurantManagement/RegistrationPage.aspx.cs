using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantManagement
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            LoadFromCache();

        }
        private void LoadFromCache()
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadFromDatabase();
            }
            DataSet ds = (DataSet)Cache["DATASET"];
            //  GridViewCourseList.DataSource = ds.Tables["Courses"];
            // GridViewCourseList.DataBind();



        }
        private void LoadFromDatabase()
        {
            string sql = "SELECT * FROM Employees";

            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(connStr);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");
            ds.Tables["Employees"].PrimaryKey = new DataColumn[] { ds.Tables["Employees"].Columns["EmployeeId"] };
            Cache["DATASET"] = ds;
            Cache["Employees_Adapter"] = adapter;

        }


        protected void register_Click(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            DataSet ds = (DataSet)Cache["DATASET"];
            int n = new Random().Next(1,100);
            DataRow dr = ds.Tables["Employees"].NewRow();

            dr["EmployeeId"] = GridView1.Rows.Count + n;
            dr["EmployeeName"] = FullName.Text;
            dr["Email"] = email.Text;
            dr["Address"] = address.Text;
            dr["Password"] = pass.Text;
            //dr["DOB"] = Calendar1.SelectedDate;
            dr["DOB"] = DateTime.Parse(date.Text);
            ds.Tables["Employees"].Rows.Add(dr);
            Cache["DATASET"] = ds;
            SqlDataAdapter adapter = (SqlDataAdapter)Cache["Employees_Adapter"];//
            adapter.Update(ds.Tables["Employees"]);
            this.LoadFromDatabase();
            // GridView1.DataSource = ds.Tables["Employees"];
            //GridView1.DataBind();
            Label13.Text = "Employee Registered Successfully";
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
        protected void ImageButtonShowCalendar_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDOB.Visible = !CalendarDOB.Visible;
        }
        protected void CalendarDOB_SelectionChanged(object sender, EventArgs e)
        {
            date.Text = CalendarDOB.SelectedDate.ToShortDateString();
            CalendarDOB.Visible = false;
        }
    }
}