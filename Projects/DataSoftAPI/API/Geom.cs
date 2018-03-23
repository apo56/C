using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Geom
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
}
