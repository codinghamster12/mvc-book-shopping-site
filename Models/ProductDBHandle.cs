using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace bookstore1.Models
{
    public class ProductDBHandle
    {
        private SqlConnection con;
        private List<Book> productlist;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["bookStore"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddOrder(Orders order)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Country", order.Country);
            cmd.Parameters.AddWithValue("@Firstname", order.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", order.Lastname);
            cmd.Parameters.AddWithValue("@Address", order.Address);
            cmd.Parameters.AddWithValue("@City", order.City);
            cmd.Parameters.AddWithValue("@Email", order.Email);
            cmd.Parameters.AddWithValue("@Phone", order.Phone);
            cmd.Parameters.AddWithValue("@Zip", order.Zip);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



        public bool AddProduct(Book bmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title",bmodel.Title);
            cmd.Parameters.AddWithValue("@Description", bmodel.Description);
            cmd.Parameters.AddWithValue("@Author", bmodel.Author);
            cmd.Parameters.AddWithValue("@Category", bmodel.Category);
            cmd.Parameters.AddWithValue("@Price", bmodel.Price);
            cmd.Parameters.AddWithValue("@Cover", bmodel.Cover);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Book> GetProduct()
        {
            connection();
            this.productlist = new List<Book>();

            SqlCommand cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productlist.Add(
                    new Book
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Title = Convert.ToString(dr["Title"]),
                        Description = Convert.ToString(dr["Description"]),
                        Author = Convert.ToString(dr["Author"]),
                        Category = Convert.ToString(dr["Category"]),
                        Price = Convert.ToDouble(dr["Price"]),
                        Cover = Convert.ToString(dr["Cover"])

                    });
                        
            }
            return productlist;
        }

        public Book find(int id)
        {
            return this.productlist.Single(p => p.Id.Equals(id));
        }

        public bool UpdateDetails(Book bmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", bmodel.Id);
            cmd.Parameters.AddWithValue("@Title", bmodel.Title);
            cmd.Parameters.AddWithValue("@Description", bmodel.Description);
            cmd.Parameters.AddWithValue("@Author", bmodel.Author);
            cmd.Parameters.AddWithValue("@Category", bmodel.Category);
            cmd.Parameters.AddWithValue("@Price", bmodel.Price);
            cmd.Parameters.AddWithValue("@Cover", bmodel.Cover);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

      
        public bool DeleteProduct(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
  

    
    


