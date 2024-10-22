using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Shopping_Website_Project
{
    public partial class Login : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = emailID.Text.Trim();
            string password1 = password.Text.Trim();
            string query = "select * from TableUserMaster where Email=@Email and Password = @Password";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password1);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read(); 
                        string fullname = reader["Fullname"].ToString(); 
                        Response.Write("<script>alert('Login successful. Welcome, " + fullname + "!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid login credentials!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occured " + ex.Message + "' );</script>");
                }

            }
          
            


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
     
            Response.Redirect("Home.aspx"); 
        }


    }
}