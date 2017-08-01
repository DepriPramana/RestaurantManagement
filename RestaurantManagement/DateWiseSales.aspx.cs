using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantManagement
{
    public partial class ShowOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                date.Text = DateTime.Now.ToShortDateString();

            
            if(!IsPostBack)
                BindGrid();

        }
        protected void ImageButtonShowCalendar_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDOB.Visible = !CalendarDOB.Visible;
        }
        protected void CalendarDOB_SelectionChanged(object sender, EventArgs e)
        {
            date.Text = CalendarDOB.SelectedDate.ToShortDateString();
            CalendarDOB.Visible = false;
            BindGrid();
        }

        private void BindGrid()
        {
            Response.Write(date.Text);
            string datet = DateTime.Now.ToShortDateString();
            Response.Write(DateTime.Parse(datet));
            POSDBDataContext DB = new POSDBDataContext(Cache["ConnectionString"].ToString());
            var showOrder = (from orders in DB.Orders
                             join orderDetails in DB.Order_Details on orders.ID equals orderDetails.ID
                             join pro in DB.Products on orderDetails.Product_ID equals pro.ID
                             where orders.Date.Value.Date.Equals(DateTime.Parse(date.Text))
                             select new { OrderID = orderDetails.ID, Name = pro.Name, Sale = pro.Sale_Price, Quantity = orderDetails.Quantity, SubTotal = pro.Sale_Price * orderDetails.Quantity });
            var sum = showOrder.Select(x => x.SubTotal).Sum();
            totalSalesAmount.Text = sum.ToString();
            gridView.DataSource = showOrder;
            gridView.DataBind();
        }

        protected void prev_Click(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Parse(date.Text);
            datetime = datetime.AddDays(-1);
            date.Text = datetime.Date.ToShortDateString();
            BindGrid();

        }

        protected void next_Click(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Parse(date.Text);
            datetime = datetime.AddDays(1);
            date.Text = datetime.Date.ToShortDateString();
            BindGrid();

        }
    }
}