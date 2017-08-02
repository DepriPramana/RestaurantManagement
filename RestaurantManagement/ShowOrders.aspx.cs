using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantManagement
{
    public partial class ShowOrders1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                date.Text = DateTime.Now.ToShortDateString();
                orderList();
                GridBind();
            }



            //POSDBDataContext DB = new POSDBDataContext(Cache["ConnectionString"].ToString());

            //var dateWise = (from orders in DB.Orders
            //                join orderDetails in DB.Order_Details on orders.ID equals orderDetails.ID
            //                join pro in DB.Products on orderDetails.Product_ID equals pro.ID
            //                where orders.Date.Value.Date < DateTime.Parse(date.Text)
            //                select new { Amount = pro.Sale_Price * orderDetails.Quantity });

            //var sum = dateWise.Select(x => x.Amount).Sum();
        }
        protected void ImageButtonShowCalendar_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDOB.Visible = !CalendarDOB.Visible;
        }
        protected void CalendarDOB_SelectionChanged(object sender, EventArgs e)
        {
            date.Text = CalendarDOB.SelectedDate.ToShortDateString();
            CalendarDOB.Visible = false;

            orderList();
            GridBind();
        }
        private void orderList()
        {
            Response.Write(date.Text);

            POSDBDataContext DB = new POSDBDataContext(Cache["ConnectionString"].ToString());

            var orders = (from ee in DB.Orders  where ee.Date.Value.Date.Equals(DateTime.Parse(date.Text)) select ee).ToList();
            //Response.Write(orders.Count);

            if (orders.Count <= 0)
            {
                msg.Visible = true;
                return;
            }
            else
            {
                msg.Visible = false;
                Cache["orders"] = orders;
                ViewState["selectedIndex"] = orders.Count - 1;
            }
        }
        private void GridBind()
        {
            List<Order> list = (List<Order>)Cache["orders"];
            int selectedIndex = (int)ViewState["selectedIndex"];
            Order ord = list.ElementAt(selectedIndex);
            POSDBDataContext DB = new POSDBDataContext(Cache["ConnectionString"].ToString());
            var query = (from orders in DB.Orders
                         join orderDetails in DB.Order_Details on orders.ID equals orderDetails.Order_ID
                         join pro in DB.Products on orderDetails.Product_ID equals pro.ID
                         where orderDetails.Order_ID.Equals(ord.ID)
                         select new {OrderID = orders.ID ,Name = pro.Name, Sale = pro.Sale_Price, Quantity = orderDetails.Quantity, SubTotal = pro.Sale_Price * orderDetails.Quantity });
            //Response.Write(query.Count());
            var sum = query.Select(x => x.SubTotal).Sum();
            totalAmount.Text = sum.ToString();
            gridView.DataSource = query;
            gridView.DataBind();
        }
        protected void prev_Click(object sender, EventArgs e)
        {
            if (ViewState["selectedIndex"] == null)
            {
                msg.Visible = true;
                return;
            }

            List<Order> list = (List<Order>)Cache["orders"];
            
            if ((int)ViewState["selectedIndex"] <= 0 )
            {
                ViewState["selectedIndex"] = list.Count-1;
            }
            else
            {
                int value = (int)ViewState["selectedIndex"] - 1;
                ViewState["selectedIndex"] = value;
            }
            GridBind();

        }

        protected void next_Click(object sender, EventArgs e)
        {

            if (ViewState["selectedIndex"] == null)
            {
                msg.Visible = true;
                return;
            }
            List<Order> list = (List<Order>)Cache["orders"];

            if ((int)ViewState["selectedIndex"] >= list.Count - 1)
            {
                ViewState["selectedIndex"] = 0;
            }
            else
            {
                int value = (int)ViewState["selectedIndex"] + 1;
                ViewState["selectedIndex"] = value;
            }
            GridBind();

        }
    }
}
