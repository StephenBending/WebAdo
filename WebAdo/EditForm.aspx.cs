using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

//  *** NOTE ***
// I am aware that CRUD can be implemented much more cleanly using inbuilt features, 
// however I wanted to implement a functional version myself to better understand the process.
//  *** NOTE ***


namespace WebAdo
{
    public partial class EditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            String txtValue = txtCID.Text;

            TextBox[] outputs = { txtCID , txtCompN, txtContN, txtContT, txtAddr, txtCit, txtReg, txtPstCode, txtCntry, txtPhone, txtFax};

            foreach (var t in outputs) t.Text = "";

            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "select * from customers where CustomerID=@CustomerID";
            SqlCommand cmd = new SqlCommand(sqlString, con);

            //to prevent sql injection
            //Bind txtValue to the parameter @Country
            cmd.Parameters.AddWithValue("@CustomerID", txtValue);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    outputs[i].Text = dr.GetValue(i).ToString();
                    //Response.Write(dr.GetValue(i));
                }
                //Response.Write("Has rows " + dr.GetString(0));
            }

            //Cleanup
            dr.Close();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ID = txtCID.Text;

            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "delete from customers where CustomerID=@CustomerID";
            SqlCommand cmd = new SqlCommand(sqlString, con);

            //to prevent sql injection
            //Bind txtValue to the parameter @Country
            cmd.Parameters.AddWithValue("@CustomerID", ID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString;

            if (check_Exists(txtCID.Text))
            {
                sqlString = "update customers set " +
                    "CompanyName = @CmpN, " +
                    "ContactName = @ConN, " +
                    "ContactTitle = @ConT, " +
                    "Address = @Addr, " +
                    "City = @City, " +
                    "Region = @Reg, " +
                    "PostalCode = @PC, " +
                    "Country = @Ctry, " +
                    "Phone = @Pne, " +
                    "Fax = @Fax " +
                    "where CustomerID=@CustomerID";
            }
            else
            {
                sqlString = "insert into customers values (" +
                    "@CustomerID, " +
                    "@CmpN, " +
                    "@ConN, " +
                    "@ConT, " +
                    "@Addr, " +
                    "@City, " +
                    "@Reg, " +
                    "@PC, " +
                    "@Ctry, " +
                    "@Pne, " +
                    "@Fax" +
                    ")";
            }

            SqlCommand cmd = new SqlCommand(sqlString, con);
            cmd.Parameters.AddWithValue("@CustomerID", txtCID.Text);
            cmd.Parameters.AddWithValue("@CmpN", txtCompN.Text);
            cmd.Parameters.AddWithValue("@ConN", txtContN.Text);
            cmd.Parameters.AddWithValue("@ConT", txtContT.Text);
            cmd.Parameters.AddWithValue("@Addr", txtAddr.Text);
            cmd.Parameters.AddWithValue("@City", txtCit.Text);
            cmd.Parameters.AddWithValue("@Reg", txtReg.Text);
            cmd.Parameters.AddWithValue("@PC", txtPstCode.Text);
            cmd.Parameters.AddWithValue("@Ctry", txtCntry.Text);
            cmd.Parameters.AddWithValue("@Pne", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        private bool check_Exists(string ID)
        {
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "select * from customers where CustomerID=@CustomerID";
            SqlCommand cmd = new SqlCommand(sqlString, con);

            //to prevent sql injection
            //Bind txtValue to the parameter @Country
            cmd.Parameters.AddWithValue("@CustomerID", ID);

            try
            {
                con.Open();
                if (!(cmd.ExecuteScalar() is null))
                {
                    return true;
                }
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}