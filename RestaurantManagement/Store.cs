using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement
{
    
    public class Store
    {
        public static string conn = @"Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static int getLastFilename()
        {
            try
            {
                string conn = @"Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                POSDBDataContext DB = new POSDBDataContext(conn);
                int result = (from t in DB.Products
                              orderby t.ID descending
                              select t.ID).First();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool removeFood(int productID)
        {
            try
            {
                POSDBDataContext DB = new POSDBDataContext(conn);
                var pro = (from ee in DB.Products
                          where ee.ID == productID
                          select ee).ToList();
                if (pro.Count == 1)
                {
                    DB.Products.DeleteOnSubmit(pro.First());
                    DB.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool addFood(Product product)
        {
            try
            {
                string conn = @"Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                POSDBDataContext DB = new POSDBDataContext(conn);

                DB.Products.InsertOnSubmit(product);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool addOrder(List<Order_Received> listOrder_Received)
        {
            try
            {
                string conn = @"Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                POSDBDataContext DB = new POSDBDataContext(conn);

                Order order = new Order();
                order.Date = DateTime.Now;
                foreach (var item in listOrder_Received)
                {
                    Order_Detail details = new Order_Detail(); //{ Product_ID = item.Product_ID, Quantity = item.Quantity, Order = order };\
                    details.Product_ID = item.Product_ID;
                    details.Quantity = item.Quantity;
                    details.Order = order;

                    DB.Order_Details.InsertOnSubmit(details);
                }

                DB.SubmitChanges();
                return true;
        }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
    }
}
    }
}