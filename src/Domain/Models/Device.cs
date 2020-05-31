namespace Texter.Domain.Models
{
    public class Device
    {
        public long DeviceId { get; set; }
        public string Address { get; set; }

        //public ICollection<Message> SentMessages { get; set; }

        //public ICollection<Message> ReceiveMessages { get; set; }
    }
}
