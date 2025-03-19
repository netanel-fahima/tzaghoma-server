using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationLUACH.Controllers
{
    public class TimesController : ApiController
    {
        // GET: api/Times
        public List<DayTimes> Get()
        {
            var dayTimeList = new List<DayTimes>();
            dayTimeList.Add(new DayTimes { Day = "22/11/2023", Sunset = "16:30", Sunrize = "06:05", Parasha1 = "ויצא", Parsha2 = "" });
            dayTimeList.Add(new DayTimes { Day = "23/11/2023", Sunset = "16:26", Sunrize = "06:06", Parasha1 = "ויצא", Parsha2 = "" });
            dayTimeList.Add(new DayTimes { Day = "24/11/2023", Sunset = "16:25", Sunrize = "06:07", Parasha1 = "ויצא", Parsha2 = "" });
            dayTimeList.Add(new DayTimes { Day = "25/11/2023", Sunset = "16:20", Sunrize = "06:08", Parasha1 = "ויצא", Parsha2 = "" });
            dayTimeList.Add(new DayTimes { Day = "26/11/2023", Sunset = "16:31", Sunrize = "06:09", Parasha1 = "ויצא", Parsha2 = "" });
            return dayTimeList;
        }

        // GET: api/Times/5
        public List<DayTimes> Get(int id)
        {
            var dayTimeList = new List<DayTimes>();
            dayTimeList.Add(new DayTimes { Day = "22/11/2023" , Sunset ="16:30",Sunrize="06:05" , Parasha1 ="ויצא", Parsha2 = ""  });
            dayTimeList.Add(new DayTimes { Day = "23/11/2023" , Sunset ="16:26",Sunrize="06:06" , Parasha1 ="ויצא", Parsha2 = ""  });
            dayTimeList.Add(new DayTimes { Day = "24/11/2023" , Sunset ="16:25",Sunrize="06:07" , Parasha1 ="ויצא", Parsha2 = ""  });
            dayTimeList.Add(new DayTimes { Day = "25/11/2023" , Sunset ="16:20",Sunrize="06:08" , Parasha1 ="ויצא", Parsha2 = ""  });
            dayTimeList.Add(new DayTimes { Day = "26/11/2023" , Sunset ="16:31",Sunrize="06:09" , Parasha1 ="ויצא", Parsha2 = ""  });
            return dayTimeList;
        }

        // POST: api/Times
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Times/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Times/5
        public void Delete(int id)
        {
        }
    }
}
