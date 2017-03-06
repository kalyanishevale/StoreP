using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Disp();
    }
    private void Disp()
    {
        SqlConnection con = new SqlConnection("Data Source=NI3-PC;Initial Catalog=Stored;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("getstor", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "stor");
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //SqlCommand s = new SqlCommand("Stored",new SqlConnection());
        SqlConnection con = new SqlConnection("Data Source=NI3-PC;Initial Catalog=Stored;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("insert_stor", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id",TextBox1.Text);
        cmd.Parameters.AddWithValue("@name",TextBox2.Text);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Disp();
        Response.Write("New Record is inserted");
    }
}