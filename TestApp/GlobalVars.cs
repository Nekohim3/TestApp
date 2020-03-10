using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace TestApp
{
    public class GlobalVars
    {
        public static Logger Log = LogManager.GetCurrentClassLogger();
    }
}
