using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using bookstore1.Models;

namespace bookstore1.Controllers
{
    public class UserDBHandle
    {
        private SqlConnection con;
        private List<User> userslist;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["bookStore"].ToString();
            con = new SqlConnection(constring);
        }
        public bool AddUser(User user)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", "user");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool validateUser(User loginUser)
        {
            connection();
            this.userslist = new List<User>();

            SqlCommand cmd = new SqlCommand("GetUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userslist.Add(
                    new User
                    {
                        
                        Email = Convert.ToString(dr["Email"]),
                        Password = Convert.ToString(dr["Password"]),
                        

                    });

            }
            foreach (User user in userslist)
            {
                if (user.Email == loginUser.Email && user.Password== loginUser.Password)
                {
                    return true;
                    break;
                }
               
            }
            return false;
           

        }
        public bool validateAdmin(User admin)
        {
            connection();
            this.userslist = new List<User>();

            SqlCommand cmd = new SqlCommand("GetUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userslist.Add(
                    new User
                    {
                        Firstname= Convert.ToString(dr["Firstname"]),
                        Email = Convert.ToString(dr["Email"]),
                        Password = Convert.ToString(dr["Password"]),
                        role= Convert.ToString(dr["Role"]),


                    });

            }

            foreach (User user in userslist)
            {
                if (user.Email == admin.Email && user.Password == admin.Password)
                {
                    if(user.role == "admin")
                    {
                        admin.Firstname = user.Firstname;
                        return true;
                        break;
                    }
                    
                }

            }

            return false;

        }

        
    }
}