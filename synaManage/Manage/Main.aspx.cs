using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class Main : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                if (Session["userName"] == null || Session["userName"].ToString() == "")
                    Response.Redirect("~/Account/Login.aspx");


                //DataTable dt = DBService.getDataTable("select * from dbo.users where user_mail = '" + Context.User.Identity.GetUserName() + "'");
                DataTable dt = DBService.getDataTable("select * from dbo.users where user_mail = '" + Session["userName"].ToString() + "'");
                if (dt.Rows.Count == 0)
                {
                    errorLable.Visible = true;
                    PanelMenu.Visible = false;  
                    errorLable.Text = "המשתמש לא הוגדר בטבלת המשתמשים יש לפנות למנהל המערכת";
                }
                else
                {
                    if (dt.Rows[0]["user_role"].ToString() == "GABAI")
                    {
                        if (dt.Rows[0]["syn_id"].ToString().Length == 0 )
                        {
                            errorLable.Visible = true;
                            PanelMenu.Visible = false;
                            errorLable.Text = "המשתמש לא שויך לבית כנסת יש לפנות למנהל המערכת";

                        }
                        else
                        {

                            Session["SYN_ID"] = dt.Rows[0]["syn_id"].ToString();
                            Session["syn_name"] = DBService.getResult("SELECT syn_name  FROM syn  where syn_id = " + dt.Rows[0]["syn_id"].ToString());
                            Response.Redirect("NihulZmanim.aspx");
                        }
                       

                    }

                    else if (dt.Rows[0]["user_role"].ToString() == "KABAT")
                    {
                        Response.Redirect("../cityManagement/HodatHerumPage.aspx");
                    }
                    else if (dt.Rows[0]["user_role"].ToString() == "ADMIN" || dt.Rows[0]["user_role"].ToString() == "TECH")
                    {
                        DataTable dtSyn = DBService.getDataTable("select syn_id , syn_name from syn");


                        synDropDown.DataSource = dtSyn;
                        synDropDown.DataBind();
                        synDropDown.SelectedIndex = 0;
                        Session["SYN_ID"] = synDropDown.SelectedValue;
                        Session["Syn_Name"] = synDropDown.SelectedItem;
                       // labelSynId.Text = "קוד - " + synDropDown.SelectedValue;
                        labelLink.Text  = "https://a-digital.co.il/luach/index.html?synid=" + synDropDown.SelectedValue;
                    }

                }
                
                
                

            }

        }


        protected void synDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SYN_ID"] = synDropDown.SelectedValue;
            Session["Syn_Name"] = synDropDown.SelectedItem;
          //  labelSynId.Text = "קוד - " +  synDropDown.SelectedValue;
            labelLink.Text = "https://a-digital.co.il/luach/index.html?synid=" + synDropDown.SelectedValue;

        }
    }
}