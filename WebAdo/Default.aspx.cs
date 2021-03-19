﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebAdo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("<center><h1>Read data from a database</h1></center><hr/>");
                Response.Write("<br/>");

                //step 1 Read connection string
                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

                //step 2 Create an sql connection
                SqlConnection con = new SqlConnection(s);

                //setup query string
                string sqlString = "select * from customers";

                //setup sql command object
                SqlCommand cmd = new SqlCommand(sqlString, con);

                //open the connection
                con.Open();

                //execute the command
                //use cmd.ExecuteReader() for SELECT statement
                //use cmd.ExecuteScalar for return of count or single numbers
                SqlDataReader dr = cmd.ExecuteReader();

                //use cmd.ExecuteNonQuery() for INSERT, UPDATE, DELETE. - CRUD
                //setup datasource for GridView
                GridView1.DataSource = dr;

                //bind datasource to GridView
                GridView1.DataBind();

                //close datareader
                dr.Close();

                //Handle drop-down menu
                string sqlStringDropDownList = "select distinct Country from customers";
                SqlCommand cmd2 = new SqlCommand(sqlStringDropDownList, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                try
                {
                    while (dr2.Read() == true)
                    {
                        DropDownList1.Items.Add(new ListItem(dr2["Country"].ToString(),
                            dr2["Country"].ToString()));
                    }
                }
                finally
                {
                    dr2.Close();

                    //close the connection
                    con.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<center><h1>Read data from a database</h1></center><hr/>"); 
            Response.Write("<br/>"); 
            String txtValue = TextBox1.Text; 

            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString; 
            SqlConnection con = new SqlConnection(s); 
            string sqlString = "select * from customers where Country=@Country"; 
            SqlCommand cmd = new SqlCommand(sqlString, con);
            
            //to prevent sql injection
            //Bind txtValue to the parameter @Country
            cmd.Parameters.AddWithValue("@Country", txtValue); 

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            
            //Cleanup
            dr.Close();
            con.Close();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditForm.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<br/>");
                string txtValue = DropDownList1.SelectedValue.ToString();
                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers where Country=@Country";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@Country", txtValue);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();

                dr.Close();
                con.Close();
            }
        }
    }
}