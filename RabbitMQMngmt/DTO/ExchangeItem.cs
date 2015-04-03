using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMngmt.DTO
{
    public class ExchangeItem : RmqDataItem
    {
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
