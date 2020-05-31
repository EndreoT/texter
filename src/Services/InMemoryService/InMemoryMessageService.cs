using System.Collections.Concurrent;
using Texter.Domain.Models;
using Texter.Domain.Services;

namespace Texter.Services.InMemoryService
{
    //Singleton
    public class InMemoryMessageService : IInMemoryMessageService
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<Message>> _messages;

        public InMemoryMessageService()
        {
            _messages = new ConcurrentDictionary<string, ConcurrentQueue<Message>>();
        }

        public void AddMessage(string address, Message message)
        {
            ConcurrentQueue<Message> queue;
            if (_messages.ContainsKey(address))
            {
                queue = _messages[address];
            }
            else
            {
                queue = new ConcurrentQueue<Message>();
                _messages.TryAdd(address, queue);
            }
            queue.Enqueue(message);
        }

        public ConcurrentQueue<Message> ExtractMessagesForAddress(string address)
        {
            _messages.TryRemove(address, out ConcurrentQueue<Message> messagesForAddr);

            return messagesForAddr;
        }
    }


}
