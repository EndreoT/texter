using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Texter.Domain.Models
{
    public class Device
    {
        public long DeviceId { get; set; }
        public string Address { get; set; }

        //[InverseProperty(nameof(Message.SourceAddr))]
        //public List<Message> SentMessages { get; set; }

        //[InverseProperty(nameof(Message.DestinationAddr))]
        //public List<Message> ReceiveMessages { get; set; }
    }
}
