using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Shopping_Website_Project
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Load available products into GridView
                LoadProducts();
                LoadUserIdentity();
            }
        }

        private void LoadUserIdentity()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString;
            if(connectionString == null)
            {
                throw new Exception("Connection String not found . Please check Web.Config");
            }
            //string query = "Select fullName from TableUserMaster where UID = @userID";
            string query = "Select fullName from SignedInUser where ID = @userID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine(reader.GetString(0));
                            //while (reader.Read())
                            //{
                            //    // Get the 'fullName' column value
                            //    string fullName = reader["fullName"].ToString();

                            //    // Display the greeting
                            //    Console.WriteLine($"Hello, {fullName}");
                            //}
                        }

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }

        }

        private void LoadProducts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString;

            if (connectionString == null)
            {
                throw new Exception("Connection string not found. Please check Web.config.");
            }

            string query = "SELECT productID, productName FROM AvailableProducts where isAvailable = 1";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {     
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Bind the results to the GridView
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error fetching products: " + ex.Message);
                    }
                }
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string productID = GridView1.DataKeys[rowIndex].Value.ToString();
                string productName = GridView1.Rows[rowIndex].Cells[1].Text;
                int userID = GetCurrentUserID();

                int a= GetCurrentUserID();
                if(a != 0)
                {
                    if (IsProductAvailable(productID))
                    {
                        AddProductToCart(userID, productID, productName);
                    }
                    else
                    {
                        Response.Write("<script>alert('The product is not available.');</script>");
                    }
                }
                
            }
        }

        private bool IsProductAvailable(string productID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString;
            if (connectionString == null)
            {
                throw new Exception("Connection string not found. Please check Web.config.");
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT isAvailable FROM AvailableProducts WHERE productID = @productID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productID", productID);
                    con.Open();

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (result is DBNull)
                        {
                            return false; 
                        }

                        return Convert.ToBoolean(result); 
                    }

                    return false;
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
                Response.Write("<script>alert('User is not logged in.');</script>");
                return 0;
            }
        }

        private void AddProductToCart(int userID, string productID, string productName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString;
            if (connectionString == null)
            {
                throw new Exception("Connection string not found. Please check Web.config.");
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryMain = "INSERT INTO UserCart (userID, productID, productName) VALUES (@userID, @productID, @productName)";
                string queryNext = "UPDATE AvailableProducts set isAvailable= 0 where productID=@productID";

                using (SqlCommand cmd = new SqlCommand(queryMain, con))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@productID", productID);
                    cmd.Parameters.AddWithValue("@productName", productName);
           
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                using (SqlCommand cmd = new SqlCommand(queryNext,con))
                {
                    cmd.Parameters.AddWithValue("@productID" , productID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                Response.Redirect("Thanks.aspx");
              
            }
        }
    }
}
