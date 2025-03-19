using System.Collections.Generic;

namespace WebApplicationLUACH.Controllers
{
    public class GeneralData
    {
        public GeneralData()
        {
        }

        public string SynName { get;  set; }
        public string MessageText1{ get;  set; }
        public string MessageText2 { get;  set; }
        public List<LuachTime> Times { get;  set; }
     
        public string Title1 { get;  set; }
        public string Title2 { get;  set; }
        public string Title3 { get;  set; }
        public string Title4 { get; set; }
        public Command Command { get;  set; }
        public string CityCode { get;  set; }
        public string CityName { get; internal set; }
     
    }
}