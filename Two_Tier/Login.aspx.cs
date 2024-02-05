using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Two_Tier
{
    public partial class Login : System.Web.UI.Page
    {
        ConCls obj = new ConCls();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string uid = "";
            string sel = "select count(id) from DT where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "')";
            string cid = obj.Fn_Scalar(sel);

            if(cid=="1")
            {
                string select = "select Id from DT where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "')";
                SqlDataReader dr = obj.Fn_DataReader(select);
                while(dr.Read())
                {
                    uid = dr["Id"].ToString();
                }
                Session["userid"] = uid;
                Response.Redirect("Userprofile.aspx");
            }
            else
            {
                Label1.Text = "Invalid username or password";
            }

        }
    }
}