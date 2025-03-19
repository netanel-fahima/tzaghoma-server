using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace synaManage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            
            DataTable dtSyn = DBService.getDataTable("select syn_id , syn_name from syn");
            dropDownSyn.DataValueField = "syn_id";
            dropDownSyn.DataTextField = "syn_name";
            dropDownSyn.DataSource = dtSyn;
            dropDownSyn.DataBind();
            
            dropDownSyn.SelectedIndex = 0;
//  hyperLinkSyn.Text = " (לצפייה במסך מחשב) צג בית הכנסת";// + synDropDown.
            hyperLinkSyn.NavigateUrl = "https://a-digital.co.il/luach/index.html?synid=" + dropDownSyn.SelectedValue;
            }





        }

        protected void dropDownSyn_SelectedIndexChanged(object sender, EventArgs e)
        {

            hyperLinkSyn.NavigateUrl = "https://a-digital.co.il/luach/index.html?synid=" + dropDownSyn.SelectedValue; 

        }

      
    }
}