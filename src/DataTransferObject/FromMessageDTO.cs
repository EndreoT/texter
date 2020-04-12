using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.DataTransferObject
{
    public class FromMessageDTO
    {
        public long Id { get; set; }
        public string SourceAddr { get; set; }
        public string DestAddr { get; set; }
        public string Content { get; set; }
    }
}
