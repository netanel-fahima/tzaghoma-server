using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationLUACH.Controllers
{
    public class GeneralDataController : ApiController
    {
        // GET: api/GeneralData
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GeneralData/5
        public GeneralData Get(int id)
        {
            var lTimes = new List<LuachTime>();
            string con = "server = ypdbdev02; Integrated Security = True; database = app_dev; ";
            string sql = "select * FROM[APP_DEV].[dbo].[syn_times] where syn_id = " + id + " order by [day_type] ,[order_num] ";

            
            DataTable dt = GeneralFunc.GetDataTableFromSQL(con, sql);
            foreach (DataRow dr in  dt.Rows)
            {
                lTimes.Add(new LuachTime { Desc =dr["Name"].ToString() , TypeTime =  dr["time_type"].ToString() , FixTime = dr["fix_hour"].ToString() ,
                                           MinutesGap = dr["gap_minutes"].ToString() , GapType = dr["gap_type"].ToString(),DayType = dr["day_type"].ToString()
                });

            }
            
            var retVal = new GeneralData();
            retVal.SynName = "בית כנסת הרמבם";
            retVal.MessageTitle1 = "הודעות";
            retVal.MessageTitle2 = "שהשמחה במעונו";
            retVal.Times = lTimes;
        
            return retVal;
        }

        // POST: api/GeneralData
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GeneralData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GeneralData/5
        public void Delete(int id)
        {
        }
    }
}
