using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class UpdateSettings : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");

            labelTitle.InnerText = Session["Syn_Name"].ToString();
            if (!IsPostBack)
            {
                DataTable dtTitles = DBService.getDataTable("select * from titles where syn_id = " + Session["Syn_id"] + " order by orderno ");
                DataTable dtMessages = DBService.getDataTable("select * from MessageText where syn_id = " + Session["Syn_id"] + " order by orderno ");

                if (dtTitles.Rows.Count > 0)
                {
                    textBoxTitle1.Text = dtTitles.Rows[0]["title"].ToString();
                    textBoxTitle2.Text = dtTitles.Rows[1]["title"].ToString();
                    textBoxTitle3.Text = dtTitles.Rows[2]["title"].ToString();
                    textBoxTitle4.Text = dtTitles.Rows[3]["title"].ToString();
                }
                if (dtMessages.Rows.Count > 0)
                {
                    
                    textBoxMessage1.Text = dtMessages.Rows[0]["text"].ToString();
                    textBoxMessage2.Text = dtMessages.Rows[1]["text"].ToString();
                }

            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            //titles
            DBService.ExecuteStatement("update dbo.titles set title = '" + textBoxTitle1.Text + "' where syn_id = " + Session["syn_id"] + " and orderNo = 1");
            DBService.ExecuteStatement("update dbo.titles set title = '" + textBoxTitle2.Text + "' where syn_id = " + Session["syn_id"] + " and orderNo = 2");
            DBService.ExecuteStatement("update dbo.titles set title = '" + textBoxTitle3.Text + "' where syn_id = " + Session["syn_id"] + " and orderNo = 3");
            DBService.ExecuteStatement("update dbo.titles set title = '" + textBoxTitle4.Text + "' where syn_id = " + Session["syn_id"] + " and orderNo = 4");

            //messages
            DBService.ExecuteStatement("update dbo.MessageText set text = '" + textBoxMessage1.Text + "' where syn_id = " + Session["syn_id"] + " and orderNo = 1");
            DBService.ExecuteStatement("update dbo.MessageText set text = '" + textBoxMessage2.Text + "' where syn_id = " + Session["syn_id"] + " and orderNo = 2");






                
                Response.Redirect("Main.aspx");

           
            

           
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NihulZmanim.aspx");
        }
    }
}