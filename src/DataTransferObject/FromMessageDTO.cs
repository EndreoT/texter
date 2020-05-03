using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;

namespace Texter.DataTransferObject
{
    public class FromMessageDTO
    {
        public long MessageId { get; set; }
        public string Content { get; set; }

        public Device SourceAddr { get; set; }
        public Device DestinationAddr{ get; set; }

    }
}
