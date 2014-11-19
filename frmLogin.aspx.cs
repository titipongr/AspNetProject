using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

 
namespace AspNetMember
{
    public partial class frmLogin : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CupCakeConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from User_data where Email='" + txtemail.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if(temp == 1)
                {
                    Response.Write("เข้าสู่ระบบ");
                }
                conn.Close();
            }

            if (!Page.IsPostBack)
            {
                txtpass.Attributes.Add("value","กรุณาป้อนรหัสผ่าน");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CupCakeConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from user_data where Email='" + txtemail.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    conn.Open();
                    string checkPasswordQuery = "select pass form user_data";
                    Response.Write("เข้าสู่ระบบ");
                }
                conn.Close();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CupCakeConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = ("INSERT INTO user_data (FName,LName,Email,Pass) values (@Fname,@Lname,@Email,@Pass)");
                SqlCommand com = new SqlCommand(insertQuery, conn);
                
                com.Parameters.AddWithValue("@Fname", txtfirst.Text);
                com.Parameters.AddWithValue("@Lname", txtlast.Text);
                com.Parameters.AddWithValue("@Email", txtemail.Text);
                com.Parameters.AddWithValue("@Pass", txtpass.Text);
           
                
                com.ExecuteNonQuery();
                Response.Redirect("Show.aspx");
                Response.Write("สมัครสมาชิกเสร็จสิ้น");
                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error"+ex.ToString());
            }
        }
    }
}