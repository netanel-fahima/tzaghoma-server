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
            /*string con = "server = ypdbdev02; Integrated Security = True; database = app_dev; ";
           */ 
            string sql = "select * FROM syn_times where syn_id = " + id + " order by [day_type] ,[order_num] ";
            
            
            //DataTable dt = GeneralFunc.GetDataTableFromSQL(sql);

            DataTable dt = DBService.getDataTable(sql);

            foreach (DataRow dr in  dt.Rows)
            {
                lTimes.Add(new LuachTime { Desc =dr["Name"].ToString() , TypeTime =  dr["time_type"].ToString() , FixTime = dr["fix_hour"].ToString() ,
                                           MinutesGap = dr["gap_minutes"].ToString() , GapType = dr["gap_type"].ToString(),DayType = dr["day_type"].ToString()
                });

            }

            var retVal = new GeneralData();
            retVal.Times = lTimes;


            

            string sqlSynData = "SELECT *  FROM syn, cities c  where syn.city_id = c.city_id " +
                                "and syn_id = " + id ;

            DataTable dtSynData = DBService.getDataTable(sqlSynData);
            retVal.SynName = dtSynData.Rows[0]["syn_name"].ToString();
            retVal.CityCode = dtSynData.Rows[0]["city_id"].ToString();
            retVal.CityName = dtSynData.Rows[0]["name"].ToString();

            string sqlSynTitles = "select * FROM titles where syn_id = " + id + " order by orderNo";
            DataTable dtSynTitles = DBService.getDataTable(sqlSynTitles);
            if (dtSynTitles.Rows.Count > 0)
            {
                retVal.Title1 = dtSynTitles.Rows[0]["title"].ToString();
                retVal.Title2 = dtSynTitles.Rows[1]["title"].ToString();
                retVal.Title3 = dtSynTitles.Rows[2]["title"].ToString();
                retVal.Title4 = dtSynTitles.Rows[3]["title"].ToString();
            }


            string sqlMessageText = "select * FROM MessageText where syn_id = " + id + " order by orderNo"; 
            DataTable dtMessageText = DBService.getDataTable(sqlMessageText);
            
            if (dtMessageText.Rows.Count > 0)
            {
                retVal.MessageText1 = dtMessageText.Rows[0]["text"].ToString();
                retVal.MessageText2 = dtMessageText.Rows[1]["text"].ToString();
            }



            string sqlCommands = "select * FROM commands where done != 'Y' and syn_id = " + id ;
            DataTable dtCommands = DBService.getDataTable(sqlCommands);
            if (dtCommands.Rows.Count > 0)
            {
                retVal.Command = new Command { Id = dtCommands.Rows[0]["command_id"].ToString(), CommandText = dtCommands.Rows[0]["command"].ToString() }; ;

            }


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
