﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantManagement
{
    public partial class OrderWindow : System.Web.UI.Page
    {
        List<Order_Received> listOrder_Received = new List<Order_Received>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string connectionString = @"Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Cache["ConnectionString"] = connectionString;
            POSDBDataContext db = new POSDBDataContext(connectionString);

            var query = (from ee in db.Products
                         where ee.Status.Equals( true)
                         select ee).ToList();
            int rowCount = query.Count();

            double numbeofSubTables = (rowCount / 4.0) ;
            bool isInt = numbeofSubTables % 1 == 0; //checking int or not
            if (!isInt) //if not int then add 1 to make table
               numbeofSubTables += 1;
            numbeofSubTables = (int)numbeofSubTables;
            int numberOfLastSubTableColumn = rowCount % 4;
            int imageCount = 0;
            int imageNameCount = 0;
            for (int i = 1; i <= numbeofSubTables; i++)
            {
                Table subTable = new Table();
                subTable.CellSpacing = 10;
                //subTable.CellPadding = 10;
                //subTable.BorderWidth = 1;

                TableRow row1 = new TableRow();
                row1.HorizontalAlign = HorizontalAlign.Center;
                subTable.Rows.Add(row1);

                for (int j = 0; j < 4; j++)
                {
                    TableCell cell = new TableCell();
                    row1.Cells.Add(cell);

                    ImageButton image = new ImageButton();
                    image.ID = query[imageCount].ID.ToString();
                    image.ImageUrl = "~/Pictures/" + query[imageCount].Image;
                    image.Width = 170;
                    image.Click += Image_Click;
                    cell.Controls.Add(image);
                    imageCount++;

                    if (i == numbeofSubTables && j == numberOfLastSubTableColumn - 1)
                        break;
                }

                TableRow row2 = new TableRow();
                row2.HorizontalAlign = HorizontalAlign.Center;
                subTable.Rows.Add(row2);
                for (int j = 0; j < 4; j++)
                {
                    TableCell cell = new TableCell();
                    row2.Cells.Add(cell);

                    Label label = new Label();
                    label.Text = query[imageNameCount].Name;
                    cell.Controls.Add(label);
                    imageNameCount++;

                    if (i == numbeofSubTables && j == numberOfLastSubTableColumn-1)
                        break;

                }

                foodSelectionPanel.Controls.Add(subTable);
            }
            if(!IsPostBack)
            {
                //listOrder_Received = new List<Order_Received>();
                ViewState["orderSerial"] = 0;
                //ViewState["listOrder_Received"] = listOrder_Received;
                orderGridView.DataSource = listOrder_Received;
                orderGridView.DataBind();
            }
        }
        private void BindGrid()
        {
            if (ViewState["listOrder_Received"] != null)
                listOrder_Received = (List<Order_Received>)ViewState["listOrder_Received"];
            orderGridView.DataSource = listOrder_Received;
            orderGridView.DataBind();

            if (orderGridView.Rows.Count <= 0)
                confirmOrder.Visible = false;
            else
                confirmOrder.Visible = true;
        }
        private void Image_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["listOrder_Received"] != null)
                listOrder_Received = (List<Order_Received>)ViewState["listOrder_Received"];
            POSDBDataContext DB = new POSDBDataContext(Cache["ConnectionString"].ToString());
            ImageButton image = sender as ImageButton;
            int productID = int.Parse(image.ID);
            bool flag = false;
            if (listOrder_Received.Count > 0)
                foreach (var item in listOrder_Received)
                {
                    if (item.Product_ID == productID)
                    {
                        item.Quantity++;
                        item.SubTotal = item.Quantity * item.Price;
                        //
                        flag = true;
                        break;
                    }
                }
            if (flag == false)
            {
                var product = (from ee in DB.Products
                               where ee.Status.Equals(true) && ee.ID == productID
                               select ee).FirstOrDefault();
                //Order_Detail orderDetails = new Order_Detail() { Product = product, Quantity =1 };
                int serial = (int)ViewState["orderSerial"];
                ViewState["orderSerial"] = ++serial;

                Order_Received obj = new Order_Received() { Price = (double)product.Sale_Price, Product_ID = product.ID, Name = product.Name, SL =  serial, Quantity = 1, SubTotal = (double)product.Sale_Price };
                listOrder_Received.Add(obj);
            }
            //Response.Write(listOrder_Received.Count);
            ViewState["listOrder_Received"] = listOrder_Received;
            BindGrid();
        }

        protected void orderGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            if (ViewState["listOrder_Received"] != null)
                listOrder_Received = (List<Order_Received>)ViewState["listOrder_Received"];
            //Response.Write(orderGridView.SelectedIndex);
            listOrder_Received.RemoveAt(e.RowIndex);
            BindGrid();
            
        }

        protected void orderGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            orderGridView.EditIndex = e.NewEditIndex;

            BindGrid();
        }

        protected void orderGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (ViewState["listOrder_Received"] != null)
                listOrder_Received = (List<Order_Received>)ViewState["listOrder_Received"];

            Order_Received order = listOrder_Received.ElementAt(e.RowIndex);
            
            //Response.Write(e.NewValues["Quantity"]);

            order.Quantity = Convert.ToInt32(e.NewValues["Quantity"]);
            order.SubTotal = order.Quantity * order.Price;

            orderGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void orderGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            orderGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void orderGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            msg.Text = "";

            foreach (TableCell cell in e.Row.Cells)
            {
                if (!string.IsNullOrEmpty(cell.Text) && cell.Text != "&nbsp;")
                {
                    try
                    {
                        BoundField field = (BoundField)((DataControlFieldCell)cell).ContainingField;
                        if (field.DataField != "Quantity")
                            field.ReadOnly = true;
                    }
                    catch
                    {

                    }
                }
            }
        }
     
        protected void confirmOrder_Click(object sender, EventArgs e)
        {
            if (ViewState["listOrder_Received"] != null)
                listOrder_Received = (List<Order_Received>)ViewState["listOrder_Received"];

            try
            {
                Store.addOrder(listOrder_Received);
                msg.Text = "Order is Placed Successfully";
                listOrder_Received.Clear();
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write("Error while placing order");
                Response.Write(ex.Message + " " + ex.StackTrace);
            }
        }
    }
    [Serializable]
    public class Order_Received
    {
        public int SL { set; get; }
        public int Product_ID { set; get; }
        public string Name { set; get; }
        public double Price { set; get; }
        public int Quantity { set; get; }
        public double SubTotal { set; get; }

        public Order_Received()
        {
            SL = 0;
        }
    }
}