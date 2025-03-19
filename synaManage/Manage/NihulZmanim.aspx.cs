using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class NihulZmanim : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");

            //setSesionData();

            labelLink.Text = "https://a-digital.co.il/luach/index.html?synid=" + Session["syn_id"];
            
            if  (Session["syn_name"] is null )
            {//טיפול במצב שאדמן נכנס לדף בית כנסת ללא מעבר בדף הראשי  במקרה כזה יחזור לדף הרשי 
                string  query = "select user_role from users where user_role = 'ADMIN' and user_mail = '" + Context.User.Identity.Name + "'";


                if (DBService.getResult(query).Length > 0)
                {
                    Response.Redirect("main.aspx");
                }
            }
                
            labelSynName.InnerText = Session["syn_name"].ToString();
            GridViewZmanim.RowDeleting += GridViewZmanim_RowDeleting;
            GridViewZmanim.RowEditing += GridViewZmanim_RowEditing; ;

            string str = "select time_id 'מספר רשומה' ,  name 'שם המוצג בלוח ' , " + 
             " IIF(fix_Hour is null, concat(gap_minutes, ' דקות ',case when gap_type = 'AFTER_SUNSET' then 'אחרי שקיעה' " +
             " when  gap_type = 'PRE_SUNSET' then 'לפני שקיעה' " +
             " when  gap_type = 'AFTER_SUNRIZE' then 'אחרי זריחה'" +
             " when  gap_type = 'PRE_SUNRIZE' then 'לפני זריחה'" +
             " end), fix_Hour) 'שעה לתצוגה' "+
             " ,case when day_type = 'SHABAT' then 'שבת' else 'חול' end  'סוג יום'" + 
             " , order_num 'סדר תצוגה'" +
             " from syn_times where syn_id = " + Session["SYN_ID"] +
             " order by day_type,order_num";

            DataTable dt = DBService.getDataTable(str);
            GridViewZmanim.DataSource = dt;
            GridViewZmanim.DataBind();

         
           /* var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            this.GridViewZmanim.Columns.Add(deleteButton);*/
        }

        private void GridViewZmanim_RowEditing(object sender, GridViewEditEventArgs e)
            {
            Response.Redirect("UpdZman.aspx?timeid=" + ((DataTable)(GridViewZmanim.DataSource)).Rows[e.NewEditIndex][0]);

            
        }

        private void GridViewZmanim_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DBService.ExecuteStatement("delete syn_times where syn_id = " + Session["SYN_ID"] + " and time_id = " + e.Values[0]);

            Response.Redirect("NihulZmanim.aspx");
        }
    }
}