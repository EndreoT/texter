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
