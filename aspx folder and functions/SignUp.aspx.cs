using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using Microsoft.Ajax.Utilities;


namespace Shopping_Website_Project
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            SignUpFunction();
        }

        private void SignUpFunction()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(dropdown.Text))
                {
                    Response.Write("<script> alert('Please enter all requirements.')</script>");
                    return;
                }

                string email = txtEmail.Text;
                string emailPattern = @"^[a-zA-Z0-9_]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
                Regex regex = new Regex(emailPattern);

                if (!regex.IsMatch(email))
                {
                    Response.Write("<script> alert('Please enter a valid email address.')</script>");
                    return;
                }

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd= new SqlCommand("insert into SignedInUser(FullName , Address , EmailId , Password , Gender)  values(@Fullname , @Address , @Email , @Password , @Gender)", con))
                    {
                        cmd.Parameters.AddWithValue("@Fullname", txtName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Gender", dropdown.Text);

                        cmd.ExecuteNonQuery();
                    }
                    Response.Write("<script> alert('Success')</script>");
                }
                clear();
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "')</script>");
            }
        }

        private void clear()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            dropdown.Text= string.Empty;
        }

        
    }
}