using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Domain.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string SourceAddr { get; set; }
        public string DestAddr { get; set; }
        public string Content { get; set; }

    }
}
