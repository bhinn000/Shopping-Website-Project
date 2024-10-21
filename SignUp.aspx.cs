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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDatabase"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into TableUserMaster(Fullname , Address , Email , Password , Gender)  values(@Fullname , @Address , @Email , @Password , @Gender)", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@Fullname" , txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Gender", dropdown.Text);

                cmd.ExecuteNonQuery();
                clear();
                Response.Write("<script> alert('Sucess')</script>");
                con.Close();

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