using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace API
{
    public class Record
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public Fields fields { get; set; }
        public Geometry geometry { get; set; }
        public DateTime record_timestamp { get; set; }

        public string[] ListRecordProperty()
        {
            var listRecordProperty = Utils.PropertiesFromType(this.ListRecordProperty());


            return listRecordProperty;
        }

    }
}
