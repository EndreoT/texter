using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Texter.DataTransferObject
{
    public class SaveMessageDTO
    {
        [Required]
        [MaxLength(30)]
        public string SourceAddr { get; set; }

        [Required]
        [MaxLength(30)]
        public string DestAddr { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
