using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantManagement
{
    public partial class AddFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile)
            {
                imageErroe.Text = "NoFile is selected";
                return;
            }
            else
            {
                imageErroe.Text = "";
            }
            string filePath = Server.MapPath("~/Pictures");
            int lastfileName = Store.getLastFilename()+1;
            fileUpload.SaveAs(filePath + "\\" + fileUpload.FileName);
            string source = filePath + "\\" + fileUpload.FileName;
            string destination = filePath + "\\" + lastfileName + ".jpg";
            Response.Write(source);
            Response.Write("<br>" + destination);
            File.Move(source, destination);

            Product product = new Product();
            product.Name = name.Text;
            product.Image = lastfileName+ ".jpg";
            product.Sale_Price = int.Parse(salePrice.Text);
            product.Unit_Price = int.Parse(unitPrice.Text);
            product.Status = true;

            try
            {
                Store.addFood(product);

            }
            catch(Exception ex)
            {
                errorMsg.Text = ex.Message;
            }
        }
    }
}