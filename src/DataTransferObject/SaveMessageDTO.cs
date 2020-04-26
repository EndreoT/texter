using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Texter.DataTransferObject
{
    public class SaveMessageDTO
    {
        [Required]
        public string SourceAddr { get; set; }

        [Required]

        public string DestinationAddr { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
