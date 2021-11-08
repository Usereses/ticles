using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Articles
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("delete from Articles where Id ='" + Convert.ToInt32(TextBox1.Text).ToString() + "'",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "data has been deleted succefully";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Articles values('" + TextBox1.Text + "' ,'" + TextBox2.Text + "','" + TextBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "data has been created succefully";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
      
        {
            
            SqlCommand cmd = new SqlCommand("update Articles set Name = '" + TextBox2.Text + "',Description='" + TextBox3.Text + "'where Id ='" + TextBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "data has been updated succefully";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string find = "select * from Articles where (Id like '%' +@Id+ '%')";
            SqlCommand cmd = new SqlCommand(find, con);
            
            cmd.Parameters.Add("@Id ", SqlDbType.NVarChar).Value = TextBox4.Text;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet() ;
            da.Fill(ds, "Id");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();

        }
    }
}