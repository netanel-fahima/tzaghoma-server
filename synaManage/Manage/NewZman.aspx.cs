using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class NewZman : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");


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



                    cmd = "insert into dbo.syn_times values(" + Session["SYN_ID"] + ",";

                    string sql = "select Isnull(max(time_id),0) + 1  from syn_times where syn_id = " + Session["SYN_ID"];






                    cmd += DBService.getResult(sql) + ", ";
                    string fixHour = "null";
                    if (textBoxFixHour.Text.Length > 0)
                        fixHour = "'" + textBoxFixHour.Text + "'";

                    cmd += "'" + DropDownListTfilaType.SelectedValue + "','" + textBoxName.Text + "'," + fixHour + ",'" + numericMinutes.Text + "','" + DropDownListGapType.SelectedValue + "','" + DropDownListDayType.SelectedValue + "'," + numericOrder.Text + ")";

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