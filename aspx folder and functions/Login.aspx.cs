using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace Shopping_Website_Project
{
    public partial class Login : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(emailID.Text) || string.IsNullOrWhiteSpace(password.Text)) { 
                Response.Write("<script> alert('Please enter all requirements.')</script>");
                return;
            }

            string email = emailID.Text.Trim();
            string password1 = password.Text.Trim();
            string query = "select * from SignedInUser where EmailId=@Email and Password = @Password";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password1);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read(); 
                        string fullname = reader["Fullname"].ToString();
                        Response.Write("<script>alert('Login successful. Welcome, " +  fullname + "!');</script>");

                        // Store the userID in session for future use
                        int userID = Convert.ToInt32(reader["ID"]);
                     
                        Session["UserID"] = userID;

                        Response.Redirect("Products.aspx" , false);
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