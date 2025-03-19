using System;

namespace WebApplicationLUACH.Controllers
{
    public class LuachTime
    {
        public string Desc { get;  set; }
        public string TypeTime { get;  set; }
        public string FixTime { get;  set; }
        public string MinutesGap { get; internal set; }
        public string GapType { get; internal set; }
        public string DayType { get; internal set; }
    }
}