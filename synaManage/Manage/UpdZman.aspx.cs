using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class UpdZman : Page
    {
        string timeId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");

            timeId = Request.QueryString["TIMEID"];
            if (!Page.IsPostBack)
            {
                 

                DataTable dt = DBService.getDataTable("select * from syn_times where syn_id = " + Session["SYN_ID"] + "  and time_id = " + timeId);
               
                textBoxFixHour.Text = dt.Rows[0]["fix_hour"].ToString();
                textBoxName.Text = dt.Rows[0]["name"].ToString();
                DropDownListTfilaType.SelectedValue = dt.Rows[0]["time_type"].ToString();
                numericMinutes.Text = dt.Rows[0]["gap_minutes"].ToString();
                DropDownListGapType.SelectedValue = dt.Rows[0]["gap_type"].ToString();
                DropDownListDayType.SelectedValue = dt.Rows[0]["day_type"].ToString();
                numericOrder.Text = dt.Rows[0]["order_num"].ToString();

            }

            

            
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string cmd = "";
            try
            {


                if (textBoxName.Text.Length == 0)
                {
                    LabelErr.Visible = true;
                    LabelErr.Text = "חובה למלא תיאור תפילה לתצוגה בלוח ";

                }
                else if (textBoxFixHour.Text.Length == 0 && numericMinutes.Text.Length == 0)
                {
                    LabelErr.Visible = true;
                    LabelErr.Text = "חובה למלא שעה קבועה או שעה יחסית";

                }
                else
                {

                    string fixHour = "null";
                    if (textBoxFixHour.Text.Length > 0)
                        fixHour = "'" + textBoxFixHour.Text + "'";

                    cmd = "update  syn_times set fix_hour = '" + textBoxFixHour.Text +"'";
                    cmd += ", name  = '" + textBoxName.Text + "'";
                    cmd += ",time_type  = '" + DropDownListTfilaType.SelectedValue + "'";
                    cmd += ",gap_minutes = " + numericMinutes.Text;
                    cmd += ",gap_type  = '" + DropDownListGapType.SelectedValue + "'";
                    cmd += ",day_type  = '" + DropDownListDayType.SelectedValue +"'";
                    cmd += ",order_num = " + numericOrder.Text;

           

                    cmd += " where syn_id = " + Session["syn_id"] + "  and time_id= " + timeId;

                    DBService.ExecuteStatement(cmd);
                    Response.Redirect("NihulZmanim.aspx");

                }
            }
            catch (Exception err)
            {
                Response.Write(err.ToString());
                Response.Write("cmd -" + cmd);
                Response.Write("Session " + Session["SYN_ID"] );

                
            }



        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NihulZmanim.aspx");
        }

    }
}