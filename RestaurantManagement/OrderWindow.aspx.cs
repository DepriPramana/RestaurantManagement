using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string connectionString = @"Data Source=DESKTOP-CKU87KC\SQLSRV2012;Initial Catalog=Sample;Integrated Security=False;User ID=sa;Password=P@$$w0rd;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            
            POSDBDataContext db = new POSDBDataContext(connectionString);

            var temp = from ee in db.Products 
                       where ee.Status != false
                       select ee;
            
            foreach (var item in temp)
            {
                Panel panel = new Panel();

                ImageButton image = new ImageButton();
                image.ImageUrl = "~/Pictures/" + item.Image;
                image.Width = 200;
                foodPanel.Controls.Add(image);

                //foodPanel.Controls.Add(panel);
            }
            foodPanel.Controls.Add(new LiteralControl("<br />"));
            //foreach (var item in temp)
            //{
            //    Label label = new Label();
            //    label.Text = item.Name;
            //    //label.Attributes.CssStyle.Add("display", "block");
            //    label.Attributes.CssStyle.Add("margin-left", "80px");
            //    foodPanel.Controls.Add(label);

            //    foodPanel.Controls.Add(new LiteralControl("<span>  dgfgf    </span>"));

            //}
        }
    }
}