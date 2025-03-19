using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class usersManage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");


            if (Session["syn_name"] is null )
                Response.Redirect("Main.aspx");


            labelSynName.InnerText = Session["syn_name"].ToString();
            GridViewUsers.RowDeleting += GridViewUsers_RowDeleting;


            string str = "select u.* ,  " +
                " (select syn_name from syn " +
                "  where syn.syn_id = u.syn_id) syn_name , " +
                " (select name from cities " +
                "  where city_id = u.cityID) city_name , " +
                "'FALSE' selected from users u ";
            if (CheckBoxOnlyGabayim.Checked)
            {
                str += "where syn_id is null and user_role = 'GABAI'";
            }

            DataTable dt = DBService.getDataTable(str);
            GridViewUsers.DataSource = dt;
            GridViewUsers.DataBind();

        }

        private void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DBService.ExecuteStatement("update users set syn_id = " + Session["syn_id"].ToString() +  " where user_mail = '" + e.Values[0].ToString() + "'");

            Response.Redirect("Main.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}