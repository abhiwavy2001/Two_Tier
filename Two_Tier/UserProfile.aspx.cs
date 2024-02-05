using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Two_Tier
{
    public partial class UserProfile : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select Name,Age,Address,Photo from DT where id=" + Session["userid"] + "";
            SqlDataReader dr = obj.Fn_DataReader(sel);


            while (dr.Read())
            {
                Label1.Text = dr["Name"].ToString();
                Label2.Text = dr["Age"].ToString();
                Label3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["photo"].ToString();
            }
            DataSet ds = obj.Fn_DataSet(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dt = obj.Fn_DataTable(sel);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}