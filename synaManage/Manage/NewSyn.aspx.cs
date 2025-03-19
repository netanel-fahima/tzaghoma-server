using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class NewSyn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                DataTable dt = DBService.getDataTable("select * from cities");
                DropDownListCities.DataValueField = "city_id";
                DropDownListCities.DataTextField = "name";

                DropDownListCities.DataSource = dt;
                DropDownListCities.DataBind();
                

            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length == 0 )
            {
                LabelErr.Visible = true;
                LabelErr.Text = "חובה למלא שם לבית הכנסת  ";

            }
            else if (DropDownListCities.SelectedValue.ToString().Length == 0 )
            {
                LabelErr.Visible = true;
                LabelErr.Text = "חובה לבחור עיר";

            }
            else
            {


                string sql = "select max(syn_Id) + 1  from syn";
                string synId = DBService.getResult(sql);

                string cmd = "insert into dbo.syn values(" + synId + ",'" + textBoxName.Text + "','" + textBoxAdress.Text + "'," + DropDownListCities.SelectedValue + ",'בחסות מחלקת בטחון,עיריית נתיבות','logo-netivot.png','BASE')";

                //string sql = "select max(time_id) + 1  from syn_times where syn_id = " + Session["SYN_ID"];






               
                DBService.ExecuteStatement(cmd);


                



 



  


  










                //titles
                DBService.ExecuteStatement("insert into dbo.titles values(" + synId + ",'זמנים לחול',1)");
                DBService.ExecuteStatement("insert into dbo.titles values(" + synId + ",'זמנים לשבת',2)");
                DBService.ExecuteStatement("insert into dbo.titles values(" + synId + ",'שהשמחה במעונם',3)");
                DBService.ExecuteStatement("insert into dbo.titles values(" + synId + ",'הודעות',4)");


                //messages
                DBService.ExecuteStatement("insert into dbo.MessageText values(" + synId + ",'הודעה 1',1)");
                DBService.ExecuteStatement("insert into dbo.MessageText values(" + synId + ",'הודעה 2',2)");

                DBService.ExecuteStatement("insert into dbo.syn_screens values(" + synId + ", 'MAIN', '4win_bg_with_footer.jpg')");



                Response.Redirect("Main.aspx");

            }
            

           
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}