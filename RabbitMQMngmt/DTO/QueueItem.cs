using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMngmt.DTO
{
    public class QueueItem : RmqDataItem
    {
        public int Messages { get; set; }
        public bool Durable { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2} messages)", Name, (Durable) ? "Durable" : "Non durable", Messages);
        }
    }
}
