using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Net;
using System.IO;
using System.Text;

namespace kanis
{
    public partial class HodatHerumPage : Page
    {
        public string Text { get; internal set; }
        public string CityCode { get; internal set; }
        public string CityName { get; internal set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["userName"] == null || Session["userName"].ToString() == "")
                Response.Redirect("~/Account/Login.aspx");

            string userName = Session["userName"].ToString();            //Context.User.Identity.GetUserName()

            DataTable dtRoles = DBService.getDataTable("select * from users where user_mail = '" + userName + "'");
            if (dtRoles.Rows[0]["user_role"].ToString() == "ADMIN")
            {
                if (!this.IsPostBack)
                {
                    DropDownListCities.DataValueField = "city_id";
                    DropDownListCities.DataTextField = "name";
                    DropDownListCities.DataSource = DBService.getDataTable("select * from cities");
                    DropDownListCities.DataBind();
                    DropDownListCities.SelectedIndex = 0;

                    TextBoxEergency.Text = DBService.getResult("select text from hodaot_herum where city_id = " + DropDownListCities.SelectedValue);

                }

                CityCode = DropDownListCities.SelectedValue;
                CityName = DropDownListCities.SelectedItem.Text;

                LabelTitle.Text = " הודעת חירום עיריית ";
               
            }
            else if (dtRoles.Rows[0]["user_role"].ToString() == "KABAT")
            {
                DropDownListCities.Visible = false;
                DataTable dt = DBService.getDataTable("SELECT  * FROM cities where city_id in " +
                                   "(select cityid from users where user_mail = '" + userName + "')");
                if (dt.Rows.Count > 0)
                {
                    CityCode = dt.Rows[0]["city_id"].ToString();
                    CityName = dt.Rows[0]["name"].ToString();
                    LabelTitle.Text = " הודעת חירום עיריית " + CityName;
                }

                

            }
            else
            {
                Response.Redirect("Main.aspx");
            }


            if (!this.IsPostBack)
            {
                if (CityCode != null)
                {
                    TextBoxEergency.Text = DBService.getResult("select text from hodaot_herum where city_id = " + CityCode);

                }
                else
                {
                    LabelTitle.Text = "לא הוגדרה עירייה ליוזר יש לפנות למנהל המערכת";
                    ButtonSave.Enabled = false;
                    ButtonCancel.Enabled = false;
                }


            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            GeneralService.logger("hodat_herum", "start save");

            if (TextBoxEergency.Text.Length == 0)
            {
                LabelStatus.Text = "לא ניתן לשמור הודעה ריקה ";
                LabelStatus.ForeColor = Color.Red; 
            
              
            }
            else
            {
                string str = "insert into hodaot_herum values(" + CityCode + ",'" + TextBoxEergency.Text + "')";
                
                if (DBService.getResult("select count(*) from hodaot_herum where city_id = " + CityCode) == "0")
                {
                    GeneralService.logger("hodat_herum", "no message");


                    DBService.ExecuteStatement(str);
                }

                else
                {
                    GeneralService.logger("hodat_herum", "yes message");
                    str = "update hodaot_herum set text ='" + TextBoxEergency.Text + "' " +
                                 "where city_id = " + CityCode;


                    DBService.ExecuteStatement(str);
                    



                }
                GeneralService.logger("hodat_herum", "save end");

                setMessageTzagAsync(CityCode,TextBoxEergency.Text);
                LabelStatus.Text = "ההודעה נשלחה בהצלחה";
                LabelStatus.ForeColor = Color.Orange;
            }
        }
        private void setMessageTzagAsync(string cityCode ,  string msg)
        {
            if (cityCode == "1")
            {


                string address = "https://www.smart-bell.net/Set_Tzag_Text.aspx/?SelText=" + msg + "&FolderID=0000&StyleID=Netivot&ObjID=000&Pass=089446";


                try
                {

                    HttpWebRequest request = WebRequest.Create(address) as System.Net.HttpWebRequest;
                    //optional
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    Stream stream = response.GetResponseStream();
                    //stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        string s = reader.ReadToEnd();
                    }

                }
                catch (Exception err)
                { }
            }
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            TextBoxEergency.Text = "";

            string str = "update hodaot_herum set text = '' " +
               "where city_id = " + CityCode;


            DBService.ExecuteStatement(str);
            setMessageTzagAsync(CityCode,"");
            LabelStatus.Text = "ביטול ההודעה עודכן";
            LabelStatus.ForeColor = Color.Green;
        }

        protected void DropDownListCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxEergency.Text = DBService.getResult("select text from hodaot_herum where city_id = " + DropDownListCities.SelectedValue);

        }
    }
}