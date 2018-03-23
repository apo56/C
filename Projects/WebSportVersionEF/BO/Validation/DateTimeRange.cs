using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validation
{
    class DateTimeRange : RangeAttribute
    {
        public DateTimeRange(int fromNowStart, int fromNowEnd) : base(typeof(DateTime), DateTime.Now.AddYears(fromNowStart).ToShortDateString(), DateTime.Now.AddYears(fromNowEnd).ToShortDateString())
        {

        }
    }
}
