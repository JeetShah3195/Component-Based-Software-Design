using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Entertainment : Disk
    {
        private TimeSpan runTime;

        public Entertainment()
        {
        }

        public Entertainment(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime)
          : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk)
        {
            this.RunTime = rTime;
        }

        public string RunTime
        {
            get
            {
                return runTime.Hours.ToString() + ":" + runTime.Minutes.ToString() + ":" + runTime.Seconds.ToString();
            }
            set
            {
                string[] strArray = value.Split(':');
                runTime = new TimeSpan(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]));
            }
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + runTime.Hours + ":" + runTime.Minutes + ":" + runTime.Seconds;
        }

        public override string ToString()
        {
            return getDisplayText("\r\n");
        }

        public override string ToCSV()
        {
            return getDisplayText(",");
        }
    }
}
