using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Shopping_Website_Project
{
    public partial class UserCart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserCart();
            }
        }

        private void LoadUserCart()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString;
            if (connectionString == null)
            {
                throw new Exception("Connection string not found. Please check Web.config.");
            }

            int userID = GetCurrentUserID();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT productID, productName FROM UserCart WHERE userID = @userID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        con.Open();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading user cart: " + ex.Message);
                    }
                }
            }
        }

        private int GetCurrentUserID()
        {
            if (Session["UserID"] != null)
            {
                return Convert.ToInt32(Session["UserID"]);
            }
            else
            {
                throw new Exception("User is not logged in.");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the user session
            Session.Clear();
            Session.Abandon();

            Response.Redirect("Home.aspx"); 
        }
    }
}
