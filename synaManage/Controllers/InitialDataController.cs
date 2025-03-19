using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationLUACH.Controllers
{
    public class InitialDataController : ApiController
    {
        // GET: api/InitialData
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/InitialData/5
        public InitialData Get(int id)
        {
            var lScreens = new List<ScreenData>();

            string sql = "select * FROM syn_screens where  syn_id = " + id;

            DataTable dt = DBService.getDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                lScreens.Add(new ScreenData
                {
                    ScreenType = dr["screen_type"].ToString(),
                    BgImageName = dr["bg_img_name"].ToString()
                });

            }

            var retVal = new InitialData();
            retVal.Screens = lScreens;

            string sql2 = "select * FROM syn where  syn_id = " + id;

            DataTable dt2 = DBService.getDataTable(sql2);

            retVal.Footer = new FooterData
            {
                textLeftFooter = dt2.Rows[0]["footer_left_text"].ToString(),
                imgLeftFooter = dt2.Rows[0]["footer_left_img"].ToString(),
                textRightFooter = "052-329-2977",//not use dt2.Rows[0]["footer_right_text"].ToString(),
                imgRightFooter = "logo-zag-digital.png"
            };

            retVal.SubscriptionType = dt2.Rows[0]["subscription_type"].ToString();

            return retVal;
        }

        // POST: api/InitialData
        public void Post([FromBody] string value)
        {


        }

        // PUT: api/InitialData/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/InitialData/5
        public void Delete(int id)
        {
        }
    }
}
