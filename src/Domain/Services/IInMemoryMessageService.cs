using System.Collections.Concurrent;
using Texter.Domain.Models;

namespace Texter.Domain.Services
{
    public interface IInMemoryMessageService
    {
        public void AddMessage(string address, Message message);

        public ConcurrentQueue<Message> ExtractMessagesForAddress(string address);
    }
}
