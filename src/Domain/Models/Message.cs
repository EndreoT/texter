using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Texter.Domain.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public string SourceAddr { get; set; }
        public string DestinationAddr { get; set; }
        public string Content { get; set; }
    }
}
