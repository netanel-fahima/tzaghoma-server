using System.Collections.Generic;

namespace WebApplicationLUACH.Controllers
{
    public class GeneralData
    {
        public GeneralData()
        {
        }

        public string SynName { get;  set; }
        public string MessageTitle1 { get;  set; }
        public string MessageTitle2 { get;  set; }
        public List<LuachTime> Times { get;  set; }
    }
}