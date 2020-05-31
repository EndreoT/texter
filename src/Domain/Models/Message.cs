namespace Texter.Domain.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public Device SourceAddr { get; set; }
        public long SourceAddrDeviceId { get; set; }
        public Device DestinationAddr { get; set; }
        public long DestinationAddrDeviceId { get; set; }

        public string Content { get; set; }
    }
}
