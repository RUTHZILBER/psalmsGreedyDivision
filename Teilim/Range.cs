using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psalms
{
    class Range
    {

        /// <summary>
        /// מפרק
        /// </summary>
        public int From { get; set; }
        /// <summary>
        /// עד פרק
        /// </summary>
        public int To { get; set; }
        /// <summary>
        /// מספר הפרקים
        /// </summary>
        public int Count { get; set; }

        public Range()
        {
        }

        public Range(int from, int to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
